
namespace TestCosta
{
    public interface IApplicationController
    {
        void Start();

        void RunPresenter<TPresenter, TView>()
            where TPresenter : class, IPresenter<TView>
            where TView : IView;

        void RunPresenter<TPresenter, TView, TArg>(TArg arg)
           where TPresenter : class, IPresenterWithArg<TArg, TView>
            where TView : IView;
    }
}
