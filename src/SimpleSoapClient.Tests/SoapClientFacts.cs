using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using SimpleSOAPClient;
using SimpleSOAPClient.Helpers;
using SimpleSOAPClient.Models;
using Xunit;

namespace SimpleSoapClient.Tests
{
    public class SoapClientFacts
    {
        [Fact]
        public async Task SameSoapClientDifferentUrls()
        {
            const string actionName = "http://tessiturasoftware.com/GetNewSessionKeyEx";

            var soapClient = SoapClient.Prepare();

            var url1 = "http://gateway.cincyplay.com/webservice_test/tessitura.asmx";
            var url2 = "http://tnewapi.tessituranetworkramp.com/TNEW5API/tessitura.asmx";

            var soapEnvelope = SoapEnvelope.Prepare().Body(new GetNewSessionKeyExRequestBody() { iBusinessUnit = 1, sIP = string.Empty});
            var response1 = await soapClient.SendAsync(url1, actionName, soapEnvelope, CancellationToken.None);
            var response2 = await soapClient.SendAsync(url2, actionName, soapEnvelope, CancellationToken.None);
        }

        [XmlRoot("GetNewSessionKeyEx", Namespace = "http://tessiturasoftware.com/")]
        public class GetNewSessionKeyExRequestBody
        {
            public string sIP { get; set; }
            public int iBusinessUnit { get; set; }
        }

        [XmlRoot("GetNewSessionKeyExResponse", Namespace = "http://tessiturasoftware.com/")]
        public class GetNewSessionKeyExResponseBody
        {
            [XmlElement("GetNewSessionKeyExResult")]
            public string GetNewSessionKeyExResult { get; set; }
        }
    }
}