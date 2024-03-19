using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lydong.Rpa.Windows.Bases.Hooks
{
    public struct MouseHookData
    {
        /// <summary>
        /// 鼠标位置
        /// </summary>
        public Point pt;
        public int hWnd;
        public int wHitTestCode;
        public int dwExtraInfo;
    }
}
