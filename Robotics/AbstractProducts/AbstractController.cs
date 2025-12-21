namespace Robotics
{
    // AbstractProductC
    public abstract class AbstractController
    {
        public abstract string process(string command);
        public abstract bool initialize(string parameters);
        public abstract void shutdown();
        public abstract void updateParameters(string parameters);
        public abstract string diagnose();
        public abstract string getVersion();
    }    
}