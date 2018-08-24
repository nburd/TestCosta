using System;

namespace TestCosta.Presenters.Contexts
{
    public class DepartmentContext : Context
    {
        public Guid? Id { get; set; }

        public Guid? ParentId { get; set; }

        public DepartmentContext(Mode mode) : base(mode) { }
    }
}
