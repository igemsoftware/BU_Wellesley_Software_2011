using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.IO;
using System.IO.Packaging;
using System.Windows.Resources;

namespace GnomeSurferPro.Util
{
    public class DeleteSound
    {
        private const string Source = "/Resources/audio/delete.wav";

        private SoundPlayer _player;

        public DeleteSound()
        {
            Uri audioUri = new Uri(Source, UriKind.Relative);
            StreamResourceInfo info = App.GetContentStream(audioUri);
            Stream audioStream = info.Stream;
            _player = new SoundPlayer(audioStream);
        }

        public void Play()
        {
            _player.Play();
        }
    }
}
