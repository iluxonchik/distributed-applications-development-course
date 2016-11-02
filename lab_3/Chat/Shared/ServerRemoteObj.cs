using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ServerRemoteObj : MarshalByRefObject, IServer
    {
        static IServer server;

        public void AddClient(string nick, string clientUrl)
        {
            server.AddClient(nick, clientUrl);
        }

        public void SendMessage(string clientNick, string clientUrl, string message)
        {
            server.SendMessage(clientNick, clientUrl, message);
        }
    }
}
