using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using kumatodo.Persistence;
using kumatodo.Model;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace kumatodo.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        // メモデータ用ストア
        private readonly IMemoStore _memoStore;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainViewModel(IMemoStore memoStore)
        {
            // メモデータ用のストア
            _memoStore = memoStore;

            // データロードのコマンド
            LoadDataCommand = new Command(async () => await LoadData());

            // メモ追加ボタンのコマンド
            AddMemoCommand = new Command(() => AddMemo());

            // メモ削除ボタンのコマンド
            DeleteMemoCommand = new Command(() => DeleteMemo());
        }

        /// <summary>
        /// メモ一覧
        /// </summary>
        public ObservableCollection<Memo> MemoList { get; private set; } = new ObservableCollection<Memo>();

        /// <summary>
        /// Entryへの入力内容
        /// </summary>
        public string AddMemoText
        {

            get { return _addMemoText; }
            set
            {
                _addMemoText = value;
                OnPropertyChanged(nameof(AddMemoText));
            }
        }
        private string _addMemoText = "";

        /// <summary>
        /// メモ追加
        /// </summary>
        public ICommand AddMemoCommand { get; }

        /// <summary>
        /// メモ削除
        /// </summary>
        public ICommand DeleteMemoCommand { get; }

        /// <summary>
        /// データロード
        /// </summary>
        public ICommand LoadDataCommand { get; private set; }

        /// <summary>
        /// 初期表示データロード
        /// </summary>
        /// <returns></returns>
        public async Task LoadData()
        {
            // メモデータを全件取得
            var memos = await _memoStore.GetMemosAsync();

            foreach (Memo m in memos)
            {
                MemoList.Add(m);
            }
        }

        /// <summary>
        /// メモ追加
        /// </summary>
        public void AddMemo()
        {
            // メモを追加
            Memo memo = new Memo();
            memo.Text = _addMemoText;

            // 追加したメモを画面に反映
            MemoList.Add(memo);

            // テキストボックスを初期化
            AddMemoText = "";
        }

        /// <summary>
        /// メモ削除
        /// </summary>
        public void DeleteMemo()
        {
            // チェックされているものだけ絞り込む
            var query = MemoList.Where(x => x.IsChecked == true).ToList();

            // チェックされているものだけを削除する
            foreach (Memo memo in query)
            {
                MemoList.Remove(memo);
            }
        }
    }
}
