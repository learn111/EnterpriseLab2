using System;
using System.Web;
using System.Web.Http;
using MediaPlayer.Core.Cqrs.Contracts;
using MediaPlayer.Core.Ioc;
using MediaPlayer.Web.App_Start;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Web.Common;
using Ninject.Web.Mvc;
using WebActivatorEx;
using WebGrease.Configuration;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof (NinjectWebCommon), "Start")]
[assembly: ApplicationShutdownMethod(typeof (NinjectWebCommon), "Stop")]

namespace MediaPlayer.Web.App_Start
{
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        ///     Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof (OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof (NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        ///     Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        ///     Creates the kernel that will manage your application.
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
        ///     Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IContainer>().To<NinjectAdapter>();
            kernel.Bind(x => x
                .FromAssembliesMatching("MediaPlayer.Core.dll", "MediaPlayer.Web.dll", "MediaPlayer.Data.dll")
                .SelectAllClasses()
                .BindDefaultInterface());
            kernel.Bind(
                x =>
                    x.FromAssembliesMatching("MediaPlayer.Cqrs.dll")
                        .SelectAllClasses()
                        .InheritedFrom(typeof (IQueryHandler<,>))
                        .BindAllInterfaces());
            kernel.Bind(
                x =>
                    x.FromAssembliesMatching("MediaPlayer.Cqrs.dll")
                        .SelectAllClasses()
                        .InheritedFrom(typeof (ICommandHandler<>))
                        .BindAllInterfaces());
        }
    }
}