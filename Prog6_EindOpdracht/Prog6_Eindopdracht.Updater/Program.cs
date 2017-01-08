using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Prog6_Eindopdracht.Updater.TamagotchiService;

namespace Prog6_Eindopdracht.Updater
{
    class Program
    {
        static void Main(string[] args)
        {
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
