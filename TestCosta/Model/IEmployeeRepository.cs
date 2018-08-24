using System;
using System.Collections.Generic;

namespace TestCosta.Model
{
    public interface IEmployeeRepository
    {
        IEnumerable<Empoyee> GetAllEmployees();
        IEnumerable<Empoyee> GetEmployeesByDepartmentsId(List<Guid> ids);
        Empoyee GetEmpoyeeById(int? id);
        decimal AddEmployee(Empoyee employee);
        decimal UpdateEmployee(Empoyee employee);
        void DeleteEmployee(int id);
    }
}
