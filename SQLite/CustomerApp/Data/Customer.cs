using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Data {
    internal class Customer {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// 名前
        /// </summary>
        public String Name { get; set; } = string.Empty;

        /// <summary>
        /// 電話番号
        /// </summary>
        public String Phone { get; set; } = string.Empty;

        /// <summary>
        /// 住所
        /// </summary>
        public String Address { get; set; } = string.Empty;

        /// <summary>
        /// 画像
        /// </summary>
        public byte[] Picture { get; set; }

    }
}
