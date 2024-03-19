using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lydong.Rpa.Windows.Bases.Windows
{
    internal enum WindowShowStyle
    {
        /// <summary>
        /// 隐藏窗口并激活其他窗口
        /// </summary>
        Hide = 0,
        /// <summary>
        /// 以普通大小和位置显示窗口。首次显示时，通常窗口处于此状态。
        /// </summary>
        Normal = 1,
        /// <summary>
        /// 以最小化的形式显示窗口，窗口未激活。
        /// </summary>
        Minimized = 2,
        /// <summary>
        /// 以最大化的形式显示窗口。
        /// </summary>
        Maximized = 3,
        /// <summary>
        /// 以当前大小和位置显示窗口，但不激活该窗口。
        /// </summary>
        ShowNoActivate = 4,
        /// <summary>
        /// 激活并以当前大小和位置显示窗口。
        /// </summary>
        Show = 5,
        /// <summary>
        /// 最小化指定的窗口，并激活下一个顶级窗口。
        /// </summary>
        Minimize = 6,
        /// <summary>
        /// 以最小化的形式显示窗口，但不激活该窗口。
        /// </summary>
        ShowMinNoActive = 7,
        /// <summary>
        /// 激活并以当前大小和位置显示窗口。但不将其设置为最顶层窗口。
        /// </summary>
        ShowNA = 8,
        /// <summary>
        /// 与ShowDefault相同
        /// </summary>
        Restore = 9,
        /// <summary>
        /// 用窗口的默认大小和位置显示窗口。此值与Normal相同。
        /// </summary>
        ShowDefault = 10,
        /// <summary>
        /// 最小化指定的窗口，即使线程不拥有该窗口也是如此。
        /// </summary>
        ForceMinimize = 11
    }
}
