using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.Music
{
    public class Music
    {
        public Music(string musicName, string musicUri)
        {
            MusicName = musicName.Contains(".")?musicName.Split('.')[0]:musicName;
            MusicUri = musicUri;
        }

        public string MusicName { get; set; }
        public string MusicUri { get; set; }
    }
}
