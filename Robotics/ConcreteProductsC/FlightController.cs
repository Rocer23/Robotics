namespace Robotics
{
    // ConcreteProductC1
    public class FlightController : AbstractController
    {
        private bool isArmed = false;
        private string flightMode = "STABILIZE";
        private float batteryLevel = 100.0f;
        private float altitude = 0.0f;

        public FlightController()
        {
            Console.WriteLine("Ініціалізація польотного контролера");
        }


        public override string process(string command)
        {
            Console.WriteLine($"Обробка команди: {command}");

            if (!isArmed)
            {
                return "Помилка: дрон не збройований.";
            }

            switch (command.ToLower())
            {
                case "takeoff":
                    altitude = 10.0f;
                    return $"Зліт на висоту {altitude} м";

                case "land":
                    altitude = 0.0f;
                    return "Посадка";

                default:
                    return $"Команда Виконана: {command}";
            }
        }

        public override bool initialize(string parameters)
        {
            Console.WriteLine($"Ініціалізація з параметрами: {parameters}");
            Thread.Sleep(100);
            return true;
        }

        public override void shutdown()
        {
            Console.WriteLine("Вимкнення польотного контролера...");
            isArmed = false;
            batteryLevel = 0.0f;
            altitude = 0.0f;
            Thread.Sleep(200);

            Console.WriteLine("Контролер вимкнено.");
        }

        public override void updateParameters(string parameters)
        {
            Console.WriteLine($"Оновлення параметрів: {parameters}");

            if (parameters.Contains("battery="))
            {
                var parts = parameters.Split("=");
                if (parts.Length == 2 && float.TryParse(parts[1], out float battery))
                {
                    batteryLevel = battery;
                }
                Console.WriteLine($"Рівень батареї: {batteryLevel}%");
            }
        }

        public override string diagnose()
        {
            return $"Діагностика польотного контролера:\n Збройовано: {isArmed}\n Режим польоту: {flightMode}\n Батарея: {batteryLevel}%\n Висота: {altitude} м";
        }

        public override string getVersion()
        {
            return "FlightController v2.1.4";
        }
    }
}