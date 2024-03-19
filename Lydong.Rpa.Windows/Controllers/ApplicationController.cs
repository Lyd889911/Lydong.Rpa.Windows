using Lydong.Rpa.Windows;
using Lydong.Rpa.Windows.Bases.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lydong.Rpa.Windows.Controllers
{
    public class ApplicationController
    {

        /// <summary>
        /// 进程是否在运行
        /// </summary>
        /// <param name="processName"></param>
        /// <returns></returns>
        public bool IsApplicationRunning(string processName)
        {
            string nameWithoutExtension = Path.GetFileNameWithoutExtension(processName);
            return Process.GetProcesses().Any(p => nameWithoutExtension.Equals(p.ProcessName, StringComparison.OrdinalIgnoreCase));
        }


        /// <summary>
        /// 杀死进程
        /// </summary>
        /// <param name="processName"></param>
        public void KillProcesses(string processName)
        {
            string nameWithoutExtension = Path.GetFileNameWithoutExtension(processName);
            var items = Process.GetProcesses().Where(p => nameWithoutExtension.Equals(p.ProcessName, StringComparison.OrdinalIgnoreCase));
            foreach (var p in items)
            {
                p.Kill();
            }
        }


        /// <summary>
        /// 启动程序
        /// </summary>
        public Process LaunchApplication(string appPath, string? arguments = null)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = appPath,
                Arguments = arguments,
                UseShellExecute = true,//这样就可以用"chrome.exe"这个相对路径启动，而不用全路径
            };
            return Process.Start(startInfo);
        }


        /// <summary>
        /// 查找窗体
        /// </summary>
        /// <param name="predict"></param>
        /// <returns></returns>
        public Window? FindWindow(Func<Window, bool> predict)
        {
            Window? window = null;
            User32.EnumWindows((hwnd, _) =>
            {
                //true就是继续枚举，false停止枚举
                bool visible = User32.IsWindowVisible(hwnd);
                if (!visible)
                    return true;
                var currentWin = new Window() { Id= hwnd };
                if (predict(currentWin))
                {
                    window = currentWin;
                    return false;
                }
                else
                {
                    return true;
                }
            }, IntPtr.Zero);
            return window;
        }


        /// <summary>
        /// 得到全部窗体
        /// </summary>
        /// <returns></returns>
        public List<Window> GetWindows()
        {
            List<Window> list = new List<Window>();
            User32.EnumWindows((hwnd, _) =>
            {
                var window = new Window() { Id = hwnd };
                list.Add(window);
                return true;
            }, IntPtr.Zero);
            return list;
        }


        /// <summary>
        /// 等待窗体加载完成
        /// </summary>
        public Window WaitForWindow(Func<Window, bool> predict, double timeoutSeconds = 2)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Window? window = null;
            while ((window = GetWindows().FirstOrDefault(predict)) == null)
            {
                if (stopwatch.ElapsedMilliseconds > timeoutSeconds * 1000)
                {
                    throw new TimeoutException("wait for Window timeout");
                }
                Thread.Sleep(50);
            }
            return window;
        }
    }
}
