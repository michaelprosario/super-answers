using System.Collections.Generic;
using System.Linq;
using App.Core.Entities;
using App.Core.Requests;
using System.Runtime.Serialization;
using App.Core.Aggregates;
using App.Core.Utilities;

namespace App.Core.Handlers
{
    public class SearchByKeywordQuery : Query<SearchByKeywordResponse>
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

    public class SearchByKeywordHandler : BaseHandler<SearchByKeywordQuery, SearchByKeywordResponse>
    {
        private readonly IQuestions _questions;

        public SearchByKeywordHandler(IQuestions questions)
        {
            _questions = questions;
        }

        protected override SearchByKeywordResponse Handle(SearchByKeywordQuery query)
        {
            Require.ObjectNotNull(query, "request should not be null");

            var response = new SearchByKeywordResponse
            {
                Questions = _questions.SearchByKeyword(query.SearchTerms).ToList()
            };

            return response;
        }
    }
}