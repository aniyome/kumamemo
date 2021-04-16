using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using kumatodo.Model;
using Xamarin.Forms;

namespace kumatodo.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// メモ一覧
        /// </summary>
        private ObservableCollection<Memo> _memos = new ObservableCollection<Memo>() {};

        /// <summary>
        /// メモへの入力フォーム内容
        /// </summary>
        private string _addMemoText = "";

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainViewModel()
        {
            // メモ追加ボタンのコマンド
            AddMemoCommand = new Command<string>(
                                execute: (string arg) =>
                                {
                                    // メモを追加
                                    _memos.Add(new Memo(_addMemoText));
                                    // 追加したメモを画面に反映
                                    Memos = _memos;
                                    // テキストボックスを初期化
                                    AddMemoText = "";
                                }
                            );
            // メモ削除ボタンのコマンド
            DeleteMemoCommand = new Command<string>(
                                execute: (string arg) =>
                                {
                                    // チェックされていないものだけ絞り込む
                                    var query = _memos.Where(x => x.IsChecked != true);
                                    // 再生成後のObservableCollectionを定義
                                    ObservableCollection<Memo> memos = new ObservableCollection<Memo>() { };
                                    // 絞り込んだ要素でメモを再生成
                                    foreach (Memo i in query)
                                    {
                                        memos.Add(i);
                                    }
                                    // 生成したリストを画面に反映させる
                                    Memos = memos;
                                }
                            );
        }

        /// <summary>
        /// メモ一覧
        /// </summary>
        public ObservableCollection<Memo> Memos
        {
            get { return _memos; }
            set
            {
                _memos = value;
                OnPropertyChanged(nameof(Memos));
            }
        }

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

        /// <summary>
        /// メモ追加
        /// </summary>
        public ICommand AddMemoCommand { get; }

        /// <summary>
        /// メモ削除
        /// </summary>
        public ICommand DeleteMemoCommand { get; }
    }
}
