using System;
using System.Collections.Generic;

namespace kumatodo.Model
{
    public class MemoItems
    {
        // コンストラクタ
        public MemoItems()
        {
            Memos = new List<Memo>() { new Memo("ここに文字が表示されます。"), new Memo("リスト形式で表示されます。") };
        }

        // メモリスト
        public List<Memo> Memos { get; set; }
    }
}
