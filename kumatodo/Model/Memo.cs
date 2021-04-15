using System;
namespace kumatodo.Model
{
    public class Memo
    {
        // コンストラクタ
        public Memo(string text)
        {
            Text = text;
        }

        // 入力内容
        public string Text { get; set; }

        // 完了 or 未完了
        public bool Done { get; set; }

        // 作成日時
        public DateTime Created { get; set; }
    }
}
