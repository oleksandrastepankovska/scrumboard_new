using System.Collections.Generic;

namespace TaskBoard.Data.Entities
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
    }
}
