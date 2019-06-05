using System;
using System.Threading;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sound1.Play();
            for (int i = 0; i < 50; i++)
            {
                sprite1.NextFrame();
                Thread.Sleep(200);
            }
            sound1.Stop();
        }
    }
}
