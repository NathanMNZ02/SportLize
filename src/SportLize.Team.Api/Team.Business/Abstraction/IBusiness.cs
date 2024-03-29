﻿using SportLize.Team.Api.Team.Repository.Model;
using SportLize.Team.Api.Team.Shared.Dto;

namespace SportLize.Team.Api.Team.Business.Abstraction
{
    public interface IBusiness
    {
        #region INSERT
        Task<GroupReadDto> InsertGroup(GroupWriteDto groupWriteDto, CancellationToken cancellationToken = default);
        Task<UserKafka> InsertUserToGroup(int groupId, UserKafka userKafka, CancellationToken cancellationToken = default);
        Task<MessageReadDto> InsertMessageToGroup(int groupId, MessageWriteDto messageWriteDto, CancellationToken cancellationToken = default);
        Task<UserKafka> InsertUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default);
        #endregion

        #region UPDATE
        Task<GroupReadDto> UpdateGroup(GroupReadDto groupReadDto, CancellationToken cancellationToken = default);
        Task<MessageReadDto> UpdateMessage(MessageReadDto messageReadDto, CancellationToken cancellationToken = default);
        Task<UserKafka> UpdateUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default);
        #endregion

        #region GET
        Task<List<GroupReadDto>?> GetAllGroup(CancellationToken cancellationToken = default);

        Task<List<UserKafka>?> GetAllUserKafka(CancellationToken cancellationToken = default);
        Task<List<MessageReadDto>?> GetAllMessagesOfGroup(int groupId, CancellationToken cancellationToken = default);
        Task<List<UserKafka>?> GetAllUserKafkaOfGroup(int groupId, CancellationToken cancellationToken = default);
        Task<GroupReadDto?> GetGroup(int id, CancellationToken cancellationToken = default);
        Task<MessageReadDto?> GetMessage(int id, CancellationToken cancellationToken = default);
        Task<UserKafka?> GetUserKafka(int id, CancellationToken cancellationToken = default);
        #endregion

        #region DELETE
        Task<GroupReadDto> DeleteGroup(GroupReadDto groupId, CancellationToken cancellationToken = default);
        Task<MessageReadDto> DeleteMessage(MessageReadDto messageReadDto, CancellationToken cancellationToken = default);
        Task<UserKafka> DeleteUserKafka(UserKafka userKafka, CancellationToken cancellationToken = default);
        #endregion

    }
}
