﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.ClassLib
{
    interface Connect
    {
        int TcpSend(string message);
        string TcpRead();
        Boolean Canwrite
        {
            get;
        }
        void TCPClose();
        void LOG(string msg,string type);
    }
}
