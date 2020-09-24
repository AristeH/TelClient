using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TelClient.Data;
using TelClient.Infrastructure;
using TelClient.Infrastructure.Commands;
using TelClient.ViewModels.Base;
using TelClient.Models.Decanat;
using System.Linq;
using TelClient.Models.Interfaces;

namespace TelClient.ViewModels
{
    class MainWindowViewModel:ViewModel
    {
       public ObservableCollection<Group> Groups { get; set; }

        private Group _SelectedGroup;
        public Group SelectedGroup {
            get => _SelectedGroup;
            set => Set(ref _SelectedGroup, value);
        }


        #region заголовок окна
        /// <summary>Заголовок окна</summary>
        public WebsocketClient ws;
        private string _Title = "Телефоны";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion
        #region команды
        public ICommand CloseApplicationCommand { get; }
        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void onCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();

        }
        public ICommand wsConnect { get; }
        private bool CanwsConnectExecute(object p) => true;
        private void onwsConnectExecuted(object p)
        {
            ws = new WebsocketClient();
            ws.initWebSocketClient("ws://127.0.0.1:8080/telephon");

        }

        public ICommand wsSend { get; }
        private bool CanwsSendExecute(object p) => true;
        private void onwsSendExecuted(object p)
        {
            ws.sendmes.Sender = "client";
            ws.sendmes.Recipient = "Server";
            ws.sendmes.Action = "getform";
            ws.sendmes.Content = "Login";
            string[] arr = { "list", "login" };
            ws.sendmes.parameters = arr;
            ws.sendMessage(ws.sendmes) ;
        }
        #endregion
        public IList<shapka> ElementsShapka { get; set; } = new List<shapka>();
        public MainWindowViewModel()
        {
            CloseApplicationCommand = new LambdaCommand(onCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            wsConnect = new LambdaCommand(onwsConnectExecuted, CanwsConnectExecute);
            wsSend    = new LambdaCommand(onwsSendExecuted, CanwsSendExecute);
            var student_index = 1;
            var students = Enumerable.Range(1, 10).Select(i => new Student
            {
                Name = $"Имя{student_index}",
                Surname = $"Фамилия{student_index++}"
            });
            var groups = Enumerable.Range(1, 20).Select(i => new Group
            {
                Name = $"Группа {i}",
                Students = new ObservableCollection<Student>(students)
            });
            Groups = new ObservableCollection<Group>(groups);

            
            ElementsShapka.Add(new shapka
            {
                Label = "Имя",
                EditBox = "Name",
                Flag  = "11111"
            });
            ElementsShapka.Add(new shapka
            {
                Label = "Пароль",
                EditBox = "Password",
                Flag = "11111"
            });


        }
    }
}
