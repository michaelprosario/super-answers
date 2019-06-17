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
    public class EditQuestionCommentCommand : IRequest<EditQuestionCommentResponse>, IUserRequest
    {
        [DataMember(Order=1)]
        public string Id { get; set; }
        
        [DataMember(Order = 2)]
        public string QuestionId { get; set; }
        
        [DataMember(Order = 3)]
        public string Comment { get; set; }
        
        [DataMember(Order = 4)]
        public DateTime CreatedAt { get; set; }
        
        [DataMember(Order = 5)]
        public string CreatedBy { get; set; }
        
        [DataMember(Order = 6)]
        public DateTime UpdatedAt { get; set; }
        
        [DataMember(Order = 7)]
        public string UpdatedBy { get; set; }
        public string UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public class EditQuestionCommentCommandValidator : AbstractValidator<EditQuestionCommentCommand>
    {
        public EditQuestionCommentCommandValidator()
        {

        }
    }

    [DataContract]
    public class EditQuestionCommentResponse : Response
    {
    }
    
    public class EditQuestionCommentHandler : BaseHandler<EditQuestionCommentCommand, EditQuestionCommentResponse>
    {

        IRepository<DbEntities.QuestionComment> _repository;
        public EditQuestionCommentHandler(IRepository<DbEntities.QuestionComment> repository)
        {
            _repository = repository;
        }
        protected override EditQuestionCommentResponse Handle(EditQuestionCommentCommand command)
        {

            var response = new EditQuestionCommentResponse
            {

                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(command, "Command is null.");
            var validationResult = new EditQuestionCommentCommandValidator().Validate(command);
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
            record.Id = command.Id;    
            _repository.Update(record);

            HandlerUtilities.TimeStampRecord(record, command.UserId, false);
            _repository.Update(record);

            return response;
        }
    }
}
