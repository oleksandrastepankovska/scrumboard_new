using System.Collections.Generic;

namespace TaskBoard.Data.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Assignment> Assignments { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
