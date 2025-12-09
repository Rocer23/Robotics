namespace Robotics
{
    // AbstractFactory
    public abstract class RobotFactory
    {
        public abstract AbstractSensor CreateSensor();
        public abstract AbstractActuator CreateActuator();
        public abstract AbstractController CreateController();
    }
}