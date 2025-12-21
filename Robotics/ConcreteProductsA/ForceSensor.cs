namespace Robotics
{
    
    public class ForceSensor : AbstractSensor
    {

        private float measurementRange = 100.0f;
        private bool isCalibrated = false;
        private float zeroPoint = 0.0f;
        private float temperature = 25.0f;

        public ForceSensor(float range)
        {
           measurementRange = range;
        }

        // ConcreteProductA2
        public override string readData()
        {
            Random simulatedForce = new Random();
            float simulated = (float)simulatedForce.NextDouble() * measurementRange;
            float compensatedForce = simulated * (1.0f - (temperature - 25.0f) * 0.001f);

            return $"Сила: {compensatedForce} N";
        }

        public override bool calibrate()
        {
            Console.WriteLine("Калібрування датчика сили...");

            zeroPoint = 0.0f;
            Thread.Sleep(500);

            isCalibrated = true;

            Console.WriteLine($"Калібрування успішне. Нульова точка: {zeroPoint} N");
            return true;
        }

        public override float getAccuracy()
        {
            if (isCalibrated)
            {
                return 0.98f;
            }
            else
            {
                return 0.85f;
            }
        }

        public override bool isActive()
        {
            return true;
        }

        public override void reset()
        {
            Console.WriteLine("Скидання датчика сили...");
            isCalibrated = false;
            zeroPoint = 0.0f;
            Thread.Sleep(300);
            Console.WriteLine("Датчик сили скинуто");
        }

        public override void configure(string config)
        {
            Console.WriteLine($"Налаштування датчика сили: {config}");

            if (config.Contains("range="))
            {
                int startIndex = config.IndexOf("newRange=") + "newRange=".Length;
                int endIndex = config.IndexOf(";", startIndex);

                string rangeString;
                if (endIndex == -1)
                {
                    rangeString = config.Substring(startIndex);
                }
                else
                {
                    rangeString = config.Substring(startIndex, endIndex - startIndex);
                }

                if (float.TryParse(rangeString, System.Globalization.CultureInfo.InvariantCulture, out float newRange))
                {
                    measurementRange = newRange;
                    Console.WriteLine($"Діапазон вимірювання: {measurementRange} N");
                }
            }

            if (config.Contains("temp_comp"))
            {
                Console.WriteLine("Компенсація температури активована");
            }
        }
    }
}