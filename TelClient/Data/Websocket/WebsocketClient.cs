using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebSocket4Net;
using TelClient;
using Newtonsoft.Json;

namespace TelClient.Data
{
    public struct mess
        {
            public string Sender; 
            public string Recipient;
            public string Content;
            public string Action;
            public string[] parameters;
        }
    class WebsocketClient
    {
        public WebSocket websocket;
        public bool is_connected = false;
        public bool is_enabled = true;

        public mess sendmes = new mess(); 
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
            is_enabled = false;
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

        public void sendMessage(mess Message)
        {
            if (is_connected)
            {
                string json = JsonConvert.SerializeObject(Message);
                websocket.Send(json);
           }
        }
    }
}
