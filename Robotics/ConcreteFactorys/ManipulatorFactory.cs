namespace Robotics
{
    // ConcreteFactory2
    public class ManipulatorFactory : RobotFactory
    {
        public override AbstractSensor CreateSensor()
        {
            return new ForceSensor(200.0f);
        }

        public override AbstractActuator CreateActuator()
        {
            return new ServoMotor(15.0f);
        }

        public override AbstractController CreateController()
        {
            return new KinematicController(6);
        }
    }
}