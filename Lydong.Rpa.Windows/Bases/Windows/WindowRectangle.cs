using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lydong.Rpa.Windows.Bases.Windows
{
    /// <summary>
    /// 窗体矩阵
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct WindowRectangle
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
        public int X
        {
            get => Left;
            set
            {
                Right -= Left - value;
                Left = value;
            }
        }
        public int Y
        {
            get => Top;
            set
            {
                Bottom -= Top - value;
                Top = value;
            }
        }
        public int Height
        {
            get => Bottom - Top;
            set => Bottom = value + Top;
        }
        public int Width
        {
            get => Right - Left;
            set => Right = value + Left;
        }

        public bool IsEmpty => Left == 0 && Top == 0 && Right == 0 && Bottom == 0;
    }
}
