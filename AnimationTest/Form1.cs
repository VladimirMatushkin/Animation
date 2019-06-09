using System;
using System.Threading;
using System.Windows.Forms;

namespace AnimationTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            sound1.Play();
            for (int i = 0; i < 20; i++)
            {
                sprite1.NextImage();
                Thread.Sleep(200);
            }
            sound1.Stop();
        }
    }
}
