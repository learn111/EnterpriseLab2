namespace MediaPlayer.Core.Ioc
{
    public interface IContainer
    {
        TService Resolve<TService>();

        void Register<TService, TImplementation>()
            where TService : TImplementation;

        void RegisterInstance<TService>(TService instance);
        void Register<TService>();
        bool IsRegistered<T>();
    }
}