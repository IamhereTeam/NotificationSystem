using System;

namespace NS.Core.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public int To { get; set; }
        public int From { get; set; }

        public DateTime Date { get; set; }
        public bool WasRead { get; set; }

        public string Subject { get; set; }
        public string Message { get; set; }
    }
}