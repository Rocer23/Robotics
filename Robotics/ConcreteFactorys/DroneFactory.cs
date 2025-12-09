namespace Robotics
{
    // CocnreteFactory1
    public class DroneFactory : RobotFactory
    {
        public override AbstractSensor CreateSensor()
        {
            return new AerialCamera();
        }
        
        public override AbstractActuator CreateActuator()
        {
            return new BrushlessMotor();
        }

        public override AbstractController CreateController()
        {
            return new FlightController();
        }

        
    }
}