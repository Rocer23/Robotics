namespace Robotics
{
    // ConcreteProductB1
    public class BrushlessMotor : AbstractActuator
    {
        public override void move()
        {
            Console.WriteLine("Безщітковий двигун обертається");
        }
    }
}