namespace MessageService.Models
{
    public class MessageModel
    {
        public Guid MessageId { get; set; }
        public string Content { get; set; } = string.Empty;
        public Guid SenderId { get; set; }
        public Guid RecipientId { get; set; }
        public MsgStatus MsgStatus { get; set; }
    }
    public enum MsgStatus
    {
        Read = 1,
        Unread = 0
    }
}
