namespace ProjectTracker.Api.Entities
{
    public class Backlog
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string State { get; set; }

    }
}
