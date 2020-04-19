[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Corp.Cencosud.Supermercados.Sua.Accesos.Api.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Corp.Cencosud.Supermercados.Sua.Accesos.Api.App_Start.NinjectWebCommon), "Stop")]

namespace Corp.Cencosud.Supermercados.Sua.Accesos.Api.App_Start
{
    using System;
    using System.Web;
    using Ninject.Web.WebApi;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Http;
    using Ninject.Web.Common.WebHost;
    using Biz.Interfaces;
    using Biz;
    using Sua_Accesos.Dal;

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
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
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
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUsuarioBiz>().To <UsuarioBiz>();
            kernel.Bind<IAppContextBiz>().To<AppContextBiz>();
            kernel.Bind<IPerfilBiz>().To<PerfilBiz>();
            kernel.Bind<IRegionBiz>().To<RegionBiz>();
            kernel.Bind<IUOW_AccesosDB>().To<UOW_AccesosDB>().InRequestScope();
            kernel.Bind<IAplicacionBiz>().To<AplicacionBiz>();
            kernel.Bind<IAccionBiz>().To<AccionBiz>();
            kernel.Bind<ISeguridadBiz>().To<SeguridadBiz>();
        }        
    }
}