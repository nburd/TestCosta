using TestCosta.Presenters.Contexts;
using TestCosta.Views;

namespace TestCosta.Presenters
{
    public interface IDepartmentPresenter : IPresenterWithArg<DepartmentContext, IDepartmentView>
    {
    }
}
