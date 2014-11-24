using Autofac;
using Autofac.Core;
using Rms.Core.Caching;
using Rms.Core.Infrastructure;
using Rms.Core.Infrastructure.DependencyManagement;
using Rms.Web.Controllers;
using Rms.Web.Infrastructure.Installation;

namespace Rms.Web.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            //we cache presentation models between requests
         
            
            //installation localization service
            builder.RegisterType<InstallationLocalizationService>().As<IInstallationLocalizationService>().InstancePerLifetimeScope();
        }

        public int Order
        {
            get { return 2; }
        }
    }
}
