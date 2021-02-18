using System.Collections.Generic;
using TaskBoard.ViewModels.Entities;

namespace TaskBoard.ViewModels
{
    public class CreateAssignmentWindowViewModel
    {
        public IEnumerable<StatusViewModel> Statuses { get; set; } = new List<StatusViewModel>();
        public IEnumerable<ProjectViewModel> Projects { get; set; } = new List<ProjectViewModel>();
        public IEnumerable<PersonViewModel> Persons { get; set; } = new List<PersonViewModel>();

        public CreateAssignmentViewModel CreatedAssignment { get; set; } = new CreateAssignmentViewModel();
    }
}
