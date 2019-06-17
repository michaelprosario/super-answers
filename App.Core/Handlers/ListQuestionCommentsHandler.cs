using App.Core.Entities;
using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using MediatR;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using AutoMapper;

namespace App.Core.Handlers
{
    public class ListQuestionCommentsQuery : IRequest<ListQuestionCommentsResponse>, IUserRequest
    {
        public string UserId { get; set; }
    }

    [DataContract]
    public class ListQuestionCommentsResponse : Response
    {
        [DataMember]
        public IList<QuestionComment> Records;
    }

    public class ListQuestionCommentsHandler : BaseHandler<ListQuestionCommentsQuery, ListQuestionCommentsResponse>
    {
        IRepository<DbEntities.QuestionComment> _repository;
        private readonly IMapper _mapper;

        public ListQuestionCommentsHandler(IRepository<DbEntities.QuestionComment> repository)
        {
            _repository = repository;
        }
        protected override ListQuestionCommentsResponse Handle(ListQuestionCommentsQuery query)
        {
            var response = new ListQuestionCommentsResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(query, "Query is null.");
            response.Records = new List<QuestionComment>();
            foreach (var dbRecord in _repository.List())
            {
                var entity = _mapper.Map<QuestionComment>(dbRecord);
                response.Records.Add(entity);
            }

            return response;
        }
    }
}
