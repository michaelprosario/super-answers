using App.Core.Entities;
using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using System.Collections.Generic;
using System.Runtime.Serialization;
using AutoMapper;

namespace App.Core.Handlers
{
    public class ListQuestionAnswersQuery : Query<ListQuestionAnswersResponse>, IUserRequest
    {
        public string UserId { get; set; }
    }

    [DataContract]
    public class ListQuestionAnswersResponse : Response
    {
        [DataMember]
        public IList<QuestionAnswer> Records;
    }

    public class ListQuestionAnswersHandler : BaseHandler<ListQuestionAnswersQuery, ListQuestionAnswersResponse>
    {
        IRepository<DbEntities.QuestionAnswer> _repository;
        private readonly IMapper _mapper;

        public ListQuestionAnswersHandler(IRepository<DbEntities.QuestionAnswer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        protected override ListQuestionAnswersResponse Handle(ListQuestionAnswersQuery query)
        {
            var response = new ListQuestionAnswersResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(query, "Request is null.");
            response.Records = new List<QuestionAnswer>();
            foreach (var dbRecord in _repository.List())
            {
                response.Records.Add(_mapper.Map<QuestionAnswer>(dbRecord));
            }

            return response;
        }
    }
}
