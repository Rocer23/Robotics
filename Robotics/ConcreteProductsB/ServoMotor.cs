using System.Runtime.InteropServices;

namespace Robotics
{
    // ConcreteProductB2
    public class ServoMotor : AbstractActuator
    {
        
        private float position = 0.0f;
        private float speed = 0.0f;
        private float torque = 10.0f;

        private bool isPowered = false;

        public ServoMotor(float torque)
        {
            this.torque = torque;
        }

        public override bool move(float position, float speed)
        {
            
            if (!isPowered) 
            {
                Console.WriteLine("Помилка: сервомотор не підключено до живлення");
                return false;
            }

            Console.WriteLine("Рух сервомотора до позиції " + position + " зі швидкістю " + speed);
            this.position = position;
            this.speed = speed;
            Thread.Sleep(150);

            Console.WriteLine("Сервомото досяг позиції " + position);            
            return true;
        }

        public override void stop()
        {
            Console.WriteLine("Зупинка сервомотора");
            speed = 0.0f;
        }

        public override float getCurrentPosition()
        {
            return position;
        }

        public override float getCurrentSpeed()
        {
            return speed;
        }

        public override void setTorque(float torque)
        {
            this.torque = torque;
            Console.WriteLine($"Крутний момент сервомотора встаоновлено на {torque} N-m");
        }

        public override string getStatus()
        {
            return $"Сервомотор: позиція = {position}, швидкість = {speed} рад/с, крутний момент = {torque} N-m";
        }
    }
}