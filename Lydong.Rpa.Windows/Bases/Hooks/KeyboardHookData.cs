using Lydong.Rpa.Windows.Bases.MouseAndKeyboards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lydong.Rpa.Windows.Bases.Hooks
{
    public struct KeyboardHookData
    {
        /// <summary>
        /// 键盘码1-254之间
        /// </summary>
        public int vkCode;
        /// <summary>
        /// 表示硬件扫描码
        /// </summary>
        public int scanCode;
        public int flags;
        public int time;
        public int dwExtraInfo;
        public Keys Key { get => (Keys)vkCode; }
    }
}
