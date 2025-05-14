namespace Exercise01 {
    public class Program {
        static void Main(string[] args) {
            //2 .1 .3
            var SongList = new List<Song>();
            Console.WriteLine("--曲の登録--");
            while (true) {
                Console.Write("曲名 : ");
                String ? title = Console.ReadLine();
                if (title.Equals("end",StringComparison.OrdinalIgnoreCase)) {
                    break;
                }

                Console.Write("アーティスト名 : ");
                String? ArtistName = Console.ReadLine();

                Console.Write("演奏時間(秒) : ");
                int Length = int.Parse(Console.ReadLine());

                var song = new Song() {
                    Title = title,
                    ArtistName = ArtistName,
                    Length = Length,
                };
                SongList.Add(song);
                
                }
            printSongs(SongList);
        
        }
        //2 .1 .4
        private static void printSongs(List<Song> songs) {
            // for文を用いる方法 
            // for (int cnt = 0; cnt < songs.Length; cnt++)  {
            Console.WriteLine("--登録曲一覧--");
            foreach (var song in songs) {

            //                 TimeSpan.変換元の単位 ( 引数 )   .ToString ( 書式設定 );
                var timespan = TimeSpan.FromSeconds(song.Length).ToString ( @"mm\:ss" );
                Console.WriteLine($"Title : {song.Title},   Artist : {song.ArtistName},   PlayTime : {timespan}");

            }  
        }
    }
}
