using Autofac;
using System.Reflection;
using Module = Autofac.Module;

namespace ChatApp.Api.AutofacModules
{
    public class BllAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("ChatApp.Bll"))
                .Where(t => t.Name.EndsWith("AppService"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
