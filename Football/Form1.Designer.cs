namespace Football
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.scenePanel1 = new Animation.ScenePanel();
            this.sprite2 = new Animation.Sprite();
            this.sprite1 = new Animation.Sprite();
            this.scenePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // scenePanel1
            // 
            this.scenePanel1.Controls.Add(this.sprite2);
            this.scenePanel1.Controls.Add(this.sprite1);
            this.scenePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scenePanel1.Filename = "C:\\Users\\АТЕЦ\\source\\repos\\Animation\\New folder\\field.jpg";
            this.scenePanel1.Location = new System.Drawing.Point(0, 0);
            this.scenePanel1.Name = "scenePanel1";
            this.scenePanel1.Size = new System.Drawing.Size(920, 585);
            this.scenePanel1.TabIndex = 0;
            // 
            // sprite2
            // 
            this.sprite2.Angle = 0F;
            this.sprite2.BackColor = System.Drawing.Color.Transparent;
            this.sprite2.BitmapScale = 1F;
            this.sprite2.BmpList = null;
            this.sprite2.Filename = "C:\\Users\\АТЕЦ\\source\\repos\\Animation\\New folder\\ricardo.png";
            this.sprite2.Flip = false;
            this.sprite2.ImageIndex = -1;
            this.sprite2.Location = new System.Drawing.Point(203, 240);
            this.sprite2.Name = "sprite2";
            this.sprite2.Size = new System.Drawing.Size(57, 86);
            this.sprite2.TabIndex = 1;
            // 
            // sprite1
            // 
            this.sprite1.Angle = 0F;
            this.sprite1.BackColor = System.Drawing.Color.Transparent;
            this.sprite1.BitmapScale = 1F;
            this.sprite1.BmpList = null;
            this.sprite1.Filename = "C:\\Users\\АТЕЦ\\source\\repos\\Animation\\New folder\\ball.bmp";
            this.sprite1.Flip = false;
            this.sprite1.ImageIndex = -1;
            this.sprite1.Location = new System.Drawing.Point(407, 262);
            this.sprite1.Name = "sprite1";
            this.sprite1.Size = new System.Drawing.Size(48, 48);
            this.sprite1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 585);
            this.Controls.Add(this.scenePanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.scenePanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Animation.ScenePanel scenePanel1;
        private Animation.Sprite sprite2;
        private Animation.Sprite sprite1;
        private System.Windows.Forms.Timer timer1;
    }
}

