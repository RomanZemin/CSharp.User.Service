namespace UserManagement.Domain.Entities
{
    public class User_Event
    {
        public Guid UserEventId { get; set; }
        public Guid UserId { get; set; }
        public Guid EventId { get; set; }
        public DateTime JoinedAt { get; set; }
    }
}
