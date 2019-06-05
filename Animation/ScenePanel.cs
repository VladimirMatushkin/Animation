using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Animation
{
    public partial class ScenePanel : Panel
    {
        string imgFile;
        Bitmap background;
        BufferedGraphics graphicsBuffer = null;
        int width = -1;
        int height = -1;

        //BufferedGraphicsContext myContext = new BufferedGraphicsContext();

        public ScenePanel()
        {
            InitializeComponent();
        }

        [EditorAttribute(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Filename
        {
            get { return imgFile; }
            set
            {
                imgFile = value;
                background = new Bitmap(imgFile);
                RefreshScene();
            }
        }

        public void RefreshScene()
        {
            //if (graphicsBuffer != null) graphicsBuffer.Dispose();
            //graphicsBuffer = BufferedGraphicsManager.Current.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            Rectangle rectangle = this.DisplayRectangle;
            if (rectangle.Width != width || rectangle.Height != height)
            {
                if (graphicsBuffer != null)
                    graphicsBuffer.Dispose();
                graphicsBuffer = BufferedGraphicsManager.Current.Allocate(this.CreateGraphics(), rectangle);
                //graphicsBuffer = myContext.Allocate(this.CreateGraphics(), rectangle);
                width = rectangle.Width;
                height = rectangle.Height;
            }
            
            Graphics g = graphicsBuffer.Graphics;
            g.DrawImage(background, 0, 0, this.Width, this.Height);
            foreach (Control c in this.Controls)
            {
                if (c is Sprite s && s.Visible == true)
                {
                    Bitmap bmp = s.Bitmap;
                    if (bmp != null)
                    {
                        //g.DrawImage(bmp, s.bmpX, s.bmpY, bmp.Width, bmp.Height);
                        g.DrawImage(bmp, s.bmpX, s.bmpY);
                    }
                }
            }
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            RefreshScene();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            //g.Graphics.DrawImage(background, 0, 0, this.Width, this.Height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //MessageBox.Show("Onapa");
            if (graphicsBuffer != null)
                graphicsBuffer.Render(e.Graphics);
        }
    }
}
