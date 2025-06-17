﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test01 {
    public class Student {
        //学生の名前
        public string Name { get; private set; } = String.Empty;
        //科目名
        public string Subject { get; private set; } = String.Empty;
        //点数
        public int Score { get; private set; }

        public Student (string name ,string sub ,int score) {
            Name = name;
            Subject = sub;
            Score = score;
        }

    }
}
