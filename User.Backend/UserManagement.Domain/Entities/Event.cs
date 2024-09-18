namespace UserManagement.Domain.Entities
{
    public class Event
    {
        public Guid EventId { get; set; }
        public string? EventName { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
