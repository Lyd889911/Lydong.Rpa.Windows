using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lydong.Rpa.Windows.Bases.MouseAndKeyboards
{

    public enum Keys
    {
        /// <summary>
        /// 鼠标左键
        /// </summary>
        MouseLeftButton = 0x01,

        /// <summary>
        /// 鼠标右键
        /// </summary>
        MouseRightButton = 0x02,

        /// <summary>
        /// 控制中断处理
        /// </summary>
        Cancel = 0x03,

        /// <summary>
        /// 鼠标中键
        /// </summary>
        MouseMiddleButton = 0x04,

        /// <summary>
        /// X1 鼠标按钮
        /// </summary>
        X1MouseButton = 0x05,

        /// <summary>
        /// X2 鼠标按钮
        /// </summary>
        X2MouseButton = 0x06,

        /// <summary>
        /// BACKSPACE 键（退格）
        /// </summary>
        Back = 0x08,

        /// <summary>
        /// Tab 键
        /// </summary>
        Tab = 0x09,

        /// <summary>
        /// Enter 键
        /// </summary>
        Enter = 0x0D,

        /// <summary>
        /// Shift 键
        /// </summary>
        Shift = 0x10,

        /// <summary>
        /// Ctrl 键
        /// </summary>
        Ctrl = 0x11,

        /// <summary>
        /// ALT 键
        /// </summary>
        Alt = 0x12,

        /// <summary>
        /// Pause 键
        /// </summary>
        Pause = 0x13,

        /// <summary>
        /// CapsLock 键（大写锁定）
        /// </summary>
        CapsLock = 0x14,

        /// <summary>
        /// ESC 键
        /// </summary>
        Esc = 0x1B,

        /// <summary>
        /// 空格键
        /// </summary>
        Space = 0x20,

        /// <summary>
        /// PageUp 键
        /// </summary>
        PageUp = 0x21,

        /// <summary>
        /// PageDown 键
        /// </summary>
        PageDown = 0x22,

        /// <summary>
        /// End 键
        /// </summary>
        End = 0x23,

        /// <summary>
        /// Home 键
        /// </summary>
        Home = 0x24,

        /// <summary>
        /// 左方向键
        /// </summary>
        Left = 0x25,

        /// <summary>
        /// 上方向键
        /// </summary>
        Up = 0x26,

        /// <summary>
        /// 右方向键
        /// </summary>
        Right = 0x27,

        /// <summary>
        /// 下方向键
        /// </summary>
        Down = 0x28,

        /// <summary>
        /// Select 键
        /// </summary>
        Select = 0x29,

        /// <summary>
        /// Print 键
        /// </summary>
        Print = 0x2A,

        /// <summary>
        /// Execute 键
        /// </summary>
        Execute = 0x2B,

        /// <summary>
        /// PrintScreen 键
        /// </summary>
        PrintScreen = 0x2C,

        /// <summary>
        /// Insert 键
        /// </summary>
        Insert = 0x2D,

        /// <summary>
        /// Delete 键
        /// </summary>
        Delete = 0x2E,

        /// <summary>
        /// Help 键
        /// </summary>
        Help = 0x2F,

        /// <summary>
        /// 0 键
        /// </summary>
        _0 = 0x30,

        /// <summary>
        /// 1 键
        /// </summary>
        _1 = 0x31,

        /// <summary>
        /// 2 键
        /// </summary>
        _2 = 0x32,

        /// <summary>
        /// 3 键
        /// </summary>
        _3 = 0x33,

        /// <summary>
        /// 4 键
        /// </summary>
        _4 = 0x34,

        /// <summary>
        /// 5 键
        /// </summary>
        _5 = 0x35,

        /// <summary>
        /// 6 键
        /// </summary>
        _6 = 0x36,

        /// <summary>
        /// 7 键
        /// </summary>
        _7 = 0x37,

        /// <summary>
        /// 8 键
        /// </summary>
        _8 = 0x38,

        /// <summary>
        /// 9 键
        /// </summary>
        _9 = 0x39,

        /// <summary>
        /// A 键
        /// </summary>
        A = 0x41,

        /// <summary>
        /// B 键
        /// </summary>
        B = 0x42,

        /// <summary>
        /// C 键
        /// </summary>
        C = 0x43,

        /// <summary>
        /// D 键
        /// </summary>
        D = 0x44,

        /// <summary>
        /// E 键
        /// </summary>
        E = 0x45,

        /// <summary>
        /// F 键
        /// </summary>
        F = 0x46,

        /// <summary>
        /// G 键
        /// </summary>
        G = 0x47,

        /// <summary>
        /// H 键
        /// </summary>
        H = 0x48,

        /// <summary>
        /// I 键
        /// </summary>
        I = 0x49,

        /// <summary>
        /// J 键
        /// </summary>
        J = 0x4A,

        /// <summary>
        /// K 键
        /// </summary>
        K = 0x4B,

        /// <summary>
        /// L 键
        /// </summary>
        L = 0x4C,

        /// <summary>
        /// M 键
        /// </summary>
        M = 0x4D,

        /// <summary>
        /// N 键
        /// </summary>
        N = 0x4E,

        /// <summary>
        /// O 键
        /// </summary>
        O = 0x4F,

        /// <summary>
        /// P 键
        /// </summary>
        P = 0x50,

        /// <summary>
        /// Q 键
        /// </summary>
        Q = 0x51,

        /// <summary>
        /// R 键
        /// </summary>
        R = 0x52,

        /// <summary>
        /// S 键
        /// </summary>
        S = 0x53,

        /// <summary>
        /// T 键
        /// </summary>
        T = 0x54,

        /// <summary>
        /// U 键
        /// </summary>
        U = 0x55,

        /// <summary>
        /// V 键
        /// </summary>
        V = 0x56,

        /// <summary>
        /// W 键
        /// </summary>
        W = 0x57,

        /// <summary>
        /// X 键
        /// </summary>
        X = 0x58,

        /// <summary>
        /// Y 键
        /// </summary>
        Y = 0x59,

        /// <summary>
        /// Z 键
        /// </summary>
        Z = 0x5A,

        /// <summary>
        /// 左 Windows 键
        /// </summary>
        LeftWin = 0x5B,

        /// <summary>
        /// 右 Windows 键
        /// </summary>
        RightWin = 0x5C,


        /// <summary>
        /// 计算机休眠键
        /// </summary>
        Sleep = 0x5F,

        /// <summary>
        /// 小键盘 0 键
        /// </summary>
        Numpad0 = 0x60,

        /// <summary>
        /// 小键盘 1 键
        /// </summary>
        Numpad1 = 0x61,

        /// <summary>
        /// 小键盘 2 键
        /// </summary>
        Numpad2 = 0x62,

        /// <summary>
        /// 小键盘 3 键
        /// </summary>
        Numpad3 = 0x63,

        /// <summary>
        /// 小键盘 4 键
        /// </summary>
        Numpad4 = 0x64,

        /// <summary>
        /// 小键盘 5 键
        /// </summary>
        Numpad5 = 0x65,

        /// <summary>
        /// 小键盘 6 键
        /// </summary>
        Numpad6 = 0x66,

        /// <summary>
        /// 小键盘 7 键
        /// </summary>
        Numpad7 = 0x67,

        /// <summary>
        /// 小键盘 8 键
        /// </summary>
        Numpad8 = 0x68,

        /// <summary>
        /// 小键盘 9 键
        /// </summary>
        Numpad9 = 0x69,

        /// <summary>
        /// 乘号键
        /// </summary>
        Multiply = 0x6A,

        /// <summary>
        /// 加号 键
        /// </summary>
        Add = 0x6B,

        /// <summary>
        /// 分隔符键
        /// </summary>
        Separator = 0x6C,

        /// <summary>
        /// 减号键
        /// </summary>
        Subtract = 0x6D,

        /// <summary>
        /// 句点键
        /// </summary>
        Decimal = 0x6E,

        /// <summary>
        /// 除号键
        /// </summary>
        Divide = 0x6F,

        /// <summary>
        /// F1 键
        /// </summary>
        F1 = 0x70,

        /// <summary>
        /// F2 键
        /// </summary>
        F2 = 0x71,

        /// <summary>
        /// F3 键
        /// </summary>
        F3 = 0x72,

        /// <summary>
        /// F4 键
        /// </summary>
        F4 = 0x73,

        /// <summary>
        /// F5 键
        /// </summary>
        F5 = 0x74,

        /// <summary>
        /// F6 键
        /// </summary>
        F6 = 0x75,

        /// <summary>
        /// F7 键
        /// </summary>
        F7 = 0x76,

        /// <summary>
        /// F8 键
        /// </summary>
        F8 = 0x77,

        /// <summary>
        /// F9 键
        /// </summary>
        F9 = 0x78,

        /// <summary>
        /// F10 键
        /// </summary>
        F10 = 0x79,

        /// <summary>
        /// F11 键
        /// </summary>
        F11 = 0x7A,

        /// <summary>
        /// F12 键
        /// </summary>
        F12 = 0x7B,


        /// <summary>
        /// 小键盘锁键
        /// </summary>
        NumLock = 0x90,

        /// <summary>
        /// 滚动锁键
        /// </summary>
        ScrollLock = 0x91,


        /// <summary>
        /// 左shift
        /// </summary>
        LeftShift = 0xA0,

        /// <summary>
        /// 右shift
        /// </summary>
        RightShift = 0xA1,

        /// <summary>
        /// 左ctrl
        /// </summary>
        LeftCtrl = 0xA2,

        /// <summary>
        /// 有ctrl
        /// </summary>
        RightCtrl = 0xA3,

        /// <summary>
        /// 左alt
        /// </summary>
        LeftAlt = 0xA4,

        /// <summary>
        /// 右alt
        /// </summary>
        RightAlt = 0xA5,

        /// <summary>
        ///  ;: 键
        /// </summary>
        OEM_1 = 0xBA,

        /// <summary>
        /// /? 键
        /// </summary>
        OEM_2 = 0xBF,

        /// <summary>
        /// `~ 键
        /// </summary>
        OEM_3 = 0xC0,

        /// <summary>
        /// [{ 键
        /// </summary>
        OEM_4 = 0xDB,

        /// <summary>
        ///  \| 键
        /// </summary>
        OEM_5 = 0xDC,

        /// <summary>
        ///  ]} 键
        /// </summary>
        OEM_6 = 0xDD,

        /// <summary>
        /// '" 键
        /// </summary>
        OEM_7 = 0xDE,

        /// <summary>
        /// <, 键
        /// </summary>
        OEM_8 = 0xBC,

        /// <summary>
        /// >. 键
        /// </summary>
        OEM_9 = 0xBE
    }
}
