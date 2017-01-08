using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleInjector;
using SimpleInjector.Integration.Wcf;
using TamagotchiService.Actions;
using TamagotchiService.Factories;
using TamagotchiService.Update;

namespace TamagotchiService.Extensions
{
    public static class Bootstrapper
    {
        public static readonly Container Container;

        static Bootstrapper()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WcfOperationLifestyle();

            container.Register(() => new ActionManager(), Lifestyle.Singleton);
            container.Register(() => new UpdateManager(RuleFactory.SupplyRules()), Lifestyle.Singleton);

            container.Verify();

            Container = container;
        }
    }
}