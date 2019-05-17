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
    public class ListQuestionsRequest : IRequest<ListQuestionsResponse>, IUserRequest
    {
        public string UserId { get; set; }
    }

    [DataContract]
    public class ListQuestionsResponse : Response
    {
        [DataMember]
        public IList<Question> Records;
    }

    public class ListQuestionsHandler : BaseHandler<ListQuestionsRequest, ListQuestionsResponse>
    {
        IRepository<DbEntities.Question> _repository;
        private readonly IMapper _mapper;

        public ListQuestionsHandler(IRepository<DbEntities.Question> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        protected override ListQuestionsResponse Handle(ListQuestionsRequest request)
        {
            var response = new ListQuestionsResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(request, "Request is null.");
            response.Records = new List<Question>();
            foreach (var dbRecord in _repository.List())
            {
                response.Records.Add(_mapper.Map<Question>(dbRecord));
            }

            return response;
        }
    }
}