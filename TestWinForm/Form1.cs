using Lydong.Rpa.Windows;
using Lydong.Rpa.Windows.Hooks;
using Lydong.Rpa.Windows.Bases.Hooks;
using System.Runtime.InteropServices;
using Keys = Lydong.Rpa.Windows.Bases.MouseAndKeyboards.Keys;

namespace TestWinForm
{
    public partial class Form1 : Form
    {
        string a = "";
        int count = 0;
        object obj = new();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //HookController.mkEvent += HC;
            RPA.Hook.SetupHook(HookCallback);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RPA.Hook.RemoveHook();
            Environment.Exit(0);
        }

        private void HookCallback(HookType hookType, HookData hookData)
        {
            if (hookType == HookType.KeyboardKeyDown)
            {
                label1.Text = $"按了{(hookData.Keyboard.Key)}，键值：{(int)hookData.Keyboard.Key}";
                //Task.Run(() => { label1.Text = $"按了{(hookData.Keyboard.Key).ToString()}"; });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3000; i++)
            {
                a = $"坐标:Yasfasfasdfasdfasdfasdfas";
                //Task.Run(() => { a = $"坐标:Yasfasfasdfasdfasdfasdfas"; });
            }
        }
    }
}