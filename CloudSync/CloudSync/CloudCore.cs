using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.IO;
using System.Diagnostics;

namespace CloudSync
{
    class cloudCore
    {
        private string url = "https://google.com/";

        public string login(string username, string password)
        {
            try
            {
                // Create a request for the URL. 
                WebRequest request = WebRequest.Create(url);
                // If required by the server, set the credentials.
                request.Credentials = CredentialCache.DefaultCredentials;
                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                Debug.Print(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Clean up the streams and the response.
                reader.Close();
                response.Close();

                //return responseFromServer;

                return "true"; //debug
            }
            catch (WebException e)
            {
                return "fail";
            }
        }
        public void notify(string caption)
        {

        }
    }
}
