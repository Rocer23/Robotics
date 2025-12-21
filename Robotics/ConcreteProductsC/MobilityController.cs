namespace Robotics
{
    // ConcreteProductC3
    public class MobilityController : AbstractController
    {
        private float speed = 0.0f;
        private int[] destination = [0, 0];
        private bool obstactleDetection = true; 


        public MobilityController()
        {
            Console.WriteLine("Контролер пересування ініціалізовано.");
        }

        public override string process(string command)
        {
            int[] coords = command.Split(" ").Select(int.Parse).ToArray();

            destination = coords;

            Console.WriteLine($"Навігація до координат: {string.Join(", ", destination)}");

            if (obstactleDetection)
            {
                Console.WriteLine("Первірка перешкод...");
                Thread.Sleep(100);
            }

            return $"Шлях до {string.Join(", ", destination)} сплановано";
        }

        public override bool initialize(string parameters)
        {
            Console.WriteLine($"налаштування контролера пересування: {parameters}");
            Thread.Sleep(100);

            return true;
        }

        public override void shutdown()
        {
            Console.WriteLine("Зупинка контролера пересування");
            speed = 0.0f;
        }

        public override void updateParameters(string parameters)
        {
            Console.WriteLine($"оновлення параметрів: {parameters}");

            if (parameters.Contains("speed="))
            {
                var speed = float.Parse(parameters.Split("speed=")[1].Split(" ")[0]);
                this.speed = speed;
            }
        }

        public override string diagnose()
        {
            return $"Контролер пересування: швидкість = {speed} м/с, детекція перешкод = {obstactleDetection}";
        }

        public override string getVersion()
        {
            return "MobilityController v3.0";
        }
    }
}