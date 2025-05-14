using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {   //2 .1 .1

    public class Song {
        public String Title { get; set; } = String.Empty;
        public String ArtistName { get; set; } = string.Empty;
        public int Length { get; set; }

        //2 .1 .2
        public Song(String Title, String ArtistName, int Length) {

            this.Title = Title;
            this.ArtistName = ArtistName;
            this.Length = Length;

        }
        public Song() {

        }
    }
}
