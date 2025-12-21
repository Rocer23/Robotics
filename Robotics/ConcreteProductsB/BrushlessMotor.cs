namespace Robotics
{
    // ConcreteProductB1
    public class BrushlessMotor : AbstractActuator
    {
        private float currentPosition = 0.0f;
        private float currentSpeed = 0.0f;
        private float maxTorque = 10.0f;

        private float temperature = 25.0f;

        public BrushlessMotor(float maxTorque)
        {
            this.maxTorque = maxTorque;
        }

        public override bool move(float position, float speed)
        {
            Console.WriteLine("Рух безщіткового двигуна до позиції " + position + " зі швидкістю " + speed);
            if (speed > 5000.0f) 
            {
                Console.WriteLine("Помилка: занадто висока швидкість");
                return false;
            }

            currentPosition = position;
            currentSpeed = speed;
            temperature += 5.0f;
            Thread.Sleep(100);

            Console.WriteLine("вигун досяг позиції " + position);
            return true;
        }

        public override void stop()
        {
            Console.WriteLine("Зупинка безщіткового двигуна");
            currentSpeed = 0.0f;
            temperature -= 2.0f;

        }

        public override float getCurrentPosition()
        {
            return currentPosition;
        }

        public override float getCurrentSpeed()
        {
            return currentSpeed;
        }

        public override void setTorque(float torque)
        {
            if (torque > 0.0f && torque <= maxTorque)
            {
                maxTorque = torque;
                Console.WriteLine("Обмеження крутного моменту встановлено на " + torque + " N·m");
            }
            else
            {
                Console.WriteLine("Помилка: недійсне значення крутного моменту");
            }
        }

        public override string getStatus()
        {
            return "Безщітковий двигун: позиція=" + currentPosition + ", швидкість=" + currentSpeed + ", температура=" + temperature + "°C";
        }
    }
}