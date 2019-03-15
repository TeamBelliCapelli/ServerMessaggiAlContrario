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
    }
}
