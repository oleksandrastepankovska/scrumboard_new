using System.Collections.Generic;
using TaskBoard.ViewModels.Entities;

namespace TaskBoard.ViewModels
{
    public class EditAssignmentWindowViewModel
    {
        public AssignmentViewModel Assignment { get; set; }
        public IEnumerable<StatusViewModel> Statuses { get; set; } = new List<StatusViewModel>();
        public IEnumerable<PersonViewModel> Persons { get; set; } = new List<PersonViewModel>();

        public EditAssignmentViewModel EditedAssignment { get; set; } = new EditAssignmentViewModel();
    }
}
