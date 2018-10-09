using System;
using System.Collections.Generic;
using System.Text;

namespace MeditecCross.Helpers
{
    public class Constants
    {
        static internal class CONN
        {
            const string NAME = "MeditecWS";
            const string PROTOCOL = "http://";
            //const string ADDRESS = "172.20.159.19";
            const string ADDRESS = "192.168.137.1";
            const int PORT = 8080;
            const string RESOURCES = "webresources";
            const string CONTROLLER = "";
            //public const string CADD = "http://192.168.1.244:8080/TrackingAPI/webresources/resources/threshold";
            public const string COMPLETEADDRESS = PROTOCOL + ADDRESS + ":8080" + "/" + NAME + "/" + RESOURCES + "/";
            public const string PINGADDRESS = PROTOCOL + ADDRESS;
        }
    }
}
