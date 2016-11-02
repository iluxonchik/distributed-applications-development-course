using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Chat
{
    class Client : IClient
    {
        private readonly FormClient form;

        public Client(FormClient form)
        {
            this.form = form;
        }

        public void BroadcastMessage(string message)
        {
            form.Invoke(new Action(() => form.AddMessage(message)));
        }
    }
}
