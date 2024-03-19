using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lydong.Rpa.Windows.Bases.Images
{
    public static class ImageExtensions
    {
        public static Mat ToMat(this Bitmap bitmap)
        {
            using MemoryStream memSteam = new MemoryStream();
            bitmap.Save(memSteam, ImageFormat.Bmp);
            memSteam.Position = 0;
            byte[] data = memSteam.ToArray();
            return Cv2.ImDecode(data, ImreadModes.Unchanged);
        }
    }
}
