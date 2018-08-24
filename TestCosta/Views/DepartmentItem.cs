using System;

namespace TestCosta.Views
{
    public class DepartmentItem
    {
        public string Name { get; set; }

        public Guid Id { get; set; }

        public DepartmentItem(string name, Guid id)
        {
            Name = name;
            Id = id;
        }

        public override string ToString() => Name;
    }
}
