using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamagotchiService.Data;

namespace TamagotchiService.Rules
{
    public interface IRule
    {
        bool ExecuteRule(Tamagotchi tamagotchi);
    }
}
