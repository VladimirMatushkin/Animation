using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sprite1.Width = 10;
            //sprite2.Top = 100;
            //sprite2.Left = 10;
            //scenePanel1.RefreshScene();
            sound1.Play();
            for (int i = 0; i < 63; i++)
            {
                sprite1.NextFrame();
                Thread.Sleep(200);
            }
            sound1.Stop();
        }
    }
}
