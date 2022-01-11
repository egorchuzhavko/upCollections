using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z4
{
    internal class Signer
    {
        public string name;
        public List<string> songs;

        public Signer(string name, List<string> songs)
        {
            this.name = name;
            this.songs = songs;
        }

        public Signer(string name, string song)
        {
            this.name = name;
            List<string> vs = new List<string>();
            vs.Add(song);
            this.songs = vs;
        }
    }
}
