namespace ProjectTracker.Api.Entities
{
    public class Bug
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Description { get; set; }
        public string State { get; set; }     

    }
}
