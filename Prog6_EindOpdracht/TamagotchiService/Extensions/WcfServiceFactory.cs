using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using SimpleInjector.Integration.Wcf;

namespace TamagotchiService.Extensions
{
    public class WcfServiceFactory : SimpleInjectorServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType,
            Uri[] baseAddresses)
        {
            return new SimpleInjectorServiceHost(
                Bootstrapper.Container,
                serviceType,
                baseAddresses);
        }
    }
}