
namespace TestCosta
{
    public interface IPresenterFactory
    {
        TPresenter CreatePresenter<TPresenter, TView>()
            where TPresenter : class, IPresenter<TView>
            where TView : IView;

        TPresenter CreatePresenter<TPresenter, TView, TArg>()
            where TPresenter : class, IPresenterWithArg<TArg, TView> 
            where TView : IView;
    }
}
