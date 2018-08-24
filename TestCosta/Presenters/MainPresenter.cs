using System;
using System.Linq;
using TestCosta.Model;
using TestCosta.Presenters.Contexts;
using TestCosta.Views;

namespace TestCosta.Presenters
{
    public class MainPresenter : BasePresenter<IMainView>, IMainPresenter
    {
        private const string Title = "Главная";

        private IDepartmentRepository _departmentRepository;
        private IEmployeeRepository _employeeRepository;

        public MainPresenter(IMainView view, IApplicationController controller, IDepartmentRepository departmentRepository,
            IEmployeeRepository employeeRepository) : base(view, controller)
        {
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;

            PrepareView();
        }

        private void PrepareView()
        {
            View.SetTitle(Title);
            View.DepartmentSelectingChanged += ViewDepartmentSelectedChanged;
            View.ClickedInsertingEmployee += ViewClickedInsertingEmployee;
            View.ClickedInsertingDepartment += ViewClickedInsertingDepartment;
            View.ClickedEditingEmployee += ViewClickedEditingEmployee;
            View.ClickedEditingDepartment += ViewClickedEditingDepartment;
            View.ClickedDeletingEmployee += ViewClickedDeletingEmployee;
            View.ClickedDeletingDepartment += ViewClickedDeletingDepartment;
            RefreshDepartments();
        }

        private void ViewDepartmentSelectedChanged(object sender, DepartmentChangedEventArgs e)
        {
            var employees = _employeeRepository.GetEmployeesByDepartmentsId(e.Guids).OrderBy(x => x.ToString());
            View.ShowEmployees(employees);
        }

        private void ViewClickedInsertingEmployee(object sender, Guid e)
        {
            var context = new EmployeeContext(Mode.Insert)
            {
                Id = null,
                DepartmentId = e
            };
            Controller.RunPresenter<IEmployeePresenter, IEmployeeView, EmployeeContext>(context);
            View.UpdateEmployees();
            if (context.Id.HasValue)
                View.SelectEmployee(context.Id.Value);
        }

        private void ViewClickedInsertingDepartment(object sender, Guid e)
        {
            var context = new DepartmentContext(Mode.Insert)
            {
                Id = null,
                ParentId = e
            };
            Controller.RunPresenter<IDepartmentPresenter, IDepartmentView, DepartmentContext>(context);
            UpdateDepartments(context.Id);
        }

        private void ViewClickedEditingEmployee(object sender, int e)
        {
            var context = new EmployeeContext(Mode.Edit)
            {
                Id = e,
                DepartmentId = null
            };
            Controller.RunPresenter<EmployeePresenter, IEmployeeView, EmployeeContext>(context);
            View.UpdateEmployees();
            View.SelectEmployee(e);
        }

        private void ViewClickedEditingDepartment(object sender, Guid e)
        {
            var context = new DepartmentContext(Mode.Edit)
            {
                Id = e                
            };
            Controller.RunPresenter<IDepartmentPresenter, IDepartmentView, DepartmentContext>(context);
            UpdateDepartments(context.Id);
        }

        private void ViewClickedDeletingEmployee(object sender, int e)
        {
            _employeeRepository.DeleteEmployee(e);
            int index = View.GetCurrentSelectedEmployeeIndex();
            if (sender != null && int.TryParse(sender.ToString(), out int result))
                index = result;

            View.UpdateEmployees();
            View.SelectEmployeeByIndex(index);
        }

        private void ViewClickedDeletingDepartment(object sender, Guid e)
        {
            var nextDepartmentId = View.GetNextNode();
            _departmentRepository.DeleteDepartment(e);
            RefreshDepartments();
            View.ExpandDepartment(nextDepartmentId);
        }

        private void RefreshDepartments()
        {
            View.ShowDepartments(_departmentRepository.GetAllDepartments());
        }

        private void UpdateDepartments(Guid? id)
        {
            RefreshDepartments();
            if (id.HasValue)
                View.ExpandDepartment(id.Value);
        }
    }
}
