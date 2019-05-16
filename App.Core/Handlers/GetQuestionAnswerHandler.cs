using App.Core.Entities;
using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using MediatR;
using System.Runtime.Serialization;

namespace App.Core.Handlers
{
    public class GetQuestionAnswerRequest : IRequest<GetQuestionAnswerResponse>, IUserRequest
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }

    [DataContract]
    public class GetQuestionAnswerResponse : Response
    {
        [DataMember] public QuestionAnswer QuestionAnswer;
    }

    public class GetQuestionAnswerHandler : BaseHandler<GetQuestionAnswerRequest, GetQuestionAnswerResponse>
    {
        readonly IRepository<DbEntities.QuestionAnswer> _repository;

        public GetQuestionAnswerHandler(IRepository<DbEntities.QuestionAnswer> repository)
        {
            _repository = repository;
        }

        protected override GetQuestionAnswerResponse Handle(GetQuestionAnswerRequest request)
        {
            var response = new GetQuestionAnswerResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(request, "Request is null.");
            var dbRecord = _repository.GetById(request.Id);
            if (dbRecord == null)
            {
                response.Code = ResponseCode.NotFound;
                return response;
            }

            var entity = EntityMapper.GetEntity(dbRecord);

            response.QuestionAnswer = entity;
            return response;
        }
    }
}
