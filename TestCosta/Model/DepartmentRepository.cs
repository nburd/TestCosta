using System;
using System.Collections.Generic;
using System.Linq;

namespace TestCosta.Model
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public IEnumerable<Department> GetAllDepartments()
        {
            using (var context = new DBEntities())
            {
                return context.Departments.ToArray();
            }
        }

        public Dictionary<Guid, string> GetDepartmentsAsDictionary()
        {
            var departments = GetAllDepartments().OrderBy(x => x.Name);
            var dictionary = new Dictionary<Guid, string>();
            foreach (var department in departments)
                dictionary.Add(department.ID, department.Name);

            return dictionary;
        }

        public Department GetDepartmentById(Guid? id)
        {
            if (!id.HasValue)
                return new Department();

            using (var context = new DBEntities())
            {
                return context.Departments.FirstOrDefault(x => x.ID == id);
            }
        }

        public Guid AddDepartment(Department department)
        {
            using (var context = new DBEntities())
            {
                department.ID = Guid.NewGuid();
                context.Departments.Add(department);
                context.SaveChanges();
            }

            UpdateDepartment(department);
            return department.ID;
        }

        public Guid UpdateDepartment(Department department)
        {
            using (var context = new DBEntities())
            {
                var editDepartment = context.Departments.FirstOrDefault(x => x.ID == department.ID);               
                editDepartment.Name = department.Name;
                editDepartment.ParentDepartmentID = department.ParentDepartmentID;
                editDepartment.Code = department.Code;
                context.SaveChanges();
                return editDepartment.ID;
            }
        }

        public void DeleteDepartment(Guid id)
        {
            using (var context = new DBEntities())
            {
                var deleteDepartments = context.Departments.Where(x => x.ID == id || x.ParentDepartmentID == id);
                foreach (var department in deleteDepartments)
                {
                    var employees = context.Empoyees.Where(x => x.DepartmentID == department.ID).ToArray();                    
                    context.Empoyees.RemoveRange(employees);                    
                }

                context.Departments.RemoveRange(deleteDepartments);
                context.SaveChanges();
            }
        }
    }
}
