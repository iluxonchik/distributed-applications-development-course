using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ServerRemoteObj : MarshalByRefObject, IServer
    {
        public static IServer Server { get; set; }

        public void AddClient(string nick, string clientUrl)
        {
            Server.AddClient(nick, clientUrl);
        }

        public void SendMessage(string clientNick, string clientUrl, string message)
        {
            Server.SendMessage(clientNick, clientUrl, message);
        }
    }
}
