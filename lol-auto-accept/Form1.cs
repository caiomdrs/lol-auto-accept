using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoItX3Lib;
using System.Threading;
using System.Runtime.InteropServices;

namespace lol_auto_accept
{
    public partial class Form1 : Form
    {
        IntPtr handle;
        string WINDOW_NAME = "League of Legends";

        AutoItX3 au3 = new AutoItX3();

        public RECT rect;

        public struct RECT
        {
            public int left, top,  right, bottom;
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string IpClassName, string IpWindowName);

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT IpRect);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread AA = new Thread(auto_accept) { IsBackground = true };
            AA.Start();
        }

        private void auto_accept()
        {
            while (true)
            {
                if (checkBox1.Checked)
                {
                    getWindowRectangle();
                    int col = au3.PixelGetColor(rect.left + 584, rect.top + 555);
                    if (col == 0x1E252A)
                    {
                        Thread.Sleep(20);
                        au3.MouseMove(rect.left + 584, rect.top + 555, 1);
                        au3.MouseClick("LEFT");
                        Thread.Sleep(20);
                        au3.MouseClick("LEFT");
                        Thread.Sleep(5000);
                    }
                }
                Thread.Sleep(20);
            }
        }

        void getWindowRectangle()
        {
            handle = FindWindow(null, WINDOW_NAME);
            GetWindowRect(handle, out rect);
        }
    }
}
