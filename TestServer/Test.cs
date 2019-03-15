using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ServerMessaggiBaseAlContrario.Test
{ 
    class Test
    {
        FakeTransport transport;
        Server server;

        [SetUp]
        public void SetUpTest()
        {
            transport = new FakeTransport();
            server = new Server(transport);
        }

        [Test]
        public void TestEmptyStart()
        {
            Assert.That(() => transport.ClientDequeue(), Throws.InstanceOf<InvalidOperationException>());
        }

        [Test]
        public void TestEmptyMessage()
        {
            Packet Emessage = new Packet(Encoding.UTF8.GetBytes(""));
            transport.ClientEnqueue(Emessage, "Samba", 99);

            server.SingleStep();

            string message = Encoding.UTF8.GetString(transport.ClientDequeue().data);

            Assert.That(message, Is.EqualTo(""));
        }

        [Test]
        public void TestMessage()
        {
            Packet Emessage = new Packet(Encoding.UTF8.GetBytes("Try"));
            transport.ClientEnqueue(Emessage, "Samba", 99);

            server.SingleStep();

            string message = Encoding.UTF8.GetString(transport.ClientDequeue().data);

            Assert.That(message, Is.EqualTo("yrT"));
        }
    }
}
