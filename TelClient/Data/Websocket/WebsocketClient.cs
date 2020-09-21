using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocket4Net;
using TelClient;

namespace TelClient.Data
{
    class WebsocketClient
    {
        public WebSocket websocket;
        private bool is_connected = false;
        struct mess
        {
            public string action;
            public string[] parameters;
        }

        public void initWebSocketClient(String serverURL)
        {
            if (serverURL == "")
            {
                //   textBox2.Text += "Не задана строка подключения\n";
            }
            else
            {
                websocket = new WebSocket(serverURL);
                websocket.Closed += new EventHandler(websocket_Closed);
                websocket.Error += new EventHandler<SuperSocket.ClientEngine.ErrorEventArgs>(websocket_Error);
                websocket.MessageReceived += new EventHandler<MessageReceivedEventArgs>(websocket_MessageReceived);
                websocket.Opened += new EventHandler(websocket_Opened);
                websocket.Open();
            }
        }

        public void websocket_Opened(object sender, EventArgs e) 
        {
            is_connected = true;
          //  return "[Подключились]\n";
        }

        public void websocket_Error(object sender, SuperSocket.ClientEngine.ErrorEventArgs e)
        {
         //   return      "[ошибка] " + e.Exception.Message + "\n";
        }

        public void websocket_Closed(object sender, EventArgs e)
        {
            //return      "[отключились]\n";

        }

        // Получено сообщение необходимо обаработать его

        public void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        {


    //        window2 subwindow = new window2();
     //       subwindow.text = e.message;

    //        subwindow.loadorders(e.message);
//subwindow.show();

        }

        public void sendMessage()
        {
            if (is_connected)
            {
                mess tom = new mess();
                tom.action = "get";
                string[] arr = { "form:list", "object:login" };
                tom.parameters = arr;
                 websocket.Send("login");
           }
        }
    }
}
