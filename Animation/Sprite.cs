using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

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

        List<Bitmap> cache;

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
                if (bmp != null)
                {
                    if (flip != value)
                    {
                        bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        MakeDrawBmp();
                        RefreshScene();
                    }
                    flip = value;
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
                if(value != null)
                {
                    bmpList = value;
                    cache = new List<Bitmap>(value.Images.Count);
                    for (int i = 0; i < value.Images.Count; i++)
                    {
                        cache.Add(new Bitmap(value.Images[i]));
                        cache[i].MakeTransparent(cache[i].GetPixel(1, 1));
                    }
                }
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
                    //bmp = new Bitmap(bmpList.Images[imgListIndex]);
                    bmp = cache[imgListIndex];
                    if (bmp != null)
                    {
                        //bmp.MakeTransparent(bmp.GetPixel(1, 1));
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
                //bmp = new Bitmap(bmpList.Images[imgListIndex]);
                //bmp.MakeTransparent(bmp.GetPixel(1, 1));
                bmp = cache[imgListIndex];
                MakeDrawBmp();
                RefreshScene();
            }
        }

        private void MakeDrawBmp()
        {
            if (drawBmp != null) drawBmp.Dispose();

            int l = bmp.Width;
            int h = bmp.Height;
            double radian = angle * Math.PI / 180;
            double cos = Math.Abs(Math.Cos(radian));
            double sin = Math.Abs(Math.Sin(radian));
            int nl = (int)((l * cos + h * sin) * scale);
            int nh = (int)((l * sin + h * cos) * scale);

            drawBmp = new Bitmap(nl, nh);
            Graphics g = Graphics.FromImage(drawBmp);

            g.TranslateTransform(nl / 2f, nh / 2f);
            g.ScaleTransform(scale, scale);
            g.RotateTransform(angle);
            g.TranslateTransform(-l / 2f, -h / 2f);

            g.DrawImage(bmp, 0, 0);

            bmpX = this.Left + (this.Width - nl) /2;
            bmpY = this.Top + (this.Height - nh) / 2;
            //return returnBitmap;

            //if (drawBmp != null) drawBmp.Dispose(); 
            //double w = this.Width;
            //double h = this.Height;
            //double r = Math.Sqrt(w * w + h * h);
            ////double a1 = Math.Atan2(h, w) - angle / 180.0 * Math.PI;
            ////double a2 = Math.Atan2(h, -w) - angle / 180.0 * Math.PI;
            ////h = Math.Max(Math.Abs(r * Math.Sin(a1)), Math.Abs(r * Math.Sin(a2)));
            ////w = Math.Max(Math.Abs(r * Math.Cos(a1)), Math.Abs(r * Math.Cos(a2)));

            //bmpX = this.Left + (this.Width - (int)(r * scale)) / 2;
            //bmpY = this.Top + (this.Height - (int)(r * scale)) / 2;
            //drawBmp = new Bitmap((int)(r * scale), (int)(r * scale));

            //Graphics g = Graphics.FromImage(drawBmp);

            //g.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
            //g.RotateTransform((float)angle);
            //g.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
            //g.ScaleTransform((float)this.Width * scale / bmp.Width, (float)this.Height * scale / bmp.Height);

            //if (flip) bmp.RotateFlip(RotateFlipType.Rotate180FlipX);
            //g.DrawImage(bmp, 0, 0);

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
                this.Parent.Refresh(); 
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
            //base.OnLocationChanged(e);
            if(drawBmp != null) {
                bmpX = this.Left + (this.Width - drawBmp.Width) / 2;
                bmpY = this.Top + (this.Height - drawBmp.Height) / 2;
                RefreshScene();
            }
        }
    }
}
