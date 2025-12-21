using System.Runtime.InteropServices;

namespace Robotics
{
    // ConcreteProductB3
    public class WheelMotor : AbstractActuator
    {

        private float rotation = 0.0f;
        private float speed = 0.0f;
        private float wheelDiameter = 0.3f;
        private float distanceTraveled = 0.0f;

        public WheelMotor(float diameter)
        {
            wheelDiameter = diameter;
        }
        
        public override bool move(float distance, float speed)
        {
            Console.WriteLine($"Рух мотор-колеса на відстань {distance} м зі швидкістю {speed} м/с");

            this.speed = speed;
            float rotationNeeded = (float)(distance / (Math.PI * wheelDiameter));

            for (float i = 1; i <= rotationNeeded; i += 0.1f)
            {
                rotation += 0.1f;
                distanceTraveled = (float)(rotation * (Math.PI * wheelDiameter));
                Thread.Sleep(50);
            }

            speed = 0.0f;
            Console.WriteLine($"Пройдено відстань {distanceTraveled} м");
            return true;
        }

        public override void stop()
        {
            Console.WriteLine("Зупинука мотор-колеса");
            speed = 0.0f;
        }

        public override float getCurrentPosition()
        {
            return distanceTraveled;
        }

        public override float getCurrentSpeed()
        {
            return speed;
        }

        public override void setTorque(float torque)
        {
            Console.WriteLine($"Обмеження крутного моменту встановлено на {torque} N-m");
        }

        public override string getStatus()
        {
            return $"Мотор-колесо: пройдено = {distanceTraveled} м, швидкість = {speed} м/с, діаметр колеса = {wheelDiameter} м";
        }
    }
}