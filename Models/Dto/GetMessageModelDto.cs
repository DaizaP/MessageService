namespace MessageService.Models.Dto
{
    public class GetMessageModelDto
    {
        public string Content { get; set; } = string.Empty;
        public Guid SenderId { get; set; }
    }
}
