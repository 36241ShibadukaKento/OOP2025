namespace Test01 {
    public class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);

        }

        //メソッドの概要： 
        private static IEnumerable<Student> ReadScore(string filePath) {
            //var student = new List<Student>();
            //var lines = File.ReadAllLines(filePath);

            //foreach (var line in lines) {
            //    String[] items = line.Split(',');
            //    var score = new Student() {
            //        Name = items[0],
            //        Subject = items[1],
            //        Score = int.Parse(items[2])
            //    };
            // student.Add(score);
            //}
            // return student;
        }

        //メソッドの概要： 
        public IDictionary<string, int> GetPerStudentScore() {

            var dict = new SortedDictionary<string, int>();
            foreach (var student in _score) {
                if (dict.ContainsKey(student.Name)) {
                    //          dict[student.Name] += student.Subject;
                } else { 
                    dict[student.Name] = student.Score;
            }
            return dict;
        }
    }
    }
}
