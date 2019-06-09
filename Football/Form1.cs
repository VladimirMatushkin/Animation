using System;
using System.Windows.Forms;

namespace Football
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            KeyPreview = true;
            DoubleBuffered = true;
        }

        private float ballSpeed = 0;
        private int dx = 0;
        private int dy = 0;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    if(sprite2.Intersect(sprite1))
                    {
                        dx = 1;
                        dy = 0;
                        ballSpeed = 10;
                    }
                    sprite2.Left += 5;
                    break;
                case Keys.A:
                    if (sprite2.Intersect(sprite1))
                    {
                        dx = -1;
                        dy = 0;
                        ballSpeed = 10;
                    }
                    sprite2.Left -= 5;
                    break;
                case Keys.S:
                    if (sprite2.Intersect(sprite1))
                    {
                        dy = 1;
                        dx = 0;
                        ballSpeed = 10;
                    }
                    sprite2.Top += 5;
                    break;
                case Keys.W:
                    if (sprite2.Intersect(sprite1))
                    {
                        dy = -1;
                        dx = 0;
                        ballSpeed = 10;
                    }
                    sprite2.Top -= 5;
                    break;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (ballSpeed > 0)
            {
                sprite1.Left += (int)(dx * ballSpeed);
                sprite1.Top += (int)(dy * ballSpeed);
                ballSpeed -= 0.5F;
            }
        }
    }
}
