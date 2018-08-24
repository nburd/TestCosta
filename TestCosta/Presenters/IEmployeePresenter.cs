using TestCosta.Presenters.Contexts;
using TestCosta.Views;

namespace TestCosta.Presenters
{
    public interface IEmployeePresenter : IPresenterWithArg<EmployeeContext, IEmployeeView>
    {
    }
}
