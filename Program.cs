using System;
using System.Threading.Tasks;

namespace CatToyTestApp
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to the Cat Toy Test App.");
            
            await ChooseLoop();
            
            async Task ChooseLoop()
            {
                switch (ChooseTestType())
                {
                    case 1:
                        Console.WriteLine("start picture test");
                        CameraTest picTest = new CameraTest();
                        Task myPic = picTest.TakePicture();
                        await myPic;
                        break;
                    case 2:
                        Console.WriteLine("start video test");
                        CameraTest vidTest = new CameraTest();
                        Task myVid = vidTest.TakeVideo();
                        await myVid;
                        break;
                    case 3:
                        Console.WriteLine("start motion detector test");
                        MotionDetectorTest motionDetectorTest = new MotionDetectorTest();
                        break;
                    case 4:
                        Console.WriteLine("start servo test");
                        ServoTest servoTest = new ServoTest();
                        servoTest.TestMotor();
                        break;
                    default:
                        break;
                }
                await ChooseLoop();
            }
            int ChooseTestType()
            {
                Console.WriteLine("What Would You Like to Test?");
                Console.WriteLine("1. Picture, 2. Video, 3. Motion Detector, 4. Servo");
                var userInput = Console.ReadLine();

                return System.Convert.ToInt32(userInput);
            }
        }
    }
}
