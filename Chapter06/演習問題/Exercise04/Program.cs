﻿using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";

            var array = line.Split(";");
            foreach(var pair in line.Split(";")){
                var word = pair.Split("=");
                Console.WriteLine($"{ToJapanese(word[0])}:{word[1]}");
            }
        }

        /// <summary>
        /// 引数の単語を日本語へ変換します
        /// </summary>
        /// <param name="key">"Novelist","BestWork","Born"</param>
        /// <returns>"「作家」,「代表作」,「誕生年」</returns>
        static string ToJapanese(string key) {

            var returnText = key switch {
                "Novelist" => "作家",
                "BestWork" => "代表作",
                "Born" => "誕生年",
                _ => "引数が正しくありません"
            };
            return returnText;

            //    switch (key) {
            //        case "Novelist":
            //            return ("作家 : ");
            //        case "BestWork":
            //            return ("代表作 : ");
            //        case "Born":
            //            return ("誕生年 : ");
            //    } return "引数が正しくありません";
            //   

        }
    }
}