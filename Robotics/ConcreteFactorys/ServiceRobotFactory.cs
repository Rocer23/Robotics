namespace Robotics
{
    // ConcreteFactory3
    public class ServiceRobotFactory : RobotFactory
    {
        public override AbstractSensor CreateSensor()
        {
            return new NavigationSensor();
        }

        public override AbstractActuator CreateActuator()
        {
            return new WheelMotor();
        }

        public override AbstractController CreateController()
        {
            return new MobilityController();
        }
    }
}