using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Threading;

namespace CloudSync
{
    class CloudSyncBackgroundWorker
    {
        public void mainWorker(object sender, DoWorkEventArgs e)
        {
            object[] credentials = e.Argument as object[];

            cloudCore http = new cloudCore(credentials[1], credentials[2]);

            while (true)
            {
                BackgroundWorker worker = sender as BackgroundWorker;

                if (worker.CancellationPending)
                {
                    e.Cancel = true;

                    break;
                }

           

                Thread.Sleep(5000);
            }
        }
    }
}
