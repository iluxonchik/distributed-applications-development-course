using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Server
{
    class Program
    {
        public static readonly int PORT = 1992;
        public static bool DEBUG = true;

        static void Main(string[] args)
        {

            ServerRemoteObj.Server = new Server();

            TcpChannel channel = new TcpChannel(PORT);
            ChannelServices.RegisterChannel(channel, true);

            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(ServerRemoteObj), 
                "ServerRemoteObject", 
                WellKnownObjectMode.Singleton);

            Console.WriteLine("Press <Enter> to exit");
            Console.ReadLine();
        }

        public static void Debug(string msg)
        {
            if (DEBUG)
            {
                Console.WriteLine(msg);
            }
        }
    }
}
