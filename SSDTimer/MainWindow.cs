using System;
using System.Windows.Forms;

namespace SSDTimer
{
    public partial class MainWindow : Form
    {
        private string age;

        public MainWindow()
        {
            InitializeComponent();
            age = SystemAge.getAge();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            ssdAge.Text = age;            
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }        
    }
}
