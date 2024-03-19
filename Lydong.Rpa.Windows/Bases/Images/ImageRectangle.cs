using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Point = Lydong.Rpa.Windows.Bases.MouseAndKeyboards.Point;

namespace Lydong.Rpa.Windows.Bases.Images
{
    public class ImageRectangle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        /// <summary>
        /// 相似度
        /// </summary>
        public double Similarity { get; set; }
        /// <summary>
        /// 图像数据
        /// </summary>
        public byte[] Image { get; set; }


        public ImageRectangle(int x, int y, int width, int height, double similarity, byte[] image)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Similarity = similarity;
            Image = image;
        }
        public ImageRectangle(int x, int y, int width, int height, double similarity)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Similarity = similarity;
        }
        public ImageRectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }


        /// <summary>
        /// 该图像在屏幕中心的点
        /// </summary>
        public Point Center
        {
            get
            {
                int centerX = X + Width / 2;
                int centerY = Y + Height / 2;
                return new Point() { X = centerX, Y = centerY };
            }
        }
    }
}
