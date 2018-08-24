using System;
using TestCosta.Model;
using TestCosta.Presenters.Contexts;
using TestCosta.Views;

namespace TestCosta.Presenters
{
    public class DepartmentPresenter : BasePresenterWithArgs<DepartmentContext, IDepartmentView>, IDepartmentPresenter
    {
        private const string AddingTitle = "Добавление подразделения";
        private const string EditingTitle = "Редактирование подразделения";
        private Department _department;
        
        public IDepartmentRepository DepartmentRepository { get; }

        public DepartmentPresenter(IDepartmentView view, IDepartmentRepository repository, IApplicationController controller)
            : base(view, controller)
        {
            DepartmentRepository = repository;

            View.SaveDepartment += ViewSaveDepartment;
            View.CloseForm += ViewCloseForm;
        }

        private void ViewCloseForm(object sender, EventArgs e)
        {
            View.SaveDepartment -= ViewSaveDepartment;
            View.CloseForm -= ViewCloseForm;
        }

        private void ViewSaveDepartment(object sender, EventArgs e)
        {
            _department.Name = View.DepartmentName;
            _department.Code = View.Code;
            _department.ParentDepartmentID = View.HasParentDepartment ? View.ParentDepartment : null;
            if (Arg.Mode == Mode.Insert)
                Arg.Id = DepartmentRepository.AddDepartment(_department);
            else
                Arg.Id = DepartmentRepository.UpdateDepartment(_department);
        }

        private void SetViewTitle()
        {
            var title = Arg.Mode == Mode.Insert ? AddingTitle : EditingTitle;
            View.SetTitle(title);
        }

        private void PrepareView()
        {
            View.DepartmentName = _department.Name;
            View.Code = _department.Code;
            View.HasParentDepartment = true;
            var parentDepartment = Arg.Mode == Mode.Edit ? _department.ParentDepartmentID : Arg.ParentId;
            View.FillDepartments(DepartmentRepository.GetDepartmentsAsDictionary(), parentDepartment);
        }

        public override void PrepareViewUsingArg()
        {
            _department = DepartmentRepository.GetDepartmentById(Arg.Id);
            SetViewTitle();
            PrepareView();
        }
    }
}