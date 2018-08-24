using System;
using System.Linq;
using TestCosta.Model;
using TestCosta.Presenters.Contexts;
using TestCosta.Views;

namespace TestCosta.Presenters
{
    public class EmployeePresenter : BasePresenterWithArgs<EmployeeContext, IEmployeeView>, IEmployeePresenter
    {
        private const string AddingTitle = "Добавление сотрудника";
        private const string EditingTitle = "Редактирование сотрудника";
        private Empoyee _employee;
        private IEmployeeRepository _employeeRepository;
        private IDepartmentRepository _departmentRepository;

        public EmployeePresenter(IEmployeeView view, IApplicationController controller, IEmployeeRepository employeeRepository,
            IDepartmentRepository departmentRepository)
            : base(view, controller)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;           

            View.SaveEmployee += ViewSaveEmployee;
            View.CloseForm += ViewCloseForm;
        }

        public override void PrepareViewUsingArg()
        {
            _employee = _employeeRepository.GetEmpoyeeById(Arg.Id);

            SetViewTitle();
            PrepareView();
        }

        private void ViewCloseForm(object sender, EventArgs e)
        {
            View.SaveEmployee -= ViewSaveEmployee;
            View.CloseForm -= ViewCloseForm;
        }

        private void ViewSaveEmployee(object sender, EventArgs e)
        {
            _employee.DepartmentID = View.SelectedDepartment.Value;
            _employee.FirstName = View.FirstName;
            _employee.Patronymic = View.Patronymic;
            _employee.SurName = View.Surname;
            _employee.Position = View.Position;
            _employee.DateOfBirth = View.Birthday;
            _employee.DocNumber = View.DocNumber;
            _employee.DocSeries = View.DocSeries;
            if (Arg.Mode == Mode.Insert)
                Arg.Id = (int)_employeeRepository.AddEmployee(_employee);
            else
                Arg.Id = (int)_employeeRepository.UpdateEmployee(_employee);
        }

        private void SetViewTitle()
        {
            string title = Arg.Mode == Mode.Insert ? AddingTitle : EditingTitle;
            View.SetTitle(title);
        }

        private void PrepareView()
        {
            View.FirstName = _employee.FirstName;
            View.Surname = _employee.SurName;
            View.Patronymic = _employee.Patronymic;
            View.Position = _employee.Position;
            View.Birthday = _employee.DateOfBirth == DateTime.MinValue ? DateTime.Now : _employee.DateOfBirth;
            View.DocSeries = _employee.DocSeries;
            View.DocNumber = _employee.DocNumber;

            Guid departmentId = Arg.Mode == Mode.Insert ? Arg.DepartmentId.Value : _employee.DepartmentID;
            View.FillDepartments(_departmentRepository.GetDepartmentsAsDictionary(), departmentId);
            View.SetAutoCompleteSource(_employeeRepository.GetAllEmployees().Select(x => x.Position)
                .Distinct().ToArray());
        }
    }
}


