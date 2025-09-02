
using System.Text.RegularExpressions;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            //True
            Console.WriteLine(IsPhoneNumber("080-0911-1234"));
            Console.WriteLine(IsPhoneNumber("090-0911-1234"));
            //False
            Console.WriteLine(IsPhoneNumber("080-0911-12T4"));
            Console.WriteLine(IsPhoneNumber("190-0911-1234"));
            Console.WriteLine(IsPhoneNumber("091-0911-1234"));
            Console.WriteLine(IsPhoneNumber("A090-0911-1234"));
            Console.WriteLine(IsPhoneNumber("090-911-1234"));
            Console.WriteLine(IsPhoneNumber("0900-1911-123"));
            Console.WriteLine(IsPhoneNumber("090-1911-12345"));

        }

        private static bool IsPhoneNumber(string telNum) {
            return Regex.IsMatch(telNum, @"^0[789]0-\d{4}-\d{4}$");
        }
    }
}
