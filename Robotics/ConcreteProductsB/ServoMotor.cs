namespace Robotics
{
    // ConcreteProductB2
    public class ServoMotor : AbstractActuator
    {
        public override void move()
        {
            Console.WriteLine("Сервомотор позиціонується");
        }
    }
}