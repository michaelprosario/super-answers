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
    public class ListQuestionTagsRequest : IRequest<ListQuestionTagsResponse>, IUserRequest
    {
        public string UserId { get; set; }
    }

    [DataContract]
    public class ListQuestionTagsResponse : Response
    {
        [DataMember]
        public IList<QuestionTag> Records;
    }

    public class ListQuestionTagsHandler : BaseHandler<ListQuestionTagsRequest, ListQuestionTagsResponse>
    {
        IRepository<DbEntities.QuestionTag> _repository;
        private readonly IMapper _mapper;

        public ListQuestionTagsHandler(IRepository<DbEntities.QuestionTag> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        protected override ListQuestionTagsResponse Handle(ListQuestionTagsRequest request)
        {
            var response = new ListQuestionTagsResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(request, "Request is null.");
            response.Records = new List<QuestionTag>();
            foreach (var dbRecord in _repository.List())
            {
                response.Records.Add(_mapper.Map<QuestionTag>(dbRecord));
            }

            return response;
        }
    }

}
