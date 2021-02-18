using System.Collections.Generic;
using TaskBoard.Data.Entities;
using TaskBoard.ViewModels.Entities;

namespace TaskBoard.ViewModels
{
    public class CreateAssignmentWindowViewModel
    {
        public IEnumerable<Status> Statuses { get; set; }

        public CreateAssignmentViewModel CreatedAssignment { get; set; } = new CreateAssignmentViewModel();
    }
}
