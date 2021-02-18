using System.Collections.Generic;
using TaskBoard.ViewModels.Entities;

namespace TaskBoard.ViewModels
{
    public class MainWindowViewModel
    {
        public IEnumerable<StatusViewModel> Statuses { get; set; } = new List<StatusViewModel>();

        public IEnumerable<AssignmentViewModel> Assignments { get; set; } = new List<AssignmentViewModel>();
    }
}
