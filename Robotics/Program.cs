using System.Reflection;

namespace Robotics
{
    // Client
    class Program
    {
        static void Main(string[] args)
        {
           RobotAssembler assembler = new RobotAssembler();

            Console.WriteLine("Step 1: Creating Drone");
            RobotFactory droneFactory = new DroneFactory();
            Robot drone = assembler.assembleRobot(droneFactory, "Drone-X1");
            Console.WriteLine("");

            Console.WriteLine("Step 2: Creating Manipulator");
            RobotFactory manipulatorFactory = new ManipulatorFactory();
            Robot manipulator = assembler.assembleRobot(manipulatorFactory, "Manipulator-M2");
            Console.WriteLine("");

            Console.WriteLine("Step 3: Creating Service Robot");
            RobotFactory serviceRobotFactory = new ServiceRobotFactory();
            Robot serviceRobot = assembler.assembleRobot(serviceRobotFactory, "ServiceBot-S3");
            Console.WriteLine("");
        }
    }

    class RobotAssembler
    {
        public Robot assembleRobot(RobotFactory factory, string robotName)
        {
            Console.WriteLine($"Початок збирання робота: {robotName}");
            
            Console.WriteLine("Створення сенсора...");
            AbstractSensor sensor = factory.CreateSensor();
            
            Console.WriteLine("Створення приводу...");
            AbstractActuator actuator = factory.CreateActuator();

            Console.WriteLine("Створення контролера...");
            AbstractController controller = factory.CreateController();

            Console.WriteLine("Калібрування системи...");
            sensor.calibrate();
            controller.initialize("default_config");

            Robot robot = new Robot(robotName, sensor, actuator, controller);
            Console.WriteLine($"Робота {robotName} успішно зібрано.");
            return robot;
        }
    }

    class Robot
    {
        private string name;
        private AbstractSensor sensor;
        private AbstractActuator actuator;
        private AbstractController controller;


        public Robot(string name, AbstractSensor sensor, AbstractActuator actuator, AbstractController controller)
        {
            this.name = name;
            this.sensor = sensor;
            this.actuator = actuator;
            this.controller = controller;
        }

        public string getName()
        {
            return name;
        }

        public AbstractSensor getSensor()
        {
            return sensor;
        }

        public AbstractActuator getActuator()
        {
            return actuator;
        }

        public AbstractController getController()
        {
            return controller;
        }

        public void setSensor(AbstractSensor newSensor)
        {
            sensor = newSensor;
        }

        public void setActuator(AbstractActuator newActuator)
        {
            actuator = newActuator;
        }

        public void setController(AbstractController newController)
        {
            controller = newController;
        }

        public bool performTask(string taskType)
        {
            Console.WriteLine($"Робот {name} виконує задачу: {taskType}");

            string data = sensor.readData();
            Console.WriteLine($"Отримано дані: {data}");

            string command = controller.process(taskType);
            Console.WriteLine($"Команда контролера: {command}");

            bool success = actuator.move(90.0f, 50.0f);
            if (success)
            {
                Console.WriteLine("Задачу виконано успішно.");
                return true;
            } 
            else
            {
                Console.WriteLine("Помилка виконання задачі.");
                return false;
            }
        }

        public void reset()
        {
            Console.WriteLine($"Скидання робота {name}....");
            sensor.reset();
            actuator.stop();
            controller.shutdown();
            Console.WriteLine("Робот скинуто.");
        }
    }
}