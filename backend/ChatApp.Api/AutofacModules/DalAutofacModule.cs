using Autofac;
using System.Reflection;
using Module = Autofac.Module;

namespace ChatApp.Api.AutofacModules
{
    public class DalAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("ChatApp.Dal"))
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
