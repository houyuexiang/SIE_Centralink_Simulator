using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Simulator.ClassLib
{
    class TCPConnect
    {
        string Connecttype, Hostipaddress, Orderport, Resultport;
        Boolean Connectstatue_O, Connectstatue_R,Stop;
        public SocketClient client_O,client_R;
        public SocketServer Server;
        private Thread statuethread;

        public String ConnectType
        {
            get
            {
                return Connecttype;
            }
            set
            {
                Connecttype = value;
            }
        }
        public Boolean ConnectStatue_O
        {
            get
            {
                return Connectstatue_O;
            }
        }
        public Boolean ConnectStatue_R
        {
            get
            {
                return Connectstatue_R;
            }
        }
        public string HostIpaddress
        {
            get
            {
                return Hostipaddress;
            }
            set
            {
                Hostipaddress = value;
            }
        }
        public string OrderPort
        {
            get
            {
                return Orderport;
            }
            set
            {
                Orderport = value;
            }
        }
        public string ResultPort
        {
            get
            {
                return Resultport;
            }
            set
            {
                Resultport = value;
            }
        }

        public int TCPConnectInit()
        {
            this.Stop = false;
            if (this.Connecttype == "S")
            {
                this.Server = new SocketServer();
                if (this.Server.initport(Convert.ToInt32(this.Orderport)))
                {
                    this.Connectstatue_O = true;
                }
                else
                {
                    this.Connectstatue_O = false;
                }

            }
            else
            {
                this.client_O = new SocketClient(this.Hostipaddress, Convert.ToInt32(this.Orderport));
                if (this.Orderport != this.Resultport)
                {
                    this.client_R = new SocketClient(this.Hostipaddress, Convert.ToInt32(this.Resultport));
                }
                else
                {
                    this.client_R = this.client_O;
                }
            }
            this.statuethread = new Thread(new ThreadStart(ConnectStatueRefreshThread));
            this.statuethread.IsBackground = true;
            statuethread.Start();
            
            return 0;
        }
        public void CloseConnect()
        {
            this.Stop = true;
            if (this.Connecttype == "S")
            {
                
                this.Server.TCPClose();
                this.Connectstatue_O = false;
            }
            else
            {
                if (this.client_O == this.client_R)
                {
                    this.client_O.TCPClose();
                }
                else
                {
                    this.client_O.TCPClose();
                    this.client_R.TCPClose();
                }
                this.Connectstatue_O = false;
                this.Connectstatue_R = false;
            }
        }
        public void ConnectStatueRefreshThread()
        {
            while(!Stop)
            {
                if (this.Connecttype == "S")
                {
                    this.Connectstatue_O = this.Server.tcpconnect;
                }
                else
                {
                    this.Connectstatue_O = this.client_O.BConnectStatue;
                    this.Connectstatue_R = this.client_R.BConnectStatue;
                }
                Thread.Sleep(10);
            }
        }

    }
}
