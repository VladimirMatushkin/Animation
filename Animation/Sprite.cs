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
    public partial class Sprite : UserControl
    {
        string imgFile;
        ImageList bmpList = null;
        Bitmap bmp = null;
        Bitmap drawBmp = null;
        int imgListIndex = -1;
        float angle = 0;
        float scale = 1;
        bool flip = false;
        public int bmpX = 0;
        public int bmpY = 0;

        public Sprite()
        {
            InitializeComponent();
            this.BackColor = Color.Transparent;
        }

        [EditorAttribute(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Filename
        {
            get { return imgFile; }
            set
            {
                if (value != null && value.Length > 0)
                {
                    imgFile = value;
                    bmp = new Bitmap(imgFile);
                    if (bmp != null)
                    {
                        bmp.MakeTransparent(bmp.GetPixel(1, 1));
                        MakeDrawBmp();
                        RefreshScene();
                    }
                }
            }
        }

        public float Angle
        {
            get { return angle; }
            set
            {
                angle = value;
                if (bmp != null)
                {
                    MakeDrawBmp();
                    RefreshScene();
                }
            }
        }

        public bool Flip
        {
            get { return flip; }
            set
            {
                flip = value;
                if (bmp != null)
                {
                    MakeDrawBmp();
                    RefreshScene();
                }
            }
        }

        public float BitmapScale
        {
            get { return scale; }
            set
            {
                scale = value;
                if (bmp != null)
                {
                    MakeDrawBmp();
                    RefreshScene();
                }
            }
        }

        public Bitmap Bitmap
        {
            get { return drawBmp; }
        }

        //[Editor(typeof(System.ComponentModel.Design.CollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ImageList BmpList
        {
            get { return bmpList; }
            set
            {
                bmpList = value;
            }
        }

        public int ImageIndex
        {
            get { return imgListIndex; }
            set
            {
                if(bmpList!= null && value >=0 && value < bmpList.Images.Count)
                {
                    imgListIndex = value;
                    bmp = new Bitmap(bmpList.Images[imgListIndex]);
                    if (bmp != null)
                    {
                        bmp.MakeTransparent(bmp.GetPixel(1, 1));
                        MakeDrawBmp();
                        RefreshScene();
                    }
                }
            }
        }

        public void NextFrame()
        {
            if (imgListIndex != -1)
            {
                
                imgListIndex = (imgListIndex + 1) % bmpList.Images.Count;
                bmp = new Bitmap(bmpList.Images[imgListIndex]);
                bmp.MakeTransparent(bmp.GetPixel(1, 1));
                MakeDrawBmp();
                RefreshScene();
            }
        }

        /*
        private Bitmap rotateImage(Bitmap b, float angle)
        {
            int maxside = (int)(Math.Sqrt(b.Width * b.Width + b.Height * b.Height));
            //create a new empty bitmap to hold rotated image
            Bitmap returnBitmap = new Bitmap(maxside, maxside);
            //make a graphics object from the empty bitmap
            Graphics g = Graphics.FromImage(returnBitmap);
            //move rotation point to center of image
            g.TranslateTransform((float)b.Width / 2, (float)b.Height / 2);
            //rotate
            g.RotateTransform(angle);
            //move image back
            g.TranslateTransform(-(float)b.Width / 2, -(float)b.Height / 2);
            //draw passed in image onto graphics object
            g.DrawImage(b, new Point(0, 0));
            return returnBitmap;
        }
         */

        private void MakeDrawBmp()
        {
            if (drawBmp != null) drawBmp.Dispose(); 
            double w = this.Width;
            double h = this.Height;
            double r = Math.Sqrt(w * w + h * h);
            //double a1 = Math.Atan2(h, w) - angle / 180.0 * Math.PI;
            //double a2 = Math.Atan2(h, -w) - angle / 180.0 * Math.PI;
            //h = Math.Max(Math.Abs(r * Math.Sin(a1)), Math.Abs(r * Math.Sin(a2)));
            //w = Math.Max(Math.Abs(r * Math.Cos(a1)), Math.Abs(r * Math.Cos(a2)));

            bmpX = this.Left + (this.Width - (int)(w * scale)) / 2;
            bmpY = this.Top + (this.Height - (int)(h * scale)) / 2;
            drawBmp = new Bitmap((int)(r * scale), (int)(r * scale));

            Graphics g = Graphics.FromImage(drawBmp);
            g.TranslateTransform((float)drawBmp.Height / 2, (float)drawBmp.Height / 2);
            g.RotateTransform((float)angle);
            g.TranslateTransform(-(float)drawBmp.Width / 2, -(float)drawBmp.Height / 2);
            g.ScaleTransform((float)this.Width * scale / bmp.Width, (float)this.Height * scale / bmp.Height);

            g.DrawImage(bmp, 0, 0);
            if (flip) bmp.RotateFlip(RotateFlipType.Rotate180FlipX);

            /*double newWidth = this.Width, newHeight = this.Height;
            double angleRadians = Math.PI / 180.0;
            if (angle < 90)
            {
                angleRadians *= angle;
            }
            else if(angle < 180)
            {
                angleRadians *= (180 - angle);
            }
            else if(angle < 270)
            {
                angleRadians *= (270 - angle);
            }
            else if(angle < 360)
            {
                angleRadians *= (360 - angle);
            }
            newWidth = this.Width * Math.Cos(angleRadians) + this.Height * Math.Sin(angleRadians);
            newHeight = this.Width * Math.Sin(angleRadians) + this.Height * Math.Cos(angleRadians);
            //this.Width = (int)newWidth;
            //this.Height = (int)newHeight

            //MessageBox.Show(newWidth + " " + newHeight);
            if (drawBmp != null) drawBmp.Dispose();
            drawBmp = new Bitmap((int)newWidth, (int)newHeight);
            using (Graphics g = Graphics.FromImage(drawBmp))
            {
                g.TranslateTransform((float)newWidth / 2, (float)newHeight / 2);
                g.RotateTransform(angle);
                g.TranslateTransform((float)-newWidth / 2, (float)-newHeight / 2);
                g.DrawImage(bmp, 0, 0);
            }*/
        }

        private void RefreshScene()
        {
            if (this.Parent != null && this.Parent is ScenePanel)
            {
                (this.Parent as ScenePanel).RefreshScene();
                this.Parent.Refresh(); //?
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (bmp != null)
            {
                MakeDrawBmp();
                RefreshScene();
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            RefreshScene();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            if(drawBmp != null) {
                bmpX = this.Left + (this.Width - drawBmp.Width) / 2;
                bmpY = this.Top + (this.Height - drawBmp.Height) / 2;
            }
            
            RefreshScene();
        }
    }
}
