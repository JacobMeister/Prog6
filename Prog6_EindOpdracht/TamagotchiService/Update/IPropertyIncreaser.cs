using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiService.Data;
using TamagotchiService.Rules;

namespace TamagotchiService.Update
{
    public interface IPropertyIncreaser
    {
        int MaxValue { get; }
        int MinValue { get; }

        IRule Rule { get; }

        void ExecuteIncrement(Tamagotchi tamagotchi);

        void UpdatePropertyIncreasers(int min, int max);
    }
}
