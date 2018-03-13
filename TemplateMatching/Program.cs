using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenCvSharp;

namespace TemplateMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            var image = new Mat(@"lena.jpg");
            var template = new Mat(@"lena_face.jpg");

            var result = new Mat();
            Cv2.MatchTemplate(image, template, result, TemplateMatchModes.CCoeffNormed);
            Cv2.Threshold(result, result, 0.8, 1.0, ThresholdTypes.Binary);

            OpenCvSharp.Point minPoint;
            OpenCvSharp.Point maxPoint;
            Cv2.MinMaxLoc(result, out minPoint, out maxPoint);

            image.Rectangle(maxPoint, new OpenCvSharp.Point(maxPoint.X + template.Width, maxPoint.Y + template.Height), Scalar.Red);
            Cv2.ImShow("test", image);
            Cv2.WaitKey();
        }
    }
}
