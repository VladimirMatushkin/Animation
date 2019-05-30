namespace Test
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.iListSpirte1 = new System.Windows.Forms.ImageList(this.components);
            this.scenePanel1 = new Animation.ScenePanel();
            this.sprite1 = new Animation.Sprite();
            this.sound1 = new Animation.Sound(this.components);
            this.scenePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(192, 395);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // iListSpirte1
            // 
            this.iListSpirte1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iListSpirte1.ImageStream")));
            this.iListSpirte1.TransparentColor = System.Drawing.Color.Transparent;
            this.iListSpirte1.Images.SetKeyName(0, "costume1.bmp");
            this.iListSpirte1.Images.SetKeyName(1, "costume2.bmp");
            this.iListSpirte1.Images.SetKeyName(2, "costume3.bmp");
            this.iListSpirte1.Images.SetKeyName(3, "costume4.bmp");
            // 
            // scenePanel1
            // 
            this.scenePanel1.Controls.Add(this.sprite1);
            this.scenePanel1.Filename = "C:\\Users\\АТЕЦ\\source\\repos\\Animation\\ы.png";
            this.scenePanel1.Location = new System.Drawing.Point(0, 0);
            this.scenePanel1.Name = "scenePanel1";
            this.scenePanel1.Size = new System.Drawing.Size(543, 389);
            this.scenePanel1.TabIndex = 0;
            // 
            // sprite1
            // 
            this.sprite1.Angle = 0F;
            this.sprite1.BackColor = System.Drawing.Color.Transparent;
            this.sprite1.BitmapScale = 1F;
            this.sprite1.BmpList = this.iListSpirte1;
            this.sprite1.Filename = null;
            this.sprite1.Flip = false;
            this.sprite1.ImageIndex = 0;
            this.sprite1.Location = new System.Drawing.Point(215, 88);
            this.sprite1.Name = "sprite1";
            this.sprite1.Size = new System.Drawing.Size(256, 256);
            this.sprite1.TabIndex = 0;
            // 
            // sound1
            // 
            this.sound1.Filename = "C:\\Users\\АТЕЦ\\source\\repos\\Animation\\sound\\Caine\'s Theme.wav";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 492);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.scenePanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.scenePanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Animation.ScenePanel scenePanel1;
        private System.Windows.Forms.Button button1;
        private Animation.Sprite sprite1;
        private System.Windows.Forms.ImageList iListSpirte1;
        private Animation.Sound sound1;
    }
}

