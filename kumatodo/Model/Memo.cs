using System;
namespace kumatodo.Model
{
    public class Memo
    {
        // コンストラクタ
        public Memo(string text)
        {
            Text = text;
            Created = DateTime.Now;
        }

        // 入力内容
        public string Text { get; set; }

        // 完了 or 未完了
        public bool Done { get; set; }

        // 作成日時
        public DateTime Created { get; set; }

        // 表示用作成日時
        public string DisplayCreated => Created.ToString("yyyy/MM/dd");
    }
}
