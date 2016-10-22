using Ninject;

namespace MediaPlayer.Core.Ioc
{
    public class NinjectAdapter : IContainer
    {
        private readonly IKernel _kernel;

        public NinjectAdapter(IKernel kernel)
        {
            _kernel = kernel;
        }

        public TService Resolve<TService>() => _kernel.Get<TService>();

        public void Register<TService, TImplementation>() where TService : TImplementation
            => _kernel.Bind<TService, TImplementation>();

        public void RegisterInstance<TService>(TService instance)
            =>
                _kernel.Bind<TService>().ToConstant(instance);


        public void Register<TService>() => _kernel.Bind<TService>().ToSelf();

        public bool IsRegistered<T>() => _kernel.CanResolve<T>();
    }
}