using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
