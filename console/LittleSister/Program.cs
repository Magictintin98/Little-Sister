using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;

namespace LittleSister
{
    class Program
    {
        static void Main(string[] args)
        {
            VideoCapture videoCapture = new VideoCapture(0);
            videoCapture.Start();
            Console.WriteLine(videoCapture.CaptureSource);
            while (true)
            {
                videoCapture.ImageGrabbed += VideoCapture_ImageGrabbed;
                System.Threading.Thread.Sleep(5000);
            }
        }

        private static void VideoCapture_ImageGrabbed(object sender, EventArgs e)
        {
            Console.WriteLine("reussi");
            VideoCapture capture = (VideoCapture)sender;
            //capture.Grab();
            Mat image=new Mat();
            capture.Retrieve(image,0);
            image.Save("C:/Users/natha/OneDrive/Documents/test/img.png");
            Image img = Image.FromFile("C:/Users/natha/OneDrive/Documents/test/img.png");
            VisionAPI.MakeAnalysisRequest(img);
            System.Threading.Thread.Sleep(5000);
            img.Dispose();
            File.Delete("C:/Users/natha/OneDrive/Documents/test/img.png");
        }
    }
}
