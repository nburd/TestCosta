
namespace TestCosta
{
    public interface IPresenter<TView>
        where TView : IView
    {
        TView View { get; }

        void Run();        
    }

    public interface IPresenterWithArg<TArg, TView> : IPresenter<TView>
        where TView : IView
    {
        TArg Arg { get; }

        void SetArg(TArg arg);
    }
}
