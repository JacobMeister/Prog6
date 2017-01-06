using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TamagotchiService.Data;

namespace TamagotchiService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITamagotchiService" in both code and config file together.
    [ServiceContract]
    public interface ITamagotchiService
    {
        [OperationContract]
        List<Tamagotchi> GetTamagotchis();

        [OperationContract]
        void CreateTamagotchi(string name);

        [OperationContract]
        void DeleteTamagotchi(int id);

        [OperationContract]
        Tamagotchi GeTamagotchi(int id);
    }
}
