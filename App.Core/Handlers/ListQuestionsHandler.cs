using App.Core.Entities;
using App.Core.Enums;
using App.Core.Interfaces;
using App.Core.Requests;
using App.Core.Utilities;
using MediatR;
using System.Collections.Generic;
using System.Runtime.Serialization;

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
        IRepository<Question> _repository;
        public ListQuestionsHandler(IRepository<Question> repository)
        {
            _repository = repository;
        }
        protected override ListQuestionsResponse Handle(ListQuestionsRequest request)
        {
            var response = new ListQuestionsResponse
            {
                Code = ResponseCode.Success
            };

            Require.ObjectNotNull(request, "Request is null.");
            response.Records = _repository.List(); 
            return response;
        }
    }
}