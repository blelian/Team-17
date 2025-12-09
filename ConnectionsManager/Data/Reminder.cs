namespace ConnectionsManager.Data
{
    public class Reminder
    {
        public int Id { get; set; } // primary key
        public string Subject { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public DateTime Date { get; set; } // date of the reminder
        public TimeSpan Time { get; set; } // time of the reminder
        public bool IsDone { get; set; } = false;
    }
}
