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

        private bool loggedIn = false;

        private string err = null;

        private string usernameFinal = null;

        private string passwordFinal = null;

        private object get(string finalUrl)
        {
            try
            {
                // Create a request for the URL. 
                WebRequest request = WebRequest.Create(finalUrl);
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
                return false;
            }
        }

        public cloudCore(object username, object password)
        {
            object loginStatus = get(url + "?username=" + username + "&password=" + password);

            if((string)loginStatus == "true" && loggedIn == false)
            {
                usernameFinal = username.ToString();

                passwordFinal = password.ToString();

                loggedIn = true;

                /*} else if((bool)loginStatus == false) --//Future use//--
                {
                    err = 
                }
                */
            }
        }
    }
}
