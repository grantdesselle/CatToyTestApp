using System;
using System.Threading;

namespace CatToyTestApp
{
    public class MotionDetectorTest
    {
        public MotionDetectorTest()
        {

        }

        public void DetectMotion()
        {
            using (Iot.Device.Hcsr501.Hcsr501 sensor =
            new Iot.Device.Hcsr501.Hcsr501(17))
            {
                while (true)
                {
                    if (sensor.IsMotionDetected)
                    {
                        Console.WriteLine("Motion Detected.");
                    }
                    else
                    {
                        Console.WriteLine("No motion detected.");
                    }

                    Thread.Sleep(1000);
                }
            }
        }
    }
}
