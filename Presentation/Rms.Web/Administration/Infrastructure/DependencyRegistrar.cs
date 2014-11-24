using Autofac;
using Autofac.Core;
using Rms.Admin.Controllers;
using Rms.Core.Caching;
using Rms.Core.Infrastructure;
using Rms.Core.Infrastructure.DependencyManagement;

namespace Rms.Admin.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            //we cache presentation models between requests
            builder.RegisterType<HomeController>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("nop_cache_static"));
        }

        public int Order
        {
            get { return 2; }
        }
    }
}
