namespace ConnectionsManager.Data
{
    public class Note
    {
        public int Id { get; set; } // primary key
        public string? UserId { get; set; } 
        public string Topic { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsPrivate { get; set; } = false;
    }
}
