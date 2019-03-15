﻿using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerMessaggiBaseAlContrario
{
    public interface Itransport
    {
        void Bind(string address, int port);
        bool Send(byte[] data, EndPoint endPoint);
        byte[] Recv(int bufferSize, ref EndPoint sender);
        EndPoint CreateEndPoint();
    }
}
