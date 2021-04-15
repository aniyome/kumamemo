using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using kumatodo.Model;

namespace kumatodo.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// メモ一覧
        /// </summary>
        private List<Memo> _memos = new List<Memo>() {
            new Memo("ここに文字が表示されます。"),
            new Memo("ここに文字が表示されます。"),
            new Memo("ここに文字が表示されます。"),
            new Memo("ここに文字が表示されます。"),
            new Memo("ここに文字が表示されます。"),
            new Memo("ここに文字が表示されます。"),
            new Memo("ここに文字が表示されます。"),
            new Memo("ここに文字が表示されます。"),
            new Memo("ここに文字が表示されます。"),
            new Memo("ここに文字が表示されます。"),
            new Memo("ここに文字が表示されます。"),
            new Memo("ここに文字が表示されます。"),
            new Memo("ここに文字が表示されます。"),
            new Memo("ここに文字が表示されます。"),
            new Memo("ここに文字が表示されます。"),
            new Memo("ここに文字が表示されます。"),
            new Memo("リスト形式で表示されます。")
        };

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainViewModel()
        {
        }

        /// <summary>
        /// メモ一覧
        /// </summary>
        public List<Memo> Memos
        {
            get { return _memos; }
            set
            {
                _memos = value;
                this.OnPropertyChanged(nameof(Memos));
            }
        }
    }
}
