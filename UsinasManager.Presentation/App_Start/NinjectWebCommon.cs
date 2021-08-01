[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(UsinasManager.Presentation.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(UsinasManager.Presentation.App_Start.NinjectWebCommon), "Stop")]

namespace UsinasManager.Presentation.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
	using Ninject.Web.Common.WebHost;
	using UsinasManager.Application;
	using UsinasManager.Application.Interfaces;
	using UsinasManager.Domain.Interfaces.Repositories;
	using UsinasManager.Domain.Interfaces.Services;
	using UsinasManager.Domain.Services;
	using UsinasManager.Infrastructure.Data.Repositories;

	public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            ///Application layer
            kernel.Bind(typeof(IApplicationServiceBase<>)).To(typeof(ApplicationServiceBase<>));
            kernel.Bind<IUsinaApplicationService>().To<UsinaApplicationService>();
            kernel.Bind<IFornecedorApplicationService>().To<FornecedorApplicationService>();

            
            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IUsinaService>().To<UsinaService>();
            kernel.Bind<IFornecedorService>().To<FornecedorService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IUsinaRepository>().To<UsinaRepository>();
            kernel.Bind<IFornecedorRepository>().To<FornecedorRepository>();
        }        
    }
}
