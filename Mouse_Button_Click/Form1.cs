using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace Mouse_Button_Click
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Opacity = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
            Click_Mouse();
        }

        private void Click_Mouse()
        {
            int c = 0;
            POINT p = new POINT();
            while (true)
            {
                GetCursorPos(ref p);
                ClientToScreen(Handle, ref p);
                DoMouseLeftClick(p.x, p.y); // Ліва кнопка миши
                //DoMouseRightClick(p.x, p.y); // права кнопка миши
                //DoMouseDoubleLeftClick(p.x, p.y); // двойний клік лівою кнопкою миши
                c++;
                Thread.Sleep(100);
                if (c == 50)
                {
                    break;
                }
            }
            Close();

        }

        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dsFlags, int dx, int dy, int cButtons, int dsExtraInfo);

        public const int MOUSE_EVENT_F_LEFTDOWN = 0X02;
        public const int MOUSE_EVENT_F_LEFTUP = 0X04;

        public const int MOUSE_EVENT_F_RIGHTDOWN = 0x08;
        public const int MOUSE_EVENT_F_RIGHTUP = 0x10;

        private void DoMouseLeftClick(int x, int y)
        {
            mouse_event(MOUSE_EVENT_F_LEFTDOWN, x, y, 0, 0);
            mouse_event(MOUSE_EVENT_F_LEFTUP, x, y, 0, 0);
        }
        private void DoMouseRightClick(int x, int y)
        {
            mouse_event(MOUSE_EVENT_F_RIGHTDOWN, x, y, 0, 0);
            mouse_event(MOUSE_EVENT_F_RIGHTUP, x, y, 0, 0);
        }
        private void DoMouseDoubleLeftClick(int x, int y)
        {
            mouse_event(MOUSE_EVENT_F_LEFTDOWN, x, y, 0, 0);
            mouse_event(MOUSE_EVENT_F_LEFTUP, x, y, 0, 0);

            mouse_event(MOUSE_EVENT_F_LEFTDOWN, x, y, 0, 0);
            mouse_event(MOUSE_EVENT_F_LEFTUP, x, y, 0, 0);
        }

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(ref POINT lpPoint);
    }
}
