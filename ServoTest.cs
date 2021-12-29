using System;
using Iot.Device.ServoMotor;
using System.Device.Pwm;

namespace CatToyTestApp
{
    public class ServoTest
    {
        PwmChannel pwmChannel { get; set; }
        ServoMotor servoMotor { get; set; }

        public void TestMotor()
        {
            servoMotor.Start();
            TestLoop();

            void TestLoop()
            {
                Console.WriteLine("Enter a pulse width in microseconds. To return to the menu, type 'menu' ");

                string pulse = Console.ReadLine();

                if(pulse == "menu")
                {
                    Console.WriteLine("Return to the main menu");
                } else
                {
                    servoMotor.WritePulseWidth(System.Convert.ToInt32(pulse));
                    TestLoop();
                }                
            }
        }

        public ServoTest()
        {
            pwmChannel = PwmChannel.Create(0, 0, 50);
            servoMotor = new ServoMotor(pwmChannel, 160, 700, 2200);
        }
    }

}
