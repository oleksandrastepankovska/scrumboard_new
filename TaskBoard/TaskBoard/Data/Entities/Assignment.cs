namespace TaskBoard.Data.Entities
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}
