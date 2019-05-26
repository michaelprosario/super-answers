using System.Collections.Generic;
using System.Linq;
using App.Core.Entities;
using App.Core.Interfaces;
using App.Core.Requests;
using MediatR;
using System.Runtime.Serialization;
using App.Core.Aggregates;
using App.Core.Utilities;

namespace App.Core.Handlers
{
    public class SearchByKeywordRequest : IRequest<SearchByKeywordResponse>
    {
        public string SearchTerms { get; set; }
        public string UserId { get; set; }
    }

    [DataContract]
    public class SearchByKeywordResponse : Response
    {
        [DataMember]
        public IList<Question> Questions;
    }

    public class SearchByKeywordHandler : BaseHandler<SearchByKeywordRequest, SearchByKeywordResponse>
    {
        private readonly IQuestions _questions;

        public SearchByKeywordHandler(IQuestions questionsFactory)
        {
            _questions = questionsFactory;
        }

        protected override SearchByKeywordResponse Handle(SearchByKeywordRequest request)
        {
            Require.ObjectNotNull(request, "request should not be null");

            var response = new SearchByKeywordResponse
            {
                Questions = _questions.SearchByKeyword(request.SearchTerms).ToList()
            };

            return response;
        }
    }
}