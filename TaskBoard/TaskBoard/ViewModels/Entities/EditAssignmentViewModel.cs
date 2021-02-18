namespace TaskBoard.ViewModels.Entities
{
    public class EditAssignmentViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public int AssigneeId { get; set; }
    }
}
