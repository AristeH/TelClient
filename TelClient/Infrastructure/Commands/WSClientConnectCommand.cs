using System;
using System.Collections.Generic;
using System.Text;
using TelClient.Data;
using TelClient.Infrastructure.Commands.Base;
using System.Windows;


namespace TelClient.Infrastructure.Commands
{
    class WSClientConnectCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;

            WebsocketClient ws = new WebsocketClient();
            ws.initWebSocketClient("ws://127.0.0.1:8080/telephon");
        }
    }
}
