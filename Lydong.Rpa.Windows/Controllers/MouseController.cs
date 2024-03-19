using Lydong.Rpa.Windows;
using Lydong.Rpa.Windows.Bases.MouseAndKeyboards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lydong.Rpa.Windows.Controllers
{
    public class MouseController
    {
        /// <summary>
        /// 鼠标点击
        /// </summary>
        public void Click(MouseButtonType button = MouseButtonType.Left, int x = 0, int y = 0)
        {
            MoveTo(x, y);
            var inputs = new InputBuilder().AddMouseButtonDown(button).AddMouseButtonUp(button).ToArray();
            User32.SendInput((uint)inputs.Length, inputs, Input.Size);
        }
        /// <summary>
        /// 鼠标按下
        /// </summary>
        public void MouseDown(MouseButtonType button = MouseButtonType.Left, int x = 0, int y = 0)
        {
            MoveTo(x, y);

            var inputs = new InputBuilder().AddMouseButtonDown(button).ToArray();
            User32.SendInput((uint)inputs.Length, inputs, Input.Size);
        }
        /// <summary>
        /// 鼠标抬起
        /// </summary>
        public void MouseUp(MouseButtonType button = MouseButtonType.Left, int x = 0, int y = 0)
        {
            MoveTo(x, y);

            var inputs = new InputBuilder().AddMouseButtonUp(button).ToArray();
            User32.SendInput((uint)inputs.Length, inputs, Input.Size);
        }
        /// <summary>
        /// 移动鼠标到xy坐标，绝对位置
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MoveTo(int x, int y)
        {
            //xy不为0就移动鼠标到这个位置
            if (x != 0 || y != 0)
                User32.SetCursorPos(x, y);
        }
        /// <summary>
        /// 从当前位置移动鼠标，相对位置
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Move(int x,int y)
        {
            var inputs = new InputBuilder().AddRelativeMouseMovement(x,y).ToArray();
            User32.SendInput((uint)inputs.Length, inputs, Input.Size);
        }
        /// <summary>
        /// 当前鼠标位置
        /// </summary>
        public Point Position()
        {
            User32.GetCursorPos(out Point lpPoint);
            return lpPoint;
        }
        /// <summary>
        /// 滚轮滚动
        /// </summary>
        /// <param name="value">z正数向前滚动，负数向人滚动</param>
        public void Scroll(int value)
        {
            //mouse_event(MouseFlags.Wheel, 0, 0, value, 0);
            
            var inputs = new InputBuilder().AddMouseWheelScroll(value).ToArray();
            User32.SendInput((uint)inputs.Length, inputs, Input.Size);
        }




        private class MouseFlags
        {
            /// <summary>
            /// 移动鼠标 
            /// </summary>
            internal const int Move = 0x0001;
            /// <summary>
            /// 鼠标左键按下 
            /// </summary>
            internal const int LeftDown = 0x0002;
            /// <summary>
            /// 鼠标左键抬起 
            /// </summary>
            internal const int LeftUp = 0x0004;
            /// <summary>
            /// 鼠标右键按下 
            /// </summary>
            internal const int RightDown = 0x0008;
            /// <summary>
            /// 鼠标右键抬起 
            /// </summary>
            internal const int RightUp = 0x0010;
            /// <summary>
            /// 鼠标中键按下
            /// </summary>
            internal const int MiddleDown = 0x0020;
            /// <summary>
            /// 鼠标中键抬起
            /// </summary>
            internal const int MiddleUp = 0x0040;
            /// <summary>
            /// 是否采用绝对坐标
            /// </summary>
            internal const int Absolute = 0x8000;
            /// <summary>
            /// 鼠标滚轮滚动操作，必须配合dwData参数
            /// </summary>
            internal const int Wheel = 0x0800;
        }
    }


}
