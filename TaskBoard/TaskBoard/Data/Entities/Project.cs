using System.Collections.Generic;

namespace TaskBoard.Data.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Person> Assignees { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
    }
}
