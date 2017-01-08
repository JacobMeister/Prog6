using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Prog6_Eindopdracht.WPF;
using Prog6_Eindopdracht.WPF1.Model;
using Prog6_Eindopdracht.WPF1.TamagotchiService;

namespace Prog6_Eindopdracht.WPF1.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel
    {
        private List<Tamagotchi> tgList = new List<Tamagotchi>();
        private ITamagotchiService TGS;
        private List<CustomTamagotchi> customTGList;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            TGS = new TamagotchiServiceClient("BasicHttpBinding_ITamagotchiService");
            loop();
        }

        public List<CustomTamagotchi> CustomTGList
        {
            get { return customTGList; }
            set { customTGList = value; }
        }

        public List<Tamagotchi> TGList
        {
            get { return tgList; }
            set
            {
                tgList = value;
                ConvertTamagotchis();
            }
        }

        public void ConvertTamagotchis()
        {
            foreach (Tamagotchi tg in tgList)
            {
                customTGList = new List<CustomTamagotchi>();
                var tmg = new CustomTamagotchi
                {
                    Name = tg.Name,
                    Health = HealthSet(tg),
                    Status = StatusSet(tg)
                };
            }
        }

        public string StatusSet(Tamagotchi tg)
        {
            if (tg.Hunger > tg.Sleep && tg.Hunger > tg.Boredom) { return "Resources/Honger.png"; }
            if (tg.Sleep > tg.Hunger && tg.Sleep > tg.Boredom) { return "Resources/Slaap.png"; }
            return "Resources/Verveeld.png"; 
        }

        public string HealthSet(Tamagotchi tg)
        {

            if (tg.Health > 80) { return "Resources/Health100.png"; }

            if (tg.Health > 60 && tg.Health <= 80) { return "Resources/Health80.png"; }
            if (tg.Health > 40 && tg.Health <= 60) { return "Resources/Health60.png"; }
            if (tg.Health > 20 && tg.Health <= 40) { return "Resources/Health40.png"; }
            if (tg.Health > 0 && tg.Health <= 20) { return "Resources/Health20.png"; }
            return "Resources/Health0.png"; 
        }

        public void loop()
        {
            var c = 0;

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                while (c < 60)
                {
                    TGList = TGS.GetTamagotchis().ToList();
                    Thread.Sleep(2000);
                    c++;
                }
            }).Start();

        }
    }
}