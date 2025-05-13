namespace Exercise01 {
    public class Program {
        static void Main(string[] args) {
            //2 .1 .3
            var songs = new Song[] {
                new Song("Let it be", "The Beatles", 243),
                new Song("Bridge Over Troubled Water", "Simon & Garfunkel", 293),
                new Song("Close To You", "Carpenters", 276),
                new Song("Honesty", "Billy Joel", 231),
            　  new Song("I Will Always Love You", "Whitney Houston", 273),
            };
            printSongs(songs);
        }
        //2 .1 .4
        private static void printSongs(Song[] songs) {
            // for文を用いる方法 
            // for (int cnt = 0; cnt < songs.Length; cnt++)  {
            foreach (var song in songs) {

            //                 TimeSpan.変換元の単位 ( 引数 )   .ToString ( 書式設定 );
                var timespan = TimeSpan.FromSeconds(song.Length).ToString ( @"m\:ss" );
                Console.WriteLine($"Title : {song.Title},   Artist : {song.ArtistName},   PlayTime : {timespan}");

            }  
        }
    }
}
