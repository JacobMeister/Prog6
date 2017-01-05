using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Prog6_Eindopdracht.Domain;


namespace Prog6_EindOpdracht.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITamagotchiService" in both code and config file together.
    [ServiceContract]
    public interface ITamagotchiService
    {

        [OperationContract]
        List<Tamagotchi> GetTamagotchis();

        [OperationContract]
        Tamagotchi CreateTamagotchi(Tamagotchi tamagotchi);

        // TODO: Add your service operations here
        [OperationContract]
        String WorkingService();

        [OperationContract]
        bool WorkingDbContext();
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Tamagotchi
    {

        public Tamagotchi()
        {
            
        }

        public Tamagotchi(Prog6_Eindopdracht.Domain.Tamagotchi tamagotchi)
        {
            ID = tamagotchi.ID;
            Name = tamagotchi.Name;
            Age = tamagotchi.Age;
            Hunger = tamagotchi.Hunger;
            Sleep = tamagotchi.Sleep;
            Boredom = tamagotchi.Boredom;
            DateOfLastAcces = tamagotchi.DateOfLastAcces;
            Health = tamagotchi.Health;
        }


        [DataMember]
        public int ID
        {
            get;
            set;
        }

        [DataMember]
        public string Name
        {
            get;
            set;
        }

        [DataMember]
        public int Age
        {
            get;
            set;
        }

        [DataMember]
        public int Hunger
        {
            get;
            set;
        }

        [DataMember]
        public int Sleep
        {
            get;
            set;
        }

        [DataMember]
        public int Boredom
        {
            get;
            set;
        }

        [DataMember]
        public int Health
        {
            get;
            set;
        }

        [DataMember]
        public DateTime DateOfLastAcces
        {
            get;
            set;
        }

        internal Prog6_Eindopdracht.Domain.Tamagotchi ToTamagotchi()
        {
            return new Prog6_Eindopdracht.Domain.Tamagotchi()
            {
                ID = this.ID,
                Name = this.Name,
                Age = this.Age,
                Hunger = this.Hunger,
                Sleep = this.Sleep,
                Boredom = this.Boredom,
                DateOfLastAcces = this.DateOfLastAcces,
                Health = this.Health
            };
        }
    }
}
