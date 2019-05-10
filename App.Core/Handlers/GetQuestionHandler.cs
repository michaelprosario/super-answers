using App.Core.Entities;
using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using MediatR;
using System.Runtime.Serialization;

namespace App.Core.Handlers
{
    public class GetQuestionRequest : IRequest<GetQuestionResponse>, IUserRequest
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }

    [DataContract]
    public class GetQuestionResponse : Response
    {
        [DataMember] public Question Question;
    }

    public class GetQuestionHandler : BaseHandler<GetQuestionRequest, GetQuestionResponse>
    {
        readonly IRepository<DbEntities.Question> _repository;

        public GetQuestionHandler(IRepository<DbEntities.Question> repository)
        {
            _repository = repository;
        }

        protected override GetQuestionResponse Handle(GetQuestionRequest request)
        {
            var response = new GetQuestionResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(request, "Request is null.");
            var dbRecord = _repository.GetById(request.Id);
            var question = EntityMapper.GetEntity(dbRecord);

            if (dbRecord == null)
            {
                response.Code = ResponseCode.NotFound;
                return response;
            }

            response.Question = question;
            return response;
        }


    }
}