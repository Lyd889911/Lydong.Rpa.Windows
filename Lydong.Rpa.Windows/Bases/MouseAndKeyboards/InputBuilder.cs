using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lydong.Rpa.Windows.Controllers.MouseController;

namespace Lydong.Rpa.Windows.Bases.MouseAndKeyboards
{
    internal class InputBuilder
    {
        /// <summary>
        /// 输入结构体列表
        /// </summary>
        private readonly List<Input> inputList = new List<Input>();
        public Input[] ToArray() => inputList.ToArray();


        /// <summary>
        /// 添加键盘按下事件
        /// </summary>
        internal InputBuilder AddKeyDown(Keys key)
        {
            var down = new Input
            {
                type = INPUTTYPE.INPUT_KEYBOARD,
                ki = new KEYBDINPUT
                {
                    wVk = (ushort)key,
                    wScan = 0,
                    dwFlags = 0,
                    time = 0,
                    dwExtraInfo = IntPtr.Zero
                }
            };
            inputList.Add(down);
            return this;
        }

        /// <summary>
        /// 添加键盘抬起事件
        /// </summary>
        internal InputBuilder AddKeyUp(Keys key)
        {

            var up = new Input
            {
                type = INPUTTYPE.INPUT_KEYBOARD,
                ki = new KEYBDINPUT
                {
                    wVk = (ushort)key,
                    wScan = 0,
                    dwFlags = KEYEVENTF.KEYEVENTF_KEYUP,
                    time = 0,
                    dwExtraInfo = IntPtr.Zero
                }
            };

            inputList.Add(up);
            return this;
        }

        /// <summary>
        /// 添加写入
        /// </summary>
        internal InputBuilder AddCharactersWrite(string value)
        {
            foreach (var c in value)
            {
                var input = new Input
                {
                    type = INPUTTYPE.INPUT_KEYBOARD,
                    ki = new KEYBDINPUT
                    {
                        wVk = 0,
                        wScan = c,
                        dwFlags = KEYEVENTF.KEYEVENTF_UNICODE,
                        time = 0,
                        dwExtraInfo = IntPtr.Zero
                    }
                };
                inputList.Add(input);
            }
            return this;

        }

        /// <summary>
        /// 添加相对于当前位置的鼠标移动事件
        /// </summary>
        internal InputBuilder AddRelativeMouseMovement(int x, int y)
        {
            MOUSEINPUT mi = new MOUSEINPUT
            {
                dwFlags = MOUSEEVENTF.MOUSEEVENTF_MOVE,
                dx = x,
                dy = y
            };
            var movement = new Input { type = INPUTTYPE.INPUT_MOUSE, mi = mi };
            inputList.Add(movement);
            return this;
        }

        /// <summary>
        /// 添加鼠标按下事件
        /// </summary>
        internal InputBuilder AddMouseButtonDown(MouseButtonType button)
        {
            var flags = ToMouseButtonDownFlag(button);
            var buttonDown = new Input { type = INPUTTYPE.INPUT_MOUSE, mi = new MOUSEINPUT { dwFlags = flags } };
            inputList.Add(buttonDown);
            return this;
        }

        /// <summary>
        /// 添加鼠标抬起事件
        /// </summary>
        internal InputBuilder AddMouseButtonUp(MouseButtonType button)
        {
            var flags = ToMouseButtonUpFlag(button);
            var buttonUp = new Input
            {
                type = INPUTTYPE.INPUT_MOUSE,
                mi = new MOUSEINPUT
                {
                    dwFlags = flags
                }
            };
            inputList.Add(buttonUp);
            return this;
        }

        /// <summary>
        /// 添加鼠标滚轮事件
        /// </summary>
        internal InputBuilder AddMouseWheelScroll(int scrollAmount)
        {
            MOUSEINPUT mi = new MOUSEINPUT
            {
                dwFlags = MOUSEEVENTF.MOUSEEVENTF_WHEEL,
                mouseData = scrollAmount,
            };
            var scroll = new Input { type = INPUTTYPE.INPUT_MOUSE, mi = mi };
            inputList.Add(scroll);
            return this;
        }


        internal static MOUSEEVENTF ToMouseButtonDownFlag(MouseButtonType button)
        {
            switch (button)
            {
                case MouseButtonType.Left:
                    return MOUSEEVENTF.MOUSEEVENTF_LEFTDOWN;

                case MouseButtonType.Middle:
                    return MOUSEEVENTF.MOUSEEVENTF_MIDDLEDOWN;

                case MouseButtonType.Right:
                    return MOUSEEVENTF.MOUSEEVENTF_RIGHTDOWN;

                default:
                    throw new ArgumentException(nameof(button));
            }
        }

        internal static MOUSEEVENTF ToMouseButtonUpFlag(MouseButtonType button)
        {
            switch (button)
            {
                case MouseButtonType.Left:
                    return MOUSEEVENTF.MOUSEEVENTF_LEFTUP;

                case MouseButtonType.Middle:
                    return MOUSEEVENTF.MOUSEEVENTF_MIDDLEUP;

                case MouseButtonType.Right:
                    return MOUSEEVENTF.MOUSEEVENTF_RIGHTUP;

                default:
                    throw new ArgumentException(nameof(button));
            }
        }

    }
}
