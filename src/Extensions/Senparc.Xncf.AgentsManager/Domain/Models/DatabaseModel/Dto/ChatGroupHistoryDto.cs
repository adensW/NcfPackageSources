using Senparc.Ncf.Core.Models;
using Senparc.Xncf.AgentsManager.Models.DatabaseModel.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senparc.Xncf.AgentsManager.Models.DatabaseModel.Models.Dto
{
    /// <summary>
    /// ChatGroupHistory 数据库实体 DTO
    /// </summary>
    public class ChatGroupHistoryDto : DtoBase
    {
        public int ChatGroupId { get; set; }
        public int ChatTaskId { get; set; }

        public ChatGroup ChatGroup { get; set; }

        public int? FromAgentTemplateId { get; set; }

        public AgentTemplate FromAgentTemplate { get; set; }

        public int? ToAgentTemplateId { get; set; }

        public AgentTemplate ToAgentTemplate { get; set; }

        //public int? FromChatGroupMemberId { get; set; }

        //public ChatGroupMember FromChatGroupMember { get; set; }

        //public int? ToChatGroupMemberId { get; set; }

        //public ChatGroupMember ToChatGroupMember { get; set; }

        public string Message { get; set; }

        public MessageType MessageType { get; set; }

        public Status Status { get; set; }

        public ChatGroupHistoryDto() { }

        public ChatGroupHistoryDto(int chatGroupId,int chatTaskId, ChatGroup chatGroup, int fromAgentTemplateId, AgentTemplate fromAgentTemplate, int toAgentTemplateId, AgentTemplate toAgentTemplate, /*int fromChatGroupMemberId, ChatGroupMember fromChatGroupMember, int toChatGroupMemberId, ChatGroupMember toChatGroupMember,*/ string message, MessageType messageType, Status status)
        {
            ChatGroupId = chatGroupId;
            ChatTaskId = chatTaskId;
            ChatGroup = chatGroup;
            FromAgentTemplateId = fromAgentTemplateId;
            FromAgentTemplate = fromAgentTemplate;
            ToAgentTemplateId = toAgentTemplateId;
            ToAgentTemplate = toAgentTemplate;
            //FromChatGroupMemberId = fromChatGroupMemberId;
            //FromChatGroupMember = fromChatGroupMember;
            //ToChatGroupMemberId = toChatGroupMemberId;
            //ToChatGroupMember = toChatGroupMember;
            Message = message;
            MessageType = messageType;
            Status = status;
        }

        public ChatGroupHistoryDto(ChatGroupHistory chatGroupHistory)
        {
            ChatGroupId = chatGroupHistory.ChatGroupId;
            ChatTaskId = chatGroupHistory.ChatTaskId;
            ChatGroup = chatGroupHistory.ChatGroup;
            FromAgentTemplateId = chatGroupHistory.FromAgentTemplateId;
            FromAgentTemplate = chatGroupHistory.FromAgentTemplate;
            ToAgentTemplateId = chatGroupHistory.ToAgentTemplateId;
            ToAgentTemplate = chatGroupHistory.ToAgentTemplate;
            //FromChatGroupMemberId = chatGroupHistory.FromChatGroupMemberId;
            //FromChatGroupMember = chatGroupHistory.FromChatGroupMember;
            //ToChatGroupMemberId = chatGroupHistory.ToChatGroupMemberId;
            //ToChatGroupMember = chatGroupHistory.ToChatGroupMember;
            Message = chatGroupHistory.Message;
            MessageType = chatGroupHistory.MessageType;
            Status = chatGroupHistory.Status;
        }
    }
}
