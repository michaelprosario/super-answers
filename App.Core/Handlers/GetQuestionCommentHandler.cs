using App.Core.Entities;
using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using MediatR;
using System.Runtime.Serialization;
using AutoMapper;

namespace App.Core.Handlers
{
    public class GetQuestionCommentQuery : IRequest<GetQuestionCommentResponse>, IUserRequest
    {
        public string Id { get; set; }
        public string UserId { get; set; }
    }

    [DataContract]
    public class GetQuestionCommentResponse : Response
    {
        [DataMember] public QuestionComment QuestionComment;
    }

    public class GetQuestionCommentHandler : BaseHandler<GetQuestionCommentQuery, GetQuestionCommentResponse>
    {
        readonly IRepository<DbEntities.QuestionComment> _repository;
        private readonly IMapper _mapper;
        
        public GetQuestionCommentHandler(IRepository<DbEntities.QuestionComment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        protected override GetQuestionCommentResponse Handle(GetQuestionCommentQuery query)
        {
            var response = new GetQuestionCommentResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(query, "Query is null.");
            var dbRecord = _repository.GetById(query.Id);
            var entity = _mapper.Map<QuestionComment>(dbRecord);

            if (dbRecord == null)
            {
                response.Code = ResponseCode.NotFound;
                return response;
            }

            response.QuestionComment = entity;
            return response;
        }
    }
}
