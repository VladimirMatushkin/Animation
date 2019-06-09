using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Animation
{
    /// <summary>
    /// Sprite - component that provides such manipulations on the image as rotation, scaling, flipping.
    /// Should be placed on <c>ScenePanel</c> component.
    /// </summary>
    [Description("Component that provides different manipulations on the image. Should be placed on ScenePanel component")]
    public partial class Sprite : UserControl
    {
        public int displayedImageLeft = 0;
        public int displayedImageTop = 0;

        private string _sourceFile = null;
        private Bitmap _baseImage = null;
        private Bitmap _displayedImage = null;
        private ImageList _imageList = null;
        private int _imageListIndex;
        private float _angle = 0.0F;
        private float _scaleX = 1;
        private float _scaleY = 1;
        private bool _flipX = false;
        private bool _flipY = false;

        List<Bitmap> cache;

        public Sprite()
        {
            InitializeComponent();
            this.BackColor = Color.Transparent;
        }

        #region Public Properties

        /// <summary>
        /// This property represent a string that holds the path to the source image.
        /// </summary>
        [
            Category("Sprite"),
            Description("Path to the source image of the Sprite."),
            EditorAttribute(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))
        ]
        public string SourceFile
        {
            get { return _sourceFile; }
            set
            {
                if (value != null && value.Length > 0)
                {
                    _sourceFile = value;
                    _baseImage = new Bitmap(_sourceFile);
                    if (_baseImage != null)
                    {
                        _baseImage.MakeTransparent(_baseImage.GetPixel(1, 1));
                        MakeDrawBmp();
                        RefreshScene();
                    }
                }
            }
        }

        /// <summary>
        /// Get the displayed image.
        /// </summary>
        [
            Category("Sprite"),
            Description("Displayed image with applied transformations.")
        ]
        public Bitmap Image
        {
            get { return _displayedImage; }
        }

        /// <summary>
        /// ImageList that used to animate sprite.
        /// </summary>
        [
            Category("Sprite"),
            Description("ImageList that used to animate sprite.")
        //[Editor(typeof(System.ComponentModel.Design.CollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        ]
        public ImageList ImgList
        {
            get { return _imageList; }
            set
            {
                if (value != null)
                {
                    if(value.Images.Count == 0)
                    {
                        MessageBox.Show("ImageList is empty");
                    }
                    else
                    {
                        _imageList = value;
                        _imageListIndex = 0;
                        cache = new List<Bitmap>(value.Images.Count);
                        for (int i = 0; i < value.Images.Count; i++)
                        {
                            cache.Add(new Bitmap(value.Images[i]));
                            cache[i].MakeTransparent(cache[i].GetPixel(1, 1));
                        }
                        _baseImage = cache[0];
                        MakeDrawBmp();
                        RefreshScene();
                    }
                }
            }
        }

        /// <summary>
        /// The index of the image in ImageList from which starts the animation.
        /// </summary>
        [
            Category("Sprite"),
            Description("The index of the image in the ImageList from which starts the animation.")
        ]
        public int ImageListIndex
        {
            get { return _imageListIndex; }
            set
            {
                if (_imageList != null && value >= 0 && value < _imageList.Images.Count)
                {
                    _imageListIndex = value;
                    //bmp = new Bitmap(bmpList.Images[imgListIndex]);
                    _baseImage = cache[_imageListIndex];
                    if (_baseImage != null)
                    {
                        //bmp.MakeTransparent(bmp.GetPixel(1, 1));
                        MakeDrawBmp();
                        RefreshScene();
                    }
                }
            }
        }

        /// <summary>
        /// Represents the angle of rotation of the sprite. Default value is 0.0. Can be negative.
        /// </summary>
        [
            Category("Sprite"),
            Description("Angle of sprite rotation.")
        ]
        public float Angle
        {
            get { return _angle; }
            set
            {
                _angle = value;
                if (_baseImage != null)
                {
                    MakeDrawBmp();
                    RefreshScene();
                }
            }
        }

        /// <summary>
        /// Set a horizontal flip.
        /// </summary>
        [
            Category("Sprite"),
            Description("When this property is true, make a horizontal sprite image flip.")
        ]
        public bool FlipX
        {
            get { return _flipX; }
            set
            {
                if (_baseImage != null)
                {
                    if (_flipX != value)
                    {
                        _baseImage.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        MakeDrawBmp();
                        RefreshScene();
                    }
                    _flipX = value;
                }
            }
        }

        /// <summary>
        /// Set a vertical flip.
        /// </summary>
        [
            Category("Sprite"),
            Description("When this property is true, make a vertical sprite image flip.")
        ]
        public bool FlipY
        {
            get { return _flipY; }
            set
            {
                if (_baseImage != null)
                {
                    if (_flipY != value)
                    {
                        _baseImage.RotateFlip(RotateFlipType.RotateNoneFlipY);
                        MakeDrawBmp();
                        RefreshScene();
                    }
                    _flipY = value;
                }
            }
        }

        /// <summary>
        /// Scale the sprite in the X direction.
        /// </summary>
        [
            Category("Sprite"),
            Description("The scale of sprite in the X direction.")
        ]
        public float ScaleX
        {
            get { return _scaleX; }
            set
            {
                _scaleX = value;
                if (_baseImage != null)
                {
                    MakeDrawBmp();
                    RefreshScene();
                }
            }
        }

        /// <summary>
        /// Scale the sprite in the Y direction.
        /// </summary>
        [
            Category("Sprite"),
            Description("The scale of sprite in the Y direction.")
        ]
        public float ScaleY
        {
            get { return _scaleY; }
            set
            {
                _scaleY = value;
                if (_baseImage != null)
                {
                    MakeDrawBmp();
                    RefreshScene();
                }
            }
        }

        #endregion Public Properties

        #region Override Events

        protected override void OnResize(EventArgs e)
        {
            //base.OnResize(e);
            if (_baseImage != null)
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

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            //base.OnLocationChanged(e);
            if (_displayedImage != null)
            {
                displayedImageLeft = this.Left + (this.Width - _displayedImage.Width) / 2;
                displayedImageTop = this.Top + (this.Height - _displayedImage.Height) / 2;
                RefreshScene();
            }
        }

        #endregion Override Events

        #region Public Methods

        /// <summary>
        /// Determines if this sprite intersects with <paramref name="s"/>
        /// </summary>
        /// <returns>
        /// This method returns true if there is any intersection, otherwise false.
        /// </returns>
        /// <param name="s">The sprite to test.</param>
        public bool Intersect(Sprite s)
        {
            return Math.Max(displayedImageLeft, s.displayedImageLeft) <= Math.Min(displayedImageLeft + _displayedImage.Width,
                                                                                  s.displayedImageLeft + s._displayedImage.Width) &&
                Math.Max(displayedImageTop, s.displayedImageTop) <= Math.Min(displayedImageTop + _displayedImage.Height,
                                                                             s.displayedImageTop + s._displayedImage.Height);
        }

        /// <summary>
        /// Draw next image in ImageList on the sprite. 
        /// If the end is reached - start from the beginning.
        /// </summary>
        public void NextImage()
        {
            if (_imageList != null && _imageList.Images.Count != 0)
            {
                _imageListIndex = (_imageListIndex + 1) % _imageList.Images.Count;
                //bmp = new Bitmap(bmpList.Images[imgListIndex]);
                //bmp.MakeTransparent(bmp.GetPixel(1, 1));
                _baseImage = cache[_imageListIndex];
                MakeDrawBmp();
                RefreshScene();
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Apply all transofmations to the base image
        /// and draw it to displayed image.
        /// Sets new Top and Left coordinates if size of displayed image is changed.
        /// </summary>
        private void MakeDrawBmp()
        {
            int oldWidth = _baseImage.Width;
            int oldHeight = _baseImage.Height;
            double radian = _angle * Math.PI / 180;
            double cos = Math.Abs(Math.Cos(radian));
            double sin = Math.Abs(Math.Sin(radian));
            float componentScaleX = (float)this.Width / _baseImage.Width;
            float componentScaleY = (float)this.Height / _baseImage.Height;
            int newWidth = (int)((oldWidth * cos + oldHeight * sin) * _scaleX * componentScaleX);
            int newHeight = (int)((oldWidth * sin + oldHeight * cos) * _scaleY * componentScaleY);

            if (_displayedImage != null)
                _displayedImage.Dispose();
            _displayedImage = new Bitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(_displayedImage))
            {
                g.TranslateTransform(newWidth / 2f, newHeight / 2f);
                g.ScaleTransform(_scaleX * componentScaleX, _scaleY * componentScaleY);
                g.RotateTransform(_angle);
                g.TranslateTransform(-oldWidth / 2f, -oldHeight / 2f);

                g.DrawImage(_baseImage, 0, 0);
            }

            displayedImageLeft = this.Left + (this.Width - newWidth) / 2;
            displayedImageTop = this.Top + (this.Height - newHeight) / 2;
        }

        /// <summary>
        /// Calls the <c>ScenePanel</c> RefreshScene method 
        /// in which this sprite is placed to redraw entire scene
        /// </summary>
        private void RefreshScene()
        {
            if (this.Parent != null && this.Parent is ScenePanel)
            {
                (this.Parent as ScenePanel).RefreshScene();
                this.Parent.Refresh();
            }
        }

        #endregion Private Methods
    }
}
