namespace Robotics
{
    // ConcreteFactory2
    public class ManipulatorFactory : RobotFactory
    {
        public override AbstractSensor CreateSensor()
        {
            return new ForceSensor();
        }

        public override AbstractActuator CreateActuator()
        {
            return new ServoMotor();
        }

        public override AbstractController CreateController()
        {
            return new KinematicController();
        }
    }
}