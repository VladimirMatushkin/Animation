using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Animation
{
    /// <summary>
    /// Container for the Sprite components.
    /// </summary>
    public partial class ScenePanel : Panel
    {
        private string _sourceFile = null;
        private Bitmap _backgroundImage = null;
        private BufferedGraphics _graphicsBuffer = null;
        private int _width = -1;
        private int _height = -1;

        public ScenePanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This property represent a string that holds the path to the source image.
        /// </summary>
        [
            Category("ScenePanel"),
            Description("Path to the source image of the ScenePanel."),
            EditorAttribute(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))
        ]
        public string SourceFile
        {
            get { return _sourceFile; }
            set
            {
                _sourceFile = value;
                _backgroundImage = new Bitmap(_sourceFile);
                RefreshScene();
            }
        }

        /// <summary>
        /// Redraw background and all the sprites that are placed on this component.
        /// Save result image to buffer that will be used in OnPaint event.
        /// </summary>
        public void RefreshScene()
        {
            // If the component size has changed - create new buffer.
            Rectangle rectangle = this.DisplayRectangle;
            if (rectangle.Width != _width || rectangle.Height != _height)
            {
                if (_graphicsBuffer != null)
                    _graphicsBuffer.Dispose();
                _graphicsBuffer = BufferedGraphicsManager.Current.Allocate(this.CreateGraphics(), rectangle);
                _width = rectangle.Width;
                _height = rectangle.Height;
            }

            // Draw background and all the sprites that are placed on this component.
            Graphics g = _graphicsBuffer.Graphics;
            g.DrawImage(_backgroundImage, 0, 0, this.Width, this.Height);
            foreach (Control c in this.Controls)
            {
                if (c is Sprite s)
                {
                    Bitmap bmp = s.Image;
                    if (bmp != null)
                    {
                        //g.DrawImage(bmp, s.bmpX, s.bmpY, bmp.Width, bmp.Height);
                        g.DrawImage(bmp, s.displayedImageLeft, s.displayedImageTop);
                    }
                }
            }
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            if (_backgroundImage != null)
                RefreshScene();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
            //g.Graphics.DrawImage(background, 0, 0, this.Width, this.Height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_graphicsBuffer != null)
                _graphicsBuffer.Render(e.Graphics);
        }
    }
}
