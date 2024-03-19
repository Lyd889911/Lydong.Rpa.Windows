using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lydong.Rpa.Windows.Bases.MouseAndKeyboards
{
    internal struct Input
    {
        [StructLayout(LayoutKind.Explicit)]
        internal struct UNION
        {
            [FieldOffset(0)]
            public MOUSEINPUT mi;

            [FieldOffset(0)]
            public KEYBDINPUT ki;

            [FieldOffset(0)]
            public HARDWAREINPUT hi;
        }

        internal INPUTTYPE type;

        internal UNION union;

        /// <summary>
        /// 鼠标
        /// </summary>
        internal MOUSEINPUT mi
        {
            get
            {
                return union.mi;
            }
            set
            {
                union.mi = value;
            }
        }
        /// <summary>
        /// 键盘
        /// </summary>
        internal KEYBDINPUT ki
        {
            get
            {
                return union.ki;
            }
            set
            {
                union.ki = value;
            }
        }
        /// <summary>
        /// 硬件
        /// </summary>
        internal HARDWAREINPUT hi
        {
            get
            {
                return union.hi;
            }
            set
            {
                union.hi = value;
            }
        }

        /// <summary>
        /// 大小
        /// </summary>
        internal static int Size
        {
            get => Marshal.SizeOf(typeof(Input));
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct MOUSEINPUT
    {
        public int dx;
        public int dy;
        public int mouseData;
        public MOUSEEVENTF dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }
    [StructLayout(LayoutKind.Sequential)]
    internal struct KEYBDINPUT
    {
        public ushort wVk;
        public ushort wScan;
        public KEYEVENTF dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }
    [StructLayout(LayoutKind.Sequential)]
    internal struct HARDWAREINPUT
    {
        public uint uMsg;
        public ushort wParamL;
        public ushort wParamH;
    }


    internal enum MOUSEEVENTF
    {
        /// <summary>
        /// dx 和 dy 成员包含规范化的绝对坐标。 如果未设置标志， dx和 dy 包含相对数据 (自上次报告的位置) 更改。 无论哪种类型的鼠标或其他指针设备（如果有）连接到系统，都可以设置或不设置此标志
        /// </summary>
        MOUSEEVENTF_ABSOLUTE = 0x8000,

        /// <summary>
        /// 鼠标左键按下 
        /// </summary>
        MOUSEEVENTF_LEFTDOWN = 0x0002,

        /// <summary>
        /// 鼠标左键抬起
        /// </summary>
        MOUSEEVENTF_LEFTUP = 0x0004,

        /// <summary>
        /// 鼠标中键按下
        /// </summary>
        MOUSEEVENTF_MIDDLEDOWN = 0x0020,

        /// <summary>
        /// 鼠标中键抬起
        /// </summary>
        MOUSEEVENTF_MIDDLEUP = 0x0040,

        /// <summary>
        /// 移动鼠标
        /// </summary>
        MOUSEEVENTF_MOVE = 0x0001,

        /// <summary>
        /// 鼠标右键按下
        /// </summary>
        MOUSEEVENTF_RIGHTDOWN = 0x0008,

        /// <summary>
        /// 鼠标右键抬起
        /// </summary>
        MOUSEEVENTF_RIGHTUP = 0x0010,

        /// <summary>
        /// 鼠标滚轮滚动操作，必须配合mouseData参数
        /// </summary>
        MOUSEEVENTF_WHEEL = 0x0800,

        /// <summary>
        /// X键按下
        /// </summary>
        MOUSEEVENTF_XDOWN = 0x0080,

        /// <summary>
        /// X键抬起
        /// </summary>
        MOUSEEVENTF_XUP = 0x0100,

        /// <summary>
        /// 水平滚轮
        /// </summary>
        MOUSEEVENTF_HWHEEL = 0x01000,

        /// <summary>
        /// 不合并鼠标移动，默认是合并
        /// </summary>
        MOUSEEVENTF_MOVE_NOCOALESCE = 0x2000,

        /// <summary>
        /// 将坐标映射到整个桌面。 必须与 MOUSEEVENTF_ABSOLUTE 一起使用。
        /// </summary>
        MOUSEEVENTF_VIRTUALDESK = 0x4000,
    }
    internal enum KEYEVENTF
    {
        /// <summary>
        /// 如果指定， 则 wScan 扫描代码由两个字节组成的序列组成，其中第一个字节的值为 0xE0(224)
        /// </summary>
        KEYEVENTF_EXTENDEDKEY = 0x0001,

        /// <summary>
        /// 如果指定，则抬起键。 如果未指定，则按键。
        /// </summary>
        KEYEVENTF_KEYUP = 0x0002,

        /// <summary>
        ///如果指定，系统会合成 VK_PACKET 击键。 wVk 参数必须为零。 此标志只能与 KEYEVENTF_KEYUP 标志组合使用。 有关详细信息，请参见“备注”部分。
        /// </summary>
        KEYEVENTF_UNICODE = 0x0004,

        /// <summary>
        /// 如果指定， wScan 将标识键，并忽略 wVk 。
        /// </summary>
        KEYEVENTF_SCANCODE = 0x0008,
    }
    internal enum INPUTTYPE
    {
        /// <summary>
        /// 鼠标
        /// </summary>
        INPUT_MOUSE = 0,

        /// <summary>
        /// 键盘
        /// </summary>
        INPUT_KEYBOARD = 1,

        /// <summary>
        /// 硬件
        /// </summary>
        INPUT_HARDWARE = 2,
    }

}
