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
    public class ListQuestionsQuery : Query<ListQuestionsResponse>, IUserRequest
    {
        public string UserId { get; set; }
    }

    [DataContract]
    public class ListQuestionsResponse : Response
    {
        [DataMember]
        public IList<Question> Records;
    }

    public class ListQuestionsHandler : BaseHandler<ListQuestionsQuery, ListQuestionsResponse>
    {
        IRepository<DbEntities.Question> _repository;
        private readonly IMapper _mapper;

        public ListQuestionsHandler(IRepository<DbEntities.Question> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        protected override ListQuestionsResponse Handle(ListQuestionsQuery query)
        {
            var response = new ListQuestionsResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(query, "Request is null.");
            response.Records = new List<Question>();
            foreach (var dbRecord in _repository.List())
            {
                response.Records.Add(_mapper.Map<Question>(dbRecord));
            }

            return response;
        }
    }
}