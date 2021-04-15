using System;
using System.ComponentModel;

namespace kumatodo.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// プロパティの変更があった時に発行される
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// PropertyChangedイベントを発行する
        /// </summary>
        /// <param name="propertyName">Property name</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
