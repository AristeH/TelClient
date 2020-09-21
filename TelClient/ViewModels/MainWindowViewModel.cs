﻿using System;
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

namespace TelClient.ViewModels
{
   

    class MainWindowViewModel:ViewModel
    {
       public ObservableCollection<Group> Groups { get; set; }
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
            ws.initWebSocketClient("ws://127.0.0.1:8080/telephon"); ;
        }

        public ICommand wsSend { get; }
        private bool CanwsSendExecute(object p) => true;
        private void onwsSendExecuted(object p)
        {
            
            ws.sendMessage() ;
        }
        #endregion








        public MainWindowViewModel()
        {
            CloseApplicationCommand = new LambdaCommand(onCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            wsConnect = new LambdaCommand(onwsConnectExecuted, CanwsConnectExecute);
            wsSend = new LambdaCommand(onwsSendExecuted, CanwsSendExecute);
            var student_index = 1;
            var students = Enumerable.Range(1, 10).Select(i => new Student
            {
                Name = $"kkkkkk{student_index}",
                Surname = $"eeeeee{student_index}"
            });
            var groups = Enumerable.Range(1, 20).Select(i => new Group
            {
                Name = $"kkkkkk{i}",
                Students = new ObservableCollection<Student>(students)
            });


            Groups = new ObservableCollection<Group>(groups);




        }
    }
}
