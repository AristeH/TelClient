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

class WindowListFieldsModel:ViewModel
    {
        #region заголовок окна
        /// <summary>Заголовок окна</summary>
        public WebsocketClient ws;
        private string _Title = "ws://127.0.0.1:8080/telephon";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
        #endregion
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
            ws.sendMessage(ws.sendmes);
        }
        public IList<shapka> ElementsShapka { get; set; } = new List<shapka>();
        public IList<ButtonsForm> ElementsButtonsForm { get; set; } = new List<ButtonsForm>();
        public WindowListFieldsModel()
        {
            wsSend = new LambdaCommand(onwsSendExecuted, CanwsSendExecute);

            ElementsShapka.Add(new shapka
            {
                Label = "Имя",
                EditBox = "Name",
                Flag = "11111"
            });
            ElementsShapka.Add(new shapka
            {
                Label = "Пароль",
                EditBox = "Password",
                Flag = "11111"
            });
            ElementsButtonsForm.Add(new ButtonsForm
            {
                Label = "Войти",
                type = "1"
            });
            ElementsButtonsForm.Add(new ButtonsForm
            {
                Label = "Отмена",
                type = "1"
            });

        }
    }
}
