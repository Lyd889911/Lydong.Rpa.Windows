using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lydong.Rpa.Windows;

namespace Lydong.Rpa.Windows.Controllers
{
    public class MessageBoxController
    {

        /// <summary>
        /// 弹出提示框
        /// </summary>
        /// <param name="text"></param>
        /// <param name="title"></param>
        public void Alert(string text, string title = " ")
        {
            User32.MessageBox(IntPtr.Zero, text, title, 64 | 0);
        }

        /// <summary>
        /// 弹出确认框
        /// </summary>
        /// <param name="text"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool Confirm(string text, string title = " ")
        {
            var r = User32.MessageBox(IntPtr.Zero, text, title, 32 | 1);
            if (r == 1)
                return true;
            else 
                return false;
        }
    }
}
