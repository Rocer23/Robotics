namespace Robotics
{
    // ConcreteProductA1
    public class AerialCamera : AbstractSensor
    {
        private string resolution = "1920x1080";
        private float zoomLevel = 1.0f;
        private bool _isActive = true;
        private bool calibrationStation = false;

        public AerialCamera(string initialResolution)
        {
            this.resolution = initialResolution;
        }

        public override string readData()
        {
            return "Аерознімок: координати (45.123, 23.456), температура 25°C";
        }

        public override bool calibrate()
        {
            Console.WriteLine("Початок калібрування авіаційної камери...");

            calibrationStation = true;
            zoomLevel = 1.0f;

            if (calibrationStation)
            {
                Console.WriteLine("Калібрування успішне. Точність: 98.5%");
                return true;
            }
            else
            {
                Console.WriteLine("Помилка калібрування");
                return false;
            }
        }

        public override float getAccuracy()
        {
            if (calibrationStation)
            {
                return 0.985f;
            } 
            else
            {
                return 0.750f;    
            }
        }

        public override bool isActive()
        {
            return _isActive;
        }

        public override void reset()
        {
            Console.WriteLine("Скидання камери до заводських налаштувань");
            zoomLevel = 1.0f;
            resolution = "1920x1080";
            calibrationStation = false;
            _isActive = false;

            Thread.Sleep(1000);

            _isActive = true;
            Console.WriteLine("Камеру скинуто та перезапущено");
        }

        public override void configure(string config)
        {
            Console.WriteLine("Застосування конфігурації: " + config);

            if (config.Contains("4K"))
            {
                resolution = "3840x2160";
            } 
            else if (config.Contains("1080p"))
            {
                resolution = "1920x1080";
            }

            if (config.Contains("zoom"))
            {
                int startIndex = config.IndexOf("zoomValue=") + "zoomValue=".Length;

                int endIndex = config.IndexOf(";", startIndex);

                if (endIndex == -1)
                {
                    endIndex = config.Length;
                }

                string zoomValueString = config.Substring(startIndex, endIndex - startIndex);

                if (float.TryParse(zoomValueString, out float extractedValue))
                {
                    zoomLevel = extractedValue;
                    Console.WriteLine($"Рівень масштабу встановлено на {zoomLevel}");
                }
                else
                {
                    Console.WriteLine("Помилка при парсингу zoomValue");
                }
            }
            else
            {
                Console.WriteLine($"'zoomValue' не знайдено в конфігурації. Використовується значення за замовчуванням: {zoomLevel}");
            }
        }
    }
}