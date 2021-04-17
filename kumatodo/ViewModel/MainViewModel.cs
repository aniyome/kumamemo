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

        // データロード完了フラグ
        private bool _isDataLoaded;

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
            AddMemoCommand = new Command<string>(
                                execute: (string arg) =>
                                {
                                    // メモを追加
                                    Memo memo = new Memo();
                                    memo.Text = _addMemoText;

                                    // 追加したメモを画面に反映
                                    Memos.Add(memo);

                                    //// 追加したメモを画面に反映
                                    //Memos = _memos;

                                    // テキストボックスを初期化
                                    AddMemoText = "";

                                    // TODO データベースに追加
                                    _memoStore.AddMemo(memo);
                                }
                            );
            // メモ削除ボタンのコマンド
            DeleteMemoCommand = new Command<string>(
                                execute: (string arg) =>
                                {
                                    // チェックされているものだけ絞り込む
                                    var query = Memos.Where(x => x.IsChecked == true).ToList();

                                    // チェックされているものだけを削除する
                                    foreach (Memo memo in query)
                                    {
                                        Memos.Remove(memo);
                                    }
                                }
                            );
        }

        /// <summary>
        /// メモ一覧
        /// </summary>
        public ObservableCollection<Memo> Memos { get; private set; } = new ObservableCollection<Memo>();

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
        private async Task LoadData()
        {
            //if (_isDataLoaded)
            //    return;

            _isDataLoaded = true;
            var memos = await _memoStore.GetMemosAsync();

            foreach (Memo m in memos)
            {
                Memos.Add(m);
            }
            Console.WriteLine("LoadData");
        }
    }
}
