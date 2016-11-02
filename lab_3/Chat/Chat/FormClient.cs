using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared;

namespace Chat
{
    public partial class FormClient : Form
    {

        /**
         * Don't take this code seriously, it's just a prototype 
         */

        private IServer server;
        private string myNick;
        private string myUrl;
        private int myPort;

        public FormClient()
        {
            InitializeComponent();
        }

        public void AddMessage(string message)
        {
            tbChat.Text += message + Environment.NewLine;
        }

        private void FormClient_Load(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            myPort = Int32.Parse(tbPort.Text);
            myNick = tbNick.Text;
            myUrl = String.Format("tcp://localhost:{0}/ClientRemoteObject", myPort);
            RegisterRemoteObject(myPort);
            RegisterOnServer(myNick, myUrl);
            btnConnect.Enabled = false;
        }

        private void RegisterRemoteObject(int myPort)
        {
            ClientRemoteObj.Client = new Client(this);
            TcpChannel channel = new TcpChannel(myPort);
            ChannelServices.RegisterChannel(channel, true);

            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(ClientRemoteObj),
                "ClientRemoteObject",
                WellKnownObjectMode.Singleton);
        }

        private void RegisterOnServer(string myNick, string myUrl)
        {
            server = (IServer)Activator.GetObject(
                typeof(ClientRemoteObj),
                "tcp://localhost:1992/ServerRemoteObject");
            server.AddClient(myNick, myUrl);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string msg = tbMessage.Text;
            AddMessage(BuildMesage(myNick, msg));
            server?.SendMessage(myNick, myUrl, msg);
        }

        private string BuildMesage(string clientNick, string msg)
        {
            return String.Format("<{0}>: {1}", clientNick, msg);
        }
    }
}
