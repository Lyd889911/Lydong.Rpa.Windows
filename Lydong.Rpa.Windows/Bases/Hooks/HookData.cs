using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lydong.Rpa.Windows.Bases.Hooks
{
    public struct HookData
    {
        /// <summary>
        /// 键盘数据
        /// </summary>
        public KeyboardHookData Keyboard;
        /// <summary>
        /// 鼠标数据
        /// </summary>
        public MouseHookData Mouse;
    }
}
