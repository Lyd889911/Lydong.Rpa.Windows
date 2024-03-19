using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lydong.Rpa.Windows;

namespace Lydong.Rpa.Windows.Bases.Windows
{
    public class Window
    {
        /// <summary>
        /// 窗口的句柄id
        /// </summary>
        public IntPtr Id { get; set; }


        /// <summary>
        /// 窗体的标题
        /// </summary>
        public string Title
        {
            get
            {
                StringBuilder sb = new StringBuilder(1024);
                User32.GetWindowText(Id, sb, sb.Capacity);
                return sb.ToString();
            }
        }


        /// <summary>
        /// 得到窗体矩形
        /// </summary>
        public WindowRectangle Rectangle
        {
            get
            {
                User32.GetWindowRect(Id, out WindowRectangle rect);
                return rect;
            }
        }

        /// <summary>
        /// 是否可见
        /// </summary>
        public bool IsVisible
        {
            get
            {
                return User32.IsWindowVisible(Id);
            }
        }


        /// <summary>
        /// 激活窗体
        /// </summary>
        public void Activate()
        {
            if (User32.IsIconic(Id))
            {
                User32.ShowWindow(Id, WindowShowStyle.Normal);
            }
            User32.SetForegroundWindow(Id);
        }


        /// <summary>
        /// 最大化窗体
        /// </summary>
        public void Maximize()
        {
            User32.ShowWindow(Id, WindowShowStyle.Maximized);
        }


        /// <summary>
        /// 最小化窗体
        /// </summary>
        public void Minimize()
        {
            User32.ShowWindow(Id, WindowShowStyle.Minimized);
        }

        /// <summary>
        /// 设置窗口位置和大小
        /// </summary>
        public void SetPosition(int x, int y)
        {
            var height = Rectangle.Height;
            var width = Rectangle.Width;
            User32.SetWindowPos(Id, IntPtr.Zero, x, y, width, height, 0);
        }

        /// <summary>
        /// 设置窗体大小
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetSize(int width, int height)
        {
            var x = Rectangle.X;
            var y = Rectangle.Y;
            User32.SetWindowPos(Id, IntPtr.Zero, x, y, width, height, 0);
        }
    }
}
