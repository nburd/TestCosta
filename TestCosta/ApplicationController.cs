using TestCosta.Presenters;
using TestCosta.Views;

namespace TestCosta
{
    public class ApplicationController : IApplicationController
    {
        private readonly IPresenterFactory _factory;

        public ApplicationController(IPresenterFactory factory)
        {
            _factory = factory;            
        }

        public void Start()
        {
            RunPresenter<IMainPresenter, IMainView>();
        }

        public void RunPresenter<TPresenter, TView>()
            where TPresenter : class, IPresenter<TView>
            where TView : IView
        {
            var presenter = _factory.CreatePresenter<TPresenter, TView>();
            presenter.Run();
        }

        public void RunPresenter<TPresenter, TView, TArg>(TArg arg)
            where TPresenter : class, IPresenterWithArg<TArg,TView>
            where TView : IView
        {
            var presenter = _factory.CreatePresenter<TPresenter, TView, TArg>();
            presenter.SetArg(arg);
            presenter.Run();
        }
    }
}
