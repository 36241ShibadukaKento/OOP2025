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
        public int Name { get; set; }

        /// <summary>
        /// 電話番号
        /// </summary>
        public int Phone { get; set; }

        /// <summary>
        /// 住所
        /// </summary>
        public int Address { get; set; }

        /// <summary>
        /// 画像
        /// </summary>
        public byte[] Picture { get; set; }

    }
}
