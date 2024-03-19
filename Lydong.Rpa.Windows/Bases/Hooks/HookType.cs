using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lydong.Rpa.Windows.Bases.Hooks
{
    public enum HookType
    {
        /// <summary>
        /// 可以截获整个系统所有模块的键盘事件
        /// </summary>
        Keyboard = 13,
        /// <summary>
        /// 可以截获整个系统所有模块的鼠标事件
        /// </summary>
        Mouse = 14,
        /// <summary>
        /// 键盘被按下
        /// </summary>
        KeyboardKeyDown = 0x100,
        /// <summary>
        /// 键盘被松开
        /// </summary>
        KeyboardKeyUp = 0x101,
        /// <summary>
        /// 键盘被按下，这个是系统键被按下，例如Alt等键
        /// </summary>
        KeyboardSysKeyDown = 0x104,
        /// <summary>
        /// 键盘被松开，这个是系统键被松开，例如Alt等键
        /// </summary>
        KeyboardSysKeyUp = 0x105,
        /// <summary>
        /// 鼠标移动
        /// </summary>
        MouseMove = 0x200,
        /// <summary>
        /// 鼠标左键按下
        /// </summary>
        MouseLeftButtonDown = 0x201,
        /// <summary>
        /// 鼠标右键按下
        /// </summary>
        MouseRgihtButtonDown = 0x204,
        /// <summary>
        /// 鼠标中键按下
        /// </summary>
        MouseMiddleButtonDown = 0x207,
        /// <summary>
        /// 鼠标左键抬起
        /// </summary>
        MouseLeftButtonUp = 0x202,
        /// <summary>
        /// 鼠标右键抬起
        /// </summary>
        MouseRgihtButtonUp = 0x205,
        /// <summary>
        /// 鼠标中键抬起
        /// </summary>
        MouseMiddleButtonUp = 0x208,

    }

}