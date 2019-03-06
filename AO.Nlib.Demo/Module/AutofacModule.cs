using Autofac;
using AO.Nlib.Demo.Services;
using Microsoft.Extensions.Logging;
using AO.Nlib.Demo.Contexts;

namespace AO.Nlib.Demo.Module
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method. All of this starts
            // with the services.AddAutofac() that happens in Program and registers Autofac
            // as the service provider.
            builder.Register(c => new ValuesService(c.Resolve<ILogger<ValuesService>>()))
                .As<IValuesService>()
                .InstancePerLifetimeScope();
            builder.Register(c => new AO.AspNetCore.NLib.UnitOfWork(new ApplicationDbContext()))
                .As<AO.AspNetCore.NLib.IUnitOfWork>()
                .InstancePerLifetimeScope();

        }
    }
}
