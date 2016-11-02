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
        }

        public void SendMessage(string clientNick, string clientUrl, string message)
        {
            // contact client with message
        }
    }
}
