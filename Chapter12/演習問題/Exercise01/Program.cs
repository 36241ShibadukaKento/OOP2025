using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings;
using System.Xml;
using System.Xml.Serialization;
using System.Text.Encodings.Web;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var emp = new Employee {
                Id = 100,
                Name = "柴塚健斗",
                HireDate = new DateTime(2005, 7, 19)
            };
            var jsonString = Serialize(emp);
            Console.WriteLine(jsonString);
            var obj = Deserialize(jsonString);
            Console.WriteLine(obj);
        }


        static string Serialize(Employee emp) {
            var options = new JsonSerializerOptions {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            string jsonString = JsonSerializer.Serialize(emp, options);
            return JsonSerializer.Serialize(emp, options);
        }

    

        static Employee? Deserialize (string text) {
            var options = new JsonSerializerOptions {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            var novelist = JsonSerializer.Deserialize<Employee>(text,options);
            return novelist;
        }

        public record Employee {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime HireDate { get; set; }
        }
    }
}
