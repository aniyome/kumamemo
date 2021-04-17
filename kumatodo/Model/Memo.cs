using System;
using SQLite;

namespace kumatodo.Model
{
    public class Memo
    {
        [PrimaryKey, AutoIncrement]
        // ID
        public int ID { get; set; }

        // 入力内容
        public string Text { get; set; }

        // 作成日時
        public DateTime Created { get; set; } = DateTime.Now;

        // 選択済み
        public bool IsChecked { get; set; } = false;

        // 表示用作成日時
        public string DisplayCreated => Created.ToString("yyyy/MM/dd");
    }
}
