using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Prog6_EindOpdracht.WCF.Data
{
    public class TamagotchiContext : DbContext
    {
        public TamagotchiContext() : base("name = default")
        {
            
        }

        public DbSet<Prog6_Eindopdracht.Domain.Tamagotchi> Tamagotchis { get; set; }
    }
}