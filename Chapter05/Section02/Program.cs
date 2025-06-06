namespace Section02 {
    internal class Program {
        static void Main(string[] args) {
            var appVar1 = new AppVersion(5, 1, 3);
            var appVar2 = new AppVersion(5, 1, 3);

            if (appVar1 == appVar2) {
                Console.WriteLine("等しい");
            } else {
                Console.WriteLine("等しくない");
            }
        }
    }

    public record AppVersion(int major, int minor, int build = 0, int revision = 0) {
        public int Major { get; init; } = major;
        public int Minor { get; init; } = minor;
        public int Build { get; init; } = build;
        public int Revision { get; init; } = revision;


        public override string ToString() =>
            $"{Major}.{Minor}.{Build}.{Revision}";

    }
}

