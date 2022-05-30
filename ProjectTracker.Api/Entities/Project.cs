namespace ProjectTracker.Api.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
