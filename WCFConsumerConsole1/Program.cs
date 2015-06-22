using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Added using
using System.Net;       // WebRequest, HttpWebResponse, HttpStatusCode
using System.IO;      // Stream, StreamReader

namespace WCFConsumerConsole1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This console app demonstrates the consumation of WCFServiceLibrary2");

            WebRequest req = WebRequest.Create(@"http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary2/Service1/5");
            req.Method = "GET";

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;

            if (resp.StatusCode == HttpStatusCode.OK)
            {
                using (Stream respStream = resp.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(respStream, Encoding.UTF8);
                    Console.WriteLine(reader.ReadToEnd());
                }             
            }     
            
        }
    }
}
