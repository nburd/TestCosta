using SimpleInjector;

namespace TestCosta
{
    public class PresenterFactory : IPresenterFactory
    {
        private readonly Container _container;

        public PresenterFactory(Container container)
        {
            _container = container;
        }

        public TPresenter CreatePresenter<TPresenter, TView, TArg>() 
            where TPresenter : class, IPresenterWithArg<TArg, TView>
            where TView : IView 
        {
            return _container.GetInstance<TPresenter>();
        }

        public TPresenter CreatePresenter<TPresenter, TView>()
            where TPresenter : class, IPresenter<TView>
            where TView : IView
        {
            return _container.GetInstance<TPresenter>();
        }
    }
}
