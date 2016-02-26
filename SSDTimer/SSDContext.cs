using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace SSDTimer
{
    class SSDContext : ApplicationContext
    {
        private MainWindow window;
        private string age;

        public SSDContext()
        {
            window = new MainWindow();
            age = SystemAge.getAge();

            MenuItem show = new MenuItem("&Show Timer", new EventHandler(ShowWindow));
            MenuItem exit = new MenuItem("E&xit", (sender, e) => { Application.Exit(); });

            MenuItem startup = new MenuItem("Start with &Windows");
            startup.Checked = Properties.Settings.Default.Startup;
            startup.Click += StartUp_Click;

            NotifyIcon nicon = new NotifyIcon();
            nicon.Icon = genIcon();
            nicon.ContextMenu = new ContextMenu(new MenuItem[] { show, startup, exit });
            nicon.Text = age;
            nicon.MouseDoubleClick += ShowWindow;

            nicon.Visible = true;
        }

        void StartUp_Click(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (mi.Checked)
            {
                mi.Checked = false;
                key.DeleteValue(Application.ProductName, false);
            }
            else
            {
                mi.Checked = true;
                key.SetValue(Application.ProductName, Application.ExecutablePath);
            }
            Properties.Settings.Default.Startup = mi.Checked;
            Properties.Settings.Default.Save();
        }

        void ShowWindow(object sender, EventArgs e)
        {
            if (window == null) window = new MainWindow();

            if (window.Visible) window.Activate();
            else window.Show();
        }

        private Icon genIcon()
        {
            Bitmap iconBitmap = new Bitmap(16, 16);
            Graphics canvas = Graphics.FromImage(iconBitmap);

            Rectangle r = new Rectangle(0, 0, 16, 16);
            canvas.FillRectangle(new SolidBrush(Color.FromArgb(48, 48, 48)), r);

            canvas.DrawString(
                "SSD",
                new Font("Calibri", 6),
                new SolidBrush(Color.Orange),
                new Rectangle(0, 0, 16, 16),
                new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center }
            );

            return Icon.FromHandle(iconBitmap.GetHicon());
        }
    }
}
