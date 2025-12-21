namespace Robotics
{
    // ConcreteFactory3
    public class ServiceRobotFactory : RobotFactory
    {
        public override AbstractSensor CreateSensor()
        {
            return new NavigationSensor(true, true);
        }

        public override AbstractActuator CreateActuator()
        {
            return new WheelMotor(10.0f);
        }

        public override AbstractController CreateController()
        {
            return new MobilityController();
        }
    }
}