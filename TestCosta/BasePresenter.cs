using TestCosta.Model;

namespace TestCosta
{
    public abstract class BasePresenter<TView> : IPresenter<TView> 
        where TView : IView
    {
        public TView View { get; }
        protected IApplicationController Controller { get; }

        protected BasePresenter(IView view, IApplicationController controller)
        {            
            View = (TView)view;
            Controller = controller;
        }

        public void Run()
        {
            View.ShowForm();
        }
    }

    public abstract class BasePresenterWithArgs<TArg, TView> : BasePresenter<TView>, IPresenterWithArg<TArg, TView>
        where TView : IView
    {
        private TArg _arg;

        public TArg Arg => _arg;
        
        protected BasePresenterWithArgs(IView view, IApplicationController controller)
            : base(view, controller) {}

        public void SetArg(TArg arg)
        {
            _arg = arg;
            PrepareViewUsingArg();
        }

        public abstract void PrepareViewUsingArg();
    }
}
