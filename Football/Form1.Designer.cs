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
            this.scenePanel2 = new Animation.ScenePanel();
            this.sprite1 = new Animation.Sprite();
            this.sprite2 = new Animation.Sprite();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.scenePanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // scenePanel2
            // 
            this.scenePanel2.Controls.Add(this.sprite1);
            this.scenePanel2.Controls.Add(this.sprite2);
            this.scenePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scenePanel2.Location = new System.Drawing.Point(0, 0);
            this.scenePanel2.Name = "scenePanel2";
            this.scenePanel2.Size = new System.Drawing.Size(920, 585);
            this.scenePanel2.SourceFile = "C:\\Users\\АТЕЦ\\source\\repos\\Animation\\Football\\New folder\\field.jpg";
            this.scenePanel2.TabIndex = 0;
            // 
            // sprite1
            // 
            this.sprite1.Angle = 0F;
            this.sprite1.BackColor = System.Drawing.Color.Transparent;
            this.sprite1.FlipX = false;
            this.sprite1.FlipY = false;
            this.sprite1.ImageListIndex = 0;
            this.sprite1.ImgList = null;
            this.sprite1.Location = new System.Drawing.Point(429, 259);
            this.sprite1.Name = "sprite1";
            this.sprite1.ScaleX = 1F;
            this.sprite1.ScaleY = 1F;
            this.sprite1.Size = new System.Drawing.Size(64, 64);
            this.sprite1.SourceFile = "C:\\Users\\АТЕЦ\\source\\repos\\Animation\\Football\\New folder\\soccer-ball.png";
            this.sprite1.TabIndex = 1;
            // 
            // sprite2
            // 
            this.sprite2.Angle = 0F;
            this.sprite2.BackColor = System.Drawing.Color.Transparent;
            this.sprite2.FlipX = false;
            this.sprite2.FlipY = false;
            this.sprite2.ImageListIndex = 0;
            this.sprite2.ImgList = null;
            this.sprite2.Location = new System.Drawing.Point(123, 215);
            this.sprite2.Name = "sprite2";
            this.sprite2.ScaleX = 1F;
            this.sprite2.ScaleY = 1F;
            this.sprite2.Size = new System.Drawing.Size(99, 138);
            this.sprite2.SourceFile = "C:\\Users\\АТЕЦ\\source\\repos\\Animation\\Football\\New folder\\220px-Scratch_Cat.png";
            this.sprite2.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(920, 585);
            this.Controls.Add(this.scenePanel2);
            this.Name = "Form1";
            this.Text = "Football";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.scenePanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Animation.ScenePanel scenePanel2;
        private Animation.Sprite sprite1;
        private Animation.Sprite sprite2;
        private System.Windows.Forms.Timer timer1;
    }
}

