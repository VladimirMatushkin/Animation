using System.ComponentModel;
using System.Media;

namespace Animation
{
    [Description("Represent the SoundPlayer control")]
    public partial class Sound : Component
    {
        private string _sourceFile = null;
        private bool _isPlaying = false;
        private SoundPlayer _soundPlayer = new SoundPlayer();

        public Sound()
        {
            InitializeComponent();
        }

        public Sound(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        /// <summary>
        /// This property represent a string that holds the path to the source sound.
        /// </summary>
        [
            Category("Sound"),
            Description("Path to the source sound file."),
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
                    _soundPlayer.SoundLocation = _sourceFile;
                    _soundPlayer.Load();
                }
            }
        }

        /// <summary>
        /// Starts playing the sound. 
        /// If it's already playing - start from the beginning.
        /// </summary>
        public void Play()
        {
            if (_isPlaying == true)
                _soundPlayer.Stop();
            _soundPlayer.Play();
            _isPlaying = true;
        }

        /// <summary>
        /// Stops playback.
        /// </summary>
        public void Stop()
        {
            if (_isPlaying == true)
            {
                _isPlaying = false;
                _soundPlayer.Stop();
            }
        }
    }
}
