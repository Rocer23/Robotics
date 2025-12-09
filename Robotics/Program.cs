namespace Robotics
{
    // Client
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Будь ласка виберіть фабрику: ");
            int chooseFactory = Convert.ToInt16(Console.ReadLine());
            RobotFactory factory = new DroneFactory();

            if (chooseFactory == 1)
            {
                factory = new DroneFactory();
            }
            if (chooseFactory == 2)
            {
                factory = new ManipulatorFactory();
            }

            if (chooseFactory == 3)
            {
                factory = new ServiceRobotFactory();
            }



            AbstractSensor sensor = factory.CreateSensor();
            AbstractActuator actuator = factory.CreateActuator();
            AbstractController controller = factory.CreateController();

            Console.WriteLine($"{factory.GetType().Name}: ");
            Console.Write($"Sensor - {sensor.GetType().Name}: ");
            sensor.readData();
            Console.Write($"Actuator - {actuator.GetType().Name}: ");
            actuator.move();
            Console.Write($"Controller - {controller.GetType().Name}: ");
            controller.process();
        }
    }    
}