using System.ComponentModel;
using System.Media;

namespace Animation
{
    public partial class Sound : Component
    {
        string soundFile = null;
        bool isPlaying = false;
        SoundPlayer soundP = new SoundPlayer();

        public Sound()
        {
            InitializeComponent();
        }

        public Sound(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        [EditorAttribute(typeof(System.Windows.Forms.Design.FileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string Filename
        {
            get { return soundFile; }
            set
            {
                if (value != null && value.Length > 0)
                {
                    soundFile = value;
                    soundP.SoundLocation = soundFile;
                    soundP.Load();
                }
            }
        }

        public void Play()
        {
            if (isPlaying == true)
                soundP.Stop();
            soundP.Play();
            isPlaying = true;
        }

        public void Stop()
        {
            if(isPlaying == true)
            {
                isPlaying = false;
                soundP.Stop();
            }
        }
    }
}
