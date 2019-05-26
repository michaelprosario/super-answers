using System.Collections.Generic;
using System.Linq;
using App.Core.Entities;
using App.Core.Requests;
using MediatR;
using System.Runtime.Serialization;
using App.Core.Aggregates;
using App.Core.Utilities;

namespace App.Core.Handlers
{
    public class GetMostRecentQuestionsRequest : IRequest<GetMostRecentQuestionsResponse>
    {
        public string UserId { get; set; }
    }

    [DataContract]
    public class GetMostRecentQuestionsResponse : Response
    {
        [DataMember]
        public IList<Question> Questions;
    }

    public class GetMostRecentQuestionsHandler : BaseHandler<GetMostRecentQuestionsRequest, GetMostRecentQuestionsResponse>
    {
        private readonly IQuestions _questions;

        public GetMostRecentQuestionsHandler(IQuestions questions)
        {
            _questions = questions;
        }

        protected override GetMostRecentQuestionsResponse Handle(GetMostRecentQuestionsRequest request)
        {
            Require.ObjectNotNull(request, "request should not be null");

            var response = new GetMostRecentQuestionsResponse
            {
                Questions = _questions.GetMostRecentQuestions().ToList()
            };

            return response;
        }
    }
}