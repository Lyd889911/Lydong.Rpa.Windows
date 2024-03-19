using Lydong.Rpa.Windows;
using Lydong.Rpa.Windows.Bases.MouseAndKeyboards;
using System.Runtime.InteropServices;
using System.Text;
using static Lydong.Rpa.Windows.Controllers.KeyboardController;

namespace Lydong.Rpa.Windows.Controllers
{
    public class KeyboardController
    {
        /// <summary>
        /// 键盘键按下
        /// </summary>
        /// <param name="Key"></param>
        public void KeyDown(Keys key)
        {
            var inputs = new InputBuilder().AddKeyDown(key).ToArray();
            User32.SendInput((uint)inputs.Length, inputs, Input.Size);
        }

        /// <summary>
        /// 键盘键抬起
        /// </summary>
        /// <param name="key"></param>
        public void KeyUp(Keys key)
        {
            var inputs = new InputBuilder().AddKeyUp(key).ToArray();
            User32.SendInput((uint)inputs.Length, inputs, Input.Size);
        }

        /// <summary>
        /// 键盘按键
        /// </summary>
        /// <param name="key"></param>
        public void Press(Keys key)
        {
            var inputs = new InputBuilder().AddKeyDown(key).AddKeyUp(key).ToArray();
            User32.SendInput((uint)inputs.Length, inputs, Input.Size);
        }

        /// <summary>
        /// 键盘写入文本
        /// </summary>
        /// <param name="s"></param>
        public void Write(string s)
        {
            var inputs = new InputBuilder().AddCharactersWrite(s).ToArray();
            User32.SendInput((uint)inputs.Length, inputs, Input.Size);
        }

        /// <summary>
        /// 组合热键
        /// </summary>
        /// <param name="keys"></param>
        public void HotKey(params Keys[] keys)
        {
            foreach (var key in keys)
            {
                KeyDown(key);
            }
            for (int i = keys.Length - 1; i >= 0; i--)
            {
                var key = keys[i];
                KeyUp(key);
            }
        }

    }
}