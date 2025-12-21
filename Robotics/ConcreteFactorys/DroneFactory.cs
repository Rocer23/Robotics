namespace Robotics
{
    // CocnreteFactory1
    public class DroneFactory : RobotFactory
    {
        public override AbstractSensor CreateSensor()
        {
            return new AerialCamera("3840x2160");
        }

        public override AbstractActuator CreateActuator()
        {
            return new BrushlessMotor(1500);
        }

        public override AbstractController CreateController()
        {
            return new FlightController();
        }
    }
}