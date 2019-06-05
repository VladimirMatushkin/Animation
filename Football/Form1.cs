using System;
using System.Windows.Forms;

namespace Football
{
    public partial class Form1 : Form
    {
        private int ballSpeed = 0;
        private int dx = 0;
        private int dy = 0;

        public Form1()
        {
            InitializeComponent();

            KeyPreview = true;
            DoubleBuffered = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D:
                    if (sprite2.Left + sprite2.Width + 5 >= sprite1.Left && sprite2.Left + sprite2.Width + 5 <= sprite1.Left + sprite1.Width && sprite2.Top <= sprite1.Top && sprite2.Top + sprite2.Height >= sprite1.Top)
                    {
                        dx = 1;
                    }
                    sprite2.Left += 5;
                    ballSpeed = 10;
                    break;
                case Keys.A:
                    if (sprite2.Left - 5 <= sprite1.Left + sprite1.Width && sprite2.Left + sprite2.Width >= sprite1.Left && sprite2.Top <= sprite1.Top && sprite2.Top + sprite2.Height >= sprite1.Top)
                    {
                        dx = -1;
                    }
                    sprite2.Left -= 5;
                    ballSpeed = 10;
                    break;
                case Keys.S:
                    if (sprite2.Top + sprite2.Height + 5 >= sprite1.Top && sprite2.Top + sprite2.Height + 5 <= sprite1.Top + sprite1.Height && sprite2.Left <= sprite1.Left && sprite2.Left + sprite2.Width >= sprite1.Left)
                    {
                        dy = 1;
                    }
                    sprite2.Top += 5;
                    ballSpeed = 10;
                    break;
                case Keys.W:
                    if (sprite2.Top - 5 <= sprite1.Top + sprite1.Height && sprite2.Top + sprite2.Height >= sprite1.Top && sprite2.Left <= sprite1.Left && sprite2.Left + sprite2.Width >= sprite1.Left)
                    {
                        dy = -1;
                    }
                    sprite2.Top -= 5;
                    ballSpeed = 10;
                    break;
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (ballSpeed > 0)
            {
                sprite1.Left += dx * ballSpeed;
                sprite1.Top += dy * ballSpeed;
                ballSpeed -= 2;
                if (ballSpeed <= 0)
                {
                    ballSpeed = 0;
                    dx = 0;
                    dy = 0;
                }
            }
        }
    }
}
