using System;

namespace Landy.Services.Notification.Core.Dtos
{
    public class EmailMessageDto
    {
        public Guid Id { get; set; }
        public string From { get; set; }
        public string Tos { get; set; }
        public string CCs { get; set; }
        public string BCCs { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
