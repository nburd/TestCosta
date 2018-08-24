using System;
using System.Collections.Generic;

namespace TestCosta.Views
{
    public interface IEmployeeView : IView
    {
        event EventHandler SaveEmployee;
        event EventHandler CloseForm;
        
        string FirstName { get; set; }
        string Surname{ get; set; }
        string Patronymic{ get; set; }
        DateTime Birthday{ get; set; }
        string Position{ get; set; }
        string DocSeries{ get; set; }
        string DocNumber{ get; set; }
        Guid? SelectedDepartment { get; }

        void FillDepartments(Dictionary<Guid, string> values, Guid selectedId);
        void SetAutoCompleteSource(string[] source);
    }
}
