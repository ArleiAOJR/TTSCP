using System;
using NUnit.Framework;

namespace WebServiceTest
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void autenticaMembroTest_Success()
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            bool result = cliente.autenticaMembro("arlei.aojr@gmail.com", "123");
            Assert.AreEqual(true, result);
        }

        [Test]
        public void autenticaMembroTest_Fail()
        {
            WSAppTTSCP.WSAppTTSCPSoapClient cliente = new WSAppTTSCP.WSAppTTSCPSoapClient();
            bool result = cliente.autenticaMembro("arlei.aojr@gmail.com", "");
            Assert.AreNotEqual(true, result);

            result = cliente.autenticaMembro("", "");
            Assert.AreNotEqual(true, result);
        }

    }
}
