using Lydong.Rpa.Windows.Controllers;
using Lydong.Rpa.Windows.Hooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lydong.Rpa.Windows
{
    public class RPA
    {
        /// <summary>
        /// 鼠标操作
        /// </summary>
        public static readonly MouseController Mouse = new MouseController();
        /// <summary>
        /// 键盘操作
        /// </summary>
        public static readonly KeyboardController Keyboard = new KeyboardController();
        /// <summary>
        /// 键鼠钩子操作
        /// </summary>
        public static readonly HookController Hook = new HookController();
        /// <summary>
        /// 弹窗
        /// </summary>
        public static readonly MessageBoxController MessageBox = new MessageBoxController();
        /// <summary>
        /// 应用程序
        /// </summary>
        public static readonly ApplicationController Application = new ApplicationController();
        /// <summary>
        /// 图片
        /// </summary>
        public static readonly ImageController Image = new ImageController();
    }
}
