using MessageService.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MessageService.Abstraction
{
    public interface IMessageSrv
    {
        public bool SendMsg(SendMessageModelDto messageModelDto, Guid senderId);
        public IEnumerable<GetMessageModelDto> GetMessagesForMe(Guid userId);
    }
}
