using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    class ClientRemoteObj : MarshalByRefObject, IClient
    {
        private readonly IClient client;

        public ClientRemoteObj(IClient client)
        {
            this.client = client;
        }

        public void BroadcastMessage(string message)
        {
            client.BroadcastMessage(message);
        }

    }
}
