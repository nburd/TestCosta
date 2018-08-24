using System;
using System.Collections.Generic;

namespace TestCosta.Views
{
    public interface IDepartmentView : IView
    {
        event EventHandler SaveDepartment;
        event EventHandler CloseForm;
        
        string DepartmentName { get; set; }
        string Code { get; set; }
        bool HasParentDepartment { get; set; }
        Guid? ParentDepartment { get; }

        void FillDepartments(Dictionary<Guid, string> values, Guid? selectedId);
    }
}
