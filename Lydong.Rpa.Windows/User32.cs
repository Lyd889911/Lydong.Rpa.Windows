using Lydong.Rpa.Windows.Bases.MouseAndKeyboards;
using Lydong.Rpa.Windows.Bases.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lydong.Rpa.Windows
{
    internal class User32
    {
        [DllImport("user32.dll")]
        internal static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, ushort bScan, int dwFlags, int dwExtraInfo);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr SetCursorPos(int x, int y);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr GetCursorPos(out Point lpPoint);
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern uint SendInput(uint nInputs, Input[] pInputs, int cbSize);


        /*
         * idHook:如果小于零，则挂钩过程必须将消息传递给CallNextHookEx函数，而无需进一步处理，并且应返回CallNextHookEx返回的值。
         * wParam:记录了按下的操作，比如鼠标左键按下，键盘K键抬起等
         * lParam:钩子的结构体数据指针，可以转换成结构体，拿到一些钩子的数据，比如鼠标的坐标，键盘按的哪个键
         */
        [DllImport("user32.dll")]
        internal static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        [DllImport("user32.dll")]
        internal static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        internal static extern bool UnhookWindowsHookEx(int idHook);


        //弹窗
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);

        //枚举全部窗口
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        //窗口是否显示
        [DllImport("user32.dll")]
        internal static extern bool IsWindowVisible(IntPtr hWnd);

        //得到窗口的矩形
        [DllImport("user32.dll")]
        internal static extern bool GetWindowRect(IntPtr hWnd, out WindowRectangle lpRect);

        //得到窗体的文本
        [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        //窗体是否最小化
        [DllImport("user32.dll")]
        internal static extern bool IsIconic(IntPtr hWnd);

        //显示窗口，最近显示状态
        [DllImport("user32.dll")]
        internal static extern bool ShowWindow(IntPtr hWnd, WindowShowStyle nCmdShow);

        //聚焦窗体
        [DllImport("user32.dll")]
        internal static extern bool SetForegroundWindow(IntPtr hWnd);

        //设置窗体的位置
        [DllImport("user32.dll")]
        internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int width, int height, uint flags);

        //获取系统的数据，屏幕宽0，高1
        [DllImport("user32.dll")]
        internal static extern int GetSystemMetrics(int nIndex);


    }
    internal delegate int HookProc(int nCode, int wParam, IntPtr lParam);
    internal delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
}
