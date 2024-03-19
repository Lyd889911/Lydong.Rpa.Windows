using Lydong.Rpa.Windows;
using Lydong.Rpa.Windows.Bases.Images;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lydong.Rpa.Windows.Controllers
{
    public class ImageController
    {
        /// <summary>
        /// 截图
        /// </summary>
        /// <param name="rectangle"></param>
        public Bitmap Screenshot(ImageRectangle? rectangle=null)
        {
            if (rectangle == null)
            {
                int screenWidth = User32.GetSystemMetrics(0); // SM_CXSCREEN
                int screenHeight = User32.GetSystemMetrics(1); // SM_CYSCREEN
                rectangle = new(0,0, screenWidth, screenHeight,0);
            }

            Bitmap bitmap = new Bitmap(rectangle.Width, rectangle.Height);
            using Graphics g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(rectangle.X, rectangle.Y, 0, 0, new(rectangle.Width, rectangle.Height));

            bitmap.Save("source.jpg");

            return bitmap;
        }


        /// <summary>
        /// 图像定位<br/>
        /// PS:目标小图像，相比于原图，不能有任何缩放！！！目标图像再小，都不能放大了截图！！
        /// </summary>
        public ImageRectangle? LocateOnImage(Bitmap originalBitmap, string targetImgPath, double threshold=0.9)
        {
            using Bitmap targetBitmap = new(targetImgPath);
            using Mat originalMat = originalBitmap.ToMat();
            using Mat targetMat = targetBitmap.ToMat();//Cv2.ImRead(targetImgPath);


            //using Mat grayOriginalMat = originalMat.CvtColor(ColorConversionCodes.BGR2GRAY);
            //using Mat grayTargetMat = targetMat.CvtColor(ColorConversionCodes.BGR2GRAY);

            using Mat result = originalMat.MatchTemplate(targetMat, TemplateMatchModes.CCoeffNormed);

            result.MinMaxLoc(out _, out double maxVal, out _, out OpenCvSharp.Point maxLoc);

            int x = maxLoc.X;
            int y = maxLoc.Y;
            int w = targetBitmap.Width;
            int h = targetBitmap.Height;

            if (maxVal >= threshold)
            {
                // 创建矩形区域,从原始图像中提取匹配到的区域
                Rect matchRect = new Rect(x,y,w,h);
                Mat matchedRegion = originalMat[matchRect];
                var img = matchedRegion.ToBytes();

                return new(x,y,w,h, maxVal,img);
            }
            else
                return null;
        }

        public Bitmap ConvertToBitmap(byte[] data)
        {
            return new Bitmap(new MemoryStream(data));
        }
    }
}
