namespace Robotics
{
    // ConcreteProductC2
    public class KinematicController : AbstractController
    {
        private int dof = 6;
        private int[] jointAngles = [0, 0, 0, 0, 0, 0]; 
        private bool isHomed = false;

        public KinematicController(int degreesOfFreedom)
        {
            dof = degreesOfFreedom;
        }

        public override string process(string command)
        {
            int[] angles = command.Split(" ").Select(int.Parse).ToArray();

            if (angles.Length != dof)
            {
                return "Помилка: невірна кількість кутів";
            }

            jointAngles = angles;
            return $"Кути з'єднань: {string.Join(", ", jointAngles)}";
        }

        public override bool initialize(string parameters)
        {
            Console.WriteLine("Ініціалізація контролера кінематики...");

            Thread.Sleep(150);

            Console.WriteLine("Контролер готовий до роботи.");
            return true;
        }

        public override void shutdown()
        {
            Console.WriteLine("Вимкнення контролера кінематики");
            isHomed = false;
        }

        public override void updateParameters(string parameters)
        {
            Console.WriteLine($"Оновлення параметрів: {parameters}");
        }

        public override string diagnose()
        {
            return $"Контролер кінематики: ступенів свободи = {dof}, занульвано = {isHomed}";
        }

        public override string getVersion()
        {
            return "KinematicsController v1.3";
        }
    }
}