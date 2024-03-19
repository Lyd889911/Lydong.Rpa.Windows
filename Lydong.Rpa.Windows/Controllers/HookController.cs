using Lydong.Rpa.Windows;
using Lydong.Rpa.Windows.Bases.Hooks;
using System;
using System.Runtime.InteropServices;

namespace Lydong.Rpa.Windows.Hooks
{
    public class HookController
    {
        private delegate int KeyboardDelegateHandler(int nCode, int wParam, IntPtr lParam);

        //键盘钩子的id
        private int keyboardHookId = 0;
        //鼠标钩子的id
        private int mouseHookId = 0;
        //是否设置键盘鼠标钩子
        private bool isSetupMouseHook = false;
        private bool isSetupKeyboardHook = false;

        /// <summary>
        /// 键盘钩子回调<br/>
        /// HookType：钩子的类型，键按下，键抬起等<br/>
        /// IntPtr：具体哪个键的指针，可以转换成结构体
        /// </summary>
        internal static Action<HookType, HookData> HookCallbackAction { get; set; }
        /// <summary>
        /// 委托需要设置成静态的，把这个委托传递给user32的api调用，回到托管后能找到这个方法，
        /// 如果直接传递HookCallback方法到SetWindowsHookEx，多调用几次会报错。好像还是破坏了队列
        /// </summary>
        internal static HookProc proc;

        #region 设置钩子
        /// <summary>
        /// 设置键盘钩子
        /// </summary>
        /// <param name="HookCallbackAction"></param>
        public void SetupKeyboardHook(Action<HookType, HookData> hookCallbackAction)
        {
            //设置了就不能在设置了
            if (isSetupKeyboardHook)
                return;

            if (HookCallbackAction == null)
                HookCallbackAction = hookCallbackAction;
            if (proc == null)
                proc = HookCallback;

            keyboardHookId = User32.SetWindowsHookEx((int)HookType.Keyboard, proc, IntPtr.Zero, 0);
            if (keyboardHookId == 0)
                RemoveKeyboardHook();
            else
                isSetupKeyboardHook = true;
        }

        /// <summary>
        /// 设置鼠标钩子
        /// </summary>
        /// <param name="HookCallbackAction"></param>
        public void SetupMouseHook(Action<HookType, HookData> hookCallbackAction)
        {
            if (isSetupMouseHook)
                return;

            if(HookCallbackAction == null)
                HookCallbackAction = hookCallbackAction;
            if(proc == null)
                proc = HookCallback;

            mouseHookId = User32.SetWindowsHookEx((int)HookType.Mouse, proc, IntPtr.Zero, 0);
            if (mouseHookId == 0)
                RemoveMouseHook();
            else
                isSetupMouseHook = true;
        }
        /// <summary>
        /// 设置鼠标键盘钩子
        /// </summary>
        /// <param name="HookCallbackAction"></param>
        public void SetupHook(Action<HookType, HookData> hookCallbackAction)
        {
            SetupKeyboardHook(hookCallbackAction);
            SetupMouseHook(hookCallbackAction);
        }
        #endregion


        #region 移除钩子
        /// <summary>
        /// 移除键盘钩子
        /// </summary>
        public void RemoveKeyboardHook()
        {
            User32.UnhookWindowsHookEx(keyboardHookId);
            keyboardHookId = 0;
            isSetupKeyboardHook = false;

        }
        /// <summary>
        /// 移除鼠标钩子
        /// </summary>
        public void RemoveMouseHook()
        {
            User32.UnhookWindowsHookEx(mouseHookId);
            mouseHookId = 0;
            isSetupMouseHook = false;
        }
        /// <summary>
        /// 移除鼠标键盘钩子
        /// </summary>
        public void RemoveHook()
        {
            RemoveKeyboardHook();
            RemoveMouseHook();
        }
        #endregion


        private int HookCallback(int nCode, int wParam, IntPtr lParam)
        {
            bool iskeyboard = wParam == (int)HookType.KeyboardKeyDown
                || wParam == (int)HookType.KeyboardKeyUp
                || wParam == (int)HookType.KeyboardSysKeyDown
                || wParam == (int)HookType.KeyboardSysKeyUp;
            int hookId = iskeyboard ? keyboardHookId : mouseHookId;

            if(nCode<0)
                return User32.CallNextHookEx(hookId, nCode, wParam, lParam);

            HookData data = new HookData();
            if (iskeyboard)
                data.Keyboard = (KeyboardHookData)Marshal.PtrToStructure(lParam, typeof(KeyboardHookData));
            else
                data.Mouse = (MouseHookData)Marshal.PtrToStructure(lParam, typeof(MouseHookData));

            //具体方法
            HookCallbackAction((HookType)wParam, data);

            // 继续传递事件
            return User32.CallNextHookEx(hookId, nCode, wParam, lParam);

        }
    }
}
