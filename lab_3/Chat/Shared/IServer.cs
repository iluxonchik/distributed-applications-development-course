using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IServer
    {
        void SendMessage(string clientNick, string clientUrl, string message);
        void AddClient(string nick, string clientUrl);
    }
}
