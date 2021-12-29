using System;
using System.Threading;
using System.Threading.Tasks;
using MMALSharp;
using MMALSharp.Common;
using MMALSharp.Handlers;

namespace CatToyTestApp
{
    public class CameraTest
    {
        // Singleton initialized lazily. Reference once in your application.
        MMALCamera cam = MMALCamera.Instance;

        public async Task TakePicture()
        {
            using (var imgCaptureHandler = new ImageStreamCaptureHandler("/home/pi/images/", "jpg"))
            {
                await cam.TakePicture(imgCaptureHandler, MMALEncoding.JPEG, MMALEncoding.I420);
            }

            // Cleanup disposes all unmanaged resources and unloads Broadcom library. To be called when no more processing is to be done
            // on the camera.
            cam.Cleanup();
        }

        public async Task TakeVideo()
        {
            using (var vidCaptureHandler = new VideoStreamCaptureHandler("/home/pi/videos/", "avi"))
            {
                var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

                await cam.TakeVideo(vidCaptureHandler, cts.Token);
            }

            // Cleanup disposes all unmanaged resources and unloads Broadcom library. To be called when no more processing is to be done
            // on the camera.
            cam.Cleanup();
        }
    }
}
