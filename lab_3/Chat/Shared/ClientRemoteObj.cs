using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ClientRemoteObj : MarshalByRefObject, IClient
    {
        public static IClient Client { get; set; }

        public void BroadcastMessage(string message)
        {
            Client.BroadcastMessage(message);
        }

    }
}
