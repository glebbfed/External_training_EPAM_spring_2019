using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using BLL.ServiceImplementation;
using DAL.Interface.Interfaces;
using DAL.Repositories;
using Ninject;

namespace DependencyResolver
{
    public static class ResolverConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IAccountService>().To<AccountService>();
            //kernel.Bind<IRepository>().To<FakeRepository>();
            kernel.Bind<IStorage>().To<AccountStorage>().WithConstructorArgument("test.bin");
            kernel.Bind<IAccountCreateID>().To<AccountCreateID>().InSingletonScope();
            //kernel.Bind<IApplicationSettings>().To<ApplicationSettings>();
        }
    }
}
