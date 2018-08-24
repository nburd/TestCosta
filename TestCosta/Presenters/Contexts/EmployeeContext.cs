using System;

namespace TestCosta.Presenters.Contexts
{
    public class EmployeeContext : Context
    {
        public int? Id { get; set; }

        public Guid? DepartmentId { get; set; }

        public EmployeeContext(Mode mode) : base(mode) { }
    }
}
