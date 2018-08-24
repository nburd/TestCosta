using System;
using System.Collections.Generic;
using System.Linq;

namespace TestCosta.Model
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<Empoyee> GetAllEmployees()
        {
            using (var context = new DBEntities())
            {
                return context.Empoyees.ToArray();
            }
        }

        public IEnumerable<Empoyee> GetEmployeesByDepartmentsId(List<Guid> ids)
        {
            var employees = new List<Empoyee>();
            using (var context = new DBEntities())
            {
                foreach (var id in ids)
                {
                    var department = context.Departments.FirstOrDefault(x => x.ID == id);
                    if (department == null)
                        continue;

                    employees.AddRange(department.Empoyees.ToArray());
                }
            }

            return employees;
        }

        public Empoyee GetEmpoyeeById(int? id)
        {
            if (!id.HasValue)
                return new Empoyee();

            using (var context = new DBEntities())
            {
                return context.Empoyees.FirstOrDefault(x => x.ID == id);
            }
        }

        public void DeleteEmployee(int id)
        {
            using (var context = new DBEntities())
            {
                var deleteEmployee = context.Empoyees.FirstOrDefault(x => x.ID == id);
                context.Empoyees.Remove(deleteEmployee);
                context.SaveChanges();
            }
        }

        public decimal AddEmployee(Empoyee employee)
        {
            using (var context = new DBEntities())
            {               
                context.Empoyees.Add(employee);               
                context.SaveChanges();               
            }

            UpdateEmployee(employee);
            return employee.ID;
        }

        public decimal UpdateEmployee(Empoyee employee)
        {
            using (var context = new DBEntities())
            {
                var editEmployee = context.Empoyees.FirstOrDefault(x => x.ID == employee.ID);
                if (editEmployee == null)
                {
                    editEmployee = new Empoyee();
                    context.Empoyees.Add(editEmployee);
                }
                editEmployee.FirstName = employee.FirstName;
                editEmployee.SurName = employee.SurName;
                editEmployee.Patronymic = employee.Patronymic;
                editEmployee.DepartmentID = employee.DepartmentID;
                editEmployee.Department = context.Departments.FirstOrDefault(x => x.ID == employee.DepartmentID);
                editEmployee.DateOfBirth = employee.DateOfBirth;
                editEmployee.Position = employee.Position;
                context.SaveChanges();
                return editEmployee.ID;
            }
        }
    }
}
