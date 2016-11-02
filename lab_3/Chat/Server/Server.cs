using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Server : IServer
    {
        private Dictionary<string, string> clients = new Dictionary<string, string>();

        public void AddClient(string nick, string clientUrl)
        {
            clients.Add(nick, clientUrl);
            Console.WriteLine("{0}: {1} joined the chat", nick, clientUrl);
        }

        public void SendMessage(string clientNick, string clientUrl, string message)
        {
            Program.Debug(string.Format("Sending message {0} from client {1}:{2}", message, clientNick, clientUrl));
            string msg;
            foreach(string nick in clients.Keys)
            {
                string url = clients[nick];
                if (nick == clientNick)
                {
                    // don't broadcast the message to the client that sent it to you,
                    // otherwise the program will freeze (loop calls)
                    Program.Debug(string.Format("\tSkipping client {0}:{1}", nick, url));
                    continue;
                }
                Program.Debug(string.Format("\tBroadcasting message to client {0}:{1}", nick, url));
                msg = BuildMesage(nick, message);
                SendMessageToClient(url, msg);
            }
        }

        private void SendMessageToClient(string clientUrl, string message)
        {
            Program.Debug(string.Format("\t\tSending message {0} to client {1}", message, clientUrl));
            ClientRemoteObj client = (ClientRemoteObj)Activator.GetObject(typeof(ClientRemoteObj), clientUrl);
            try
            {
                client.BroadcastMessage(message);
            } catch(Exception e)
            {
                Console.WriteLine("[ERROR!] Something went wrong when sending the message to client at {0}", clientUrl);
            }
        }

        private string BuildMesage(string clientNick, string msg)
        {
            return String.Format("<{0}>: {1}", clientNick, msg);
        }
    }
}
