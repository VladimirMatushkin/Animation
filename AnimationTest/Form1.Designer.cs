namespace AnimationTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.scenePanel1 = new Animation.ScenePanel();
            this.sprite1 = new Animation.Sprite();
            this.button1 = new System.Windows.Forms.Button();
            this.sound1 = new Animation.Sound(this.components);
            this.scenePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "costume1.bmp");
            this.imageList1.Images.SetKeyName(1, "costume2.bmp");
            this.imageList1.Images.SetKeyName(2, "costume3.bmp");
            this.imageList1.Images.SetKeyName(3, "costume4.bmp");
            this.imageList1.Images.SetKeyName(4, "costume5.bmp");
            this.imageList1.Images.SetKeyName(5, "costume6.bmp");
            // 
            // scenePanel1
            // 
            this.scenePanel1.Controls.Add(this.sprite1);
            this.scenePanel1.Controls.Add(this.button1);
            this.scenePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scenePanel1.Location = new System.Drawing.Point(0, 0);
            this.scenePanel1.Name = "scenePanel1";
            this.scenePanel1.Size = new System.Drawing.Size(664, 390);
            this.scenePanel1.SourceFile = "C:\\Users\\АТЕЦ\\source\\repos\\Animation\\AnimationTest\\Images\\backdrop1.bmp";
            this.scenePanel1.TabIndex = 0;
            // 
            // sprite1
            // 
            this.sprite1.Angle = 0F;
            this.sprite1.BackColor = System.Drawing.Color.Transparent;
            this.sprite1.FlipX = false;
            this.sprite1.FlipY = false;
            this.sprite1.ImageListIndex = 0;
            this.sprite1.ImgList = this.imageList1;
            this.sprite1.Location = new System.Drawing.Point(211, 147);
            this.sprite1.Name = "sprite1";
            this.sprite1.ScaleX = 1F;
            this.sprite1.ScaleY = 1F;
            this.sprite1.Size = new System.Drawing.Size(223, 231);
            this.sprite1.SourceFile = null;
            this.sprite1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(281, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Play";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // sound1
            // 
            this.sound1.SourceFile = "C:\\Users\\АТЕЦ\\source\\repos\\Animation\\AnimationTest\\Images\\sound\\Caine\'s Theme.wav" +
    "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 390);
            this.Controls.Add(this.scenePanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.scenePanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Animation.ScenePanel scenePanel1;
        private Animation.Sprite sprite1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ImageList imageList1;
        private Animation.Sound sound1;
    }
}

