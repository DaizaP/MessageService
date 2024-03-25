namespace MessageService.Models.Dto
{
    public class SendMessageModelDto
    {
        public string Content { get; set; } = string.Empty;
        public Guid RecipientId { get; set; }
    }
}
