using AutoMapper;
using MessageService.Abstraction;
using MessageService.Models;
using MessageService.Models.Context;
using MessageService.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessageService.Services
{
    public class MessageSrv : IMessageSrv
    {
        readonly private IMapper _mapper;
        readonly private MsgDbContext _context;

        public MessageSrv(IMapper mapper, MsgDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public IEnumerable<GetMessageModelDto> GetMessagesForMe(Guid userId)
        {
            var msgList = _context.Messages.Where(
                x => x.RecipientId == userId &&
                x.MsgStatus == Models.MsgStatus.Unread)
                .Select(x => _mapper.Map<GetMessageModelDto>(x)).ToList();

            _context.Messages.Where(
                x => x.RecipientId == userId &&
                x.MsgStatus == Models.MsgStatus.Unread).ExecuteUpdate(setter =>
                setter.SetProperty(x => x.MsgStatus, Models.MsgStatus.Read));
            _context.SaveChanges();

            return msgList;
        }

        public bool SendMsg(SendMessageModelDto messageModelDto, Guid senderId)
        {
            MessageModel msgEntity = new MessageModel {
                RecipientId = messageModelDto.RecipientId, 
                Content = messageModelDto.Content, 
                SenderId = senderId, 
                MsgStatus = MsgStatus.Unread 
            };
            _context.Messages.Add(msgEntity);
            _context.SaveChanges();
            return true;
        }
    }
}
