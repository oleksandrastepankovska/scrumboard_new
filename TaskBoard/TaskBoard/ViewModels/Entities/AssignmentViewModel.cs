namespace TaskBoard.ViewModels.Entities
{
    public class AssignmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Project { get; set; }
        public int AssigneeId { get; set; }
        public string Assignee { get; set; }
        public int StatusId { get; set; }
    }
}
