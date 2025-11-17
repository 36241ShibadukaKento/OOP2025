using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileProcessorDI {
    public class TextFileProcessor {
        private ITextFileService _servise;

        //コンストラクタ
        public TextFileProcessor(ITextFileService servise) {
            _servise = servise;
        }

        public void Run(string fileName) {
            _servise.Initialize(fileName);

            var lines = File.ReadLines(fileName);
            foreach (var line in lines) {
                _servise.Excute(line);
            }
            _servise.Terminate();
        }
    }
}
