using System;
using System.Collections.Generic;
using TestCosta.Model;

namespace TestCosta.Views
{
    public interface IMainView : IView
    {
        event EventHandler<DepartmentChangedEventArgs> DepartmentSelectingChanged;
        event EventHandler<Guid> ClickedInsertingEmployee;
        event EventHandler<Guid> ClickedInsertingDepartment;
        event EventHandler<int> ClickedEditingEmployee;
        event EventHandler<Guid> ClickedEditingDepartment;        
        event EventHandler<int> ClickedDeletingEmployee;
        event EventHandler<Guid> ClickedDeletingDepartment;

        void ShowDepartments(IEnumerable<Department> departments);
        void ShowEmployees(IEnumerable<Empoyee> employees);
        void UpdateEmployees();
        void ExpandDepartment(Guid? id);
        void SelectEmployee(int id);
        void SelectEmployeeByIndex(int index);
        int GetCurrentSelectedEmployeeIndex();
        Guid? GetNextNode();
    }

    public class DepartmentChangedEventArgs
    {
        public List<Guid> Guids { get; private set; }

        public DepartmentChangedEventArgs(List<Guid> guids)
        {
            Guids = guids;
        }
    }
}
