namespace Robotics
{
    // ConcreteProductA3
    public class NavigationSensor : AbstractSensor
    {

        private bool gpsEnabled = true;
        private bool lidarEnabled = true;
        private bool isLocalized = false;
        private float positionX = 0.0f;
        private float positionY = 0.0f;

        public NavigationSensor(bool useGPS, bool useLidar)
        {
            gpsEnabled = useGPS;
            lidarEnabled = useLidar;
        }

        public override string readData()
        {
            if (gpsEnabled && lidarEnabled)
            {
                return $"Навігаційні дані: GPS і LIDAR, позиція [{positionX}, {positionY}]";
            } else if (gpsEnabled)
            {
                return $"Навігаційні дані: GPS, позиція [{positionX}, {positionY}]";
            } else
            {
                return $"Навігаційні дані: LIDAR, позиція [{positionX}, {positionY}]";
            }
        }

        public override bool calibrate()
        {
            Console.WriteLine("Калібрування навігаційних сенсорів...");

            if (gpsEnabled)
            {
                Console.WriteLine("Калібрування GPS...");
                Thread.Sleep(300);
            }
            if (lidarEnabled)
            {
                Console.WriteLine("Калібрування LIDAR...");
                Thread.Sleep(400);
            }

            Console.WriteLine("Калібрування завершено");
            return true;
        }

        public override float getAccuracy()
        {
            float accuracy = 0.90f;
            if (gpsEnabled)
            {
                accuracy += 0.05f;
            }
            if (lidarEnabled)
            {
                accuracy += 0.03f;
            }
            return accuracy;
        }

        public override bool isActive()
        {
            return gpsEnabled || lidarEnabled;
        }

        public override void reset()
        {
            Console.WriteLine("Скидання навігаційних сенсорів...");
            isLocalized = false;
            positionX = 0.0f;
            positionY = 0.0f;
            Thread.Sleep(200);
            Console.WriteLine("Сенсори скинуті");
        }

        public override void configure(string config)
        {
            Console.WriteLine($"Налаштування навігаційних сенсорів: {config}");

            if (config.Contains("gps="))
            {
                int startIndex = config.IndexOf("gpsValue=") + "gpsValue=".Length;
                int endIndex = config.IndexOf(";", startIndex);

                string gpsValue;

                if (endIndex == -1)
                {
                    gpsValue = config.Substring(startIndex);
                }
                else
                {
                    gpsValue = config.Substring(startIndex, endIndex - startIndex);
                }

                gpsEnabled = (gpsValue == "true");
            }

            if (config.Contains("lidar="))
            {
                int startIndex = config.IndexOf("lidarValue=") + "lidarValue=".Length;
                int endIndex = config.IndexOf(";", startIndex);

                string lidarValue;

                if (endIndex == -1)
                {
                    lidarValue = config.Substring(startIndex);
                }
                else
                {
                    lidarValue = config.Substring(startIndex, endIndex - startIndex);
                }

                lidarEnabled = (lidarValue == "true");
            }

            Console.WriteLine($"GPS: {gpsEnabled}, LIDAR: {lidarEnabled}");
        }
    }
}