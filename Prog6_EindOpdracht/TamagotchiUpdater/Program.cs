﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using TamagotchiUpdater.TamagotchiService;

namespace TamagotchiUpdater
{
    // To learn more about Microsoft Azure WebJobs SDK, please see http://go.microsoft.com/fwlink/?LinkID=320976
    class Program
    {
        // Please set the following connection strings in app.config for this WebJob to run:
        // AzureWebJobsDashboard and AzureWebJobsStorage
        static void Main()
        {
           // var host = new JobHost();
            // The following code ensures that the WebJob will be running continuously
           // host.RunAndBlock();
            ITamagotchiService _service = new TamagotchiServiceClient("BasicHttpBinding_ITamagotchiService");

            while (true)
            {
                _service.DoRotation();
                var timeout = _service.GetUpdateFrequency() * 1000;
                Thread.Sleep(timeout);
            }
        }
    }
}
