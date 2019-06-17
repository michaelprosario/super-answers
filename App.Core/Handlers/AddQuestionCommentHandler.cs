using App.Core.Entities;
using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using FluentValidation;
using MediatR;
using System.Runtime.Serialization;
using System;

namespace App.Core.Handlers
{
    public class AddQuestionCommentCommand : IRequest<AddQuestionCommentResponse>, IUserRequest
    {
        
            [DataMember(Order = 1)]
            public string QuestionId { get; set; }
            [DataMember(Order = 2)]
            public string Comment { get; set; }
            [DataMember(Order = 3)]
            public DateTime CreatedAt { get; set; }
            [DataMember(Order = 4)]
            public string CreatedBy { get; set; }
            [DataMember(Order = 5)]
            public DateTime UpdatedAt { get; set; }
            [DataMember(Order = 6)]
            public string UpdatedBy { get; set; }
        public string UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public class AddQuestionCommentCommandValidator : AbstractValidator<AddQuestionCommentCommand>
    {
        public AddQuestionCommentCommandValidator()
        {

        }
    }

    public class AddQuestionCommentResponse : Response
    {
        [DataMember] public string Id { get; set; }
    }

    public class AddQuestionCommentHandler : BaseHandler<AddQuestionCommentCommand, AddQuestionCommentResponse>
    {
        readonly IRepository<DbEntities.QuestionComment> _repository;

        public AddQuestionCommentHandler(IRepository<DbEntities.QuestionComment> repository)
        {
            _repository = repository;
        }

        protected override AddQuestionCommentResponse Handle(AddQuestionCommentCommand command)
        {
            var response = new AddQuestionCommentResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(command, "Command is null.");
            var validationResult = new AddQuestionCommentCommandValidator().Validate(command);
            if (!validationResult.IsValid)
            {
                response.ValidationErrors = validationResult.Errors;
                return response;
            }

            var record = new DbEntities.QuestionComment();
            
            record.QuestionId = command.QuestionId; 
            record.Comment = command.Comment; 
            record.CreatedAt = command.CreatedAt; 
            record.CreatedBy = command.CreatedBy; 
            record.UpdatedAt = command.UpdatedAt; 
            record.UpdatedBy = command.UpdatedBy; 
    
            HandlerUtilities.TimeStampRecord(record, command.UserId, true);
            var returnRecord = _repository.Add(record);
            response.Id = returnRecord.Id;

            return response;
        }
    }
}
