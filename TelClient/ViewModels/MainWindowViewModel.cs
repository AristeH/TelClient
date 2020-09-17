using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TelClient.Infrastructure;
using TelClient.Infrastructure.Commands;
using TelClient.ViewModels.Base;


namespace TelClient.ViewModels
{

    class MainWindowViewModel:ViewModel
    {
        #region заголовок окна
        /// <summary>Заголовок окна</summary>

        private string _Title = "Телефоны";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion

        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void onCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();

        }
        
        public MainWindowViewModel()
        {
            CloseApplicationCommand = new LambdaCommand(onCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);

        }
    }
}
