namespace Robotics
{
    // AbstractProductB
    public abstract class AbstractActuator
    {
        public abstract bool move(float position, float speed);
        public abstract void stop();
        public abstract float getCurrentPosition();
        public abstract float getCurrentSpeed();
        public abstract void setTorque(float torque);
        public abstract string getStatus();
    }
}