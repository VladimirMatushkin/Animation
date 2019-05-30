using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animation
{
    public partial class ScenePanel : Panel
    {
        string imgFile;
        Bitmap background;
        BufferedGraphics graphicsBuffer=null;
        public ScenePanel()
        {
            InitializeComponent();
        }

        [EditorAttribute(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Filename 
        {
            get { return imgFile;}
            set
            {
                imgFile = value; background = new Bitmap(imgFile);
                RefreshScene();
            }
        }

        public void RefreshScene()
        {
            if(graphicsBuffer!=null) graphicsBuffer.Dispose();
            graphicsBuffer = BufferedGraphicsManager.Current.Allocate(this.CreateGraphics(), this.DisplayRectangle);
            Graphics g = graphicsBuffer.Graphics;
            g.DrawImage(background, 0, 0, this.Width, this.Height);
            foreach (Control c in this.Controls)
            {
                if (c is Sprite)
                {
                    Sprite cc = (Sprite)c;
                    Bitmap bmp=cc.Bitmap;
                    if(bmp!=null)
                    {
                        g.DrawImage(bmp, cc.bmpX, cc.bmpY);
                    }
                }
            }
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            RefreshScene();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (graphicsBuffer != null)
                graphicsBuffer.Render(e.Graphics);
        }
    }
}
