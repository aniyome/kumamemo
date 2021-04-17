using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kumatodo.Persistence;
using kumatodo.ViewModel;
using Xamarin.Forms;

namespace kumatodo
{
    public partial class MainPage : ContentPage
    {
        MainViewModel vm;

        public MainPage()
        {
            var memoStore = new SQLiteMemoStore(DependencyService.Get<ISQLiteDb>());

            vm = new MainViewModel(memoStore);

            // ViewModelをViewにDataBindingする
            BindingContext = new MainViewModel(memoStore);

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            vm.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }
    }
}
