namespace Robotics
{
    // ConcreteProductB3
    public class WheelMotor : AbstractActuator
    {
        public override void move()
        {
            Console.WriteLine("Мотор-колесо котиться");
        }
    }
}