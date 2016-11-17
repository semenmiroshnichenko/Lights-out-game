using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace LightsOutDomain
{
    public class HttpDownloader : IHttpDownloader
    {
        public string GetData(string remoteUri)
        { 
            WebClient myWebClient = new WebClient();
            return Encoding.Default.GetString(myWebClient.DownloadData(remoteUri));
        }
    }
}
