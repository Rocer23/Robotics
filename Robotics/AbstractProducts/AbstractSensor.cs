namespace Robotics
{
    // AbstractProductA
    public abstract class AbstractSensor
    {
        public abstract string readData();
        public abstract bool calibrate();
        public abstract float getAccuracy();
        public abstract bool isActive();
        public abstract void reset();
        public abstract void configure(string config);
    }
}