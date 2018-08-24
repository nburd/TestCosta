using System;
using System.Collections.Generic;

namespace TestCosta.Model
{
    public interface IDepartmentRepository
    {       
        IEnumerable<Department> GetAllDepartments();
        Dictionary<Guid, string> GetDepartmentsAsDictionary();       
        Department GetDepartmentById(Guid? id);
        Guid AddDepartment(Department department);
        Guid UpdateDepartment(Department department);       
        void DeleteDepartment(Guid id);       
    }
}
