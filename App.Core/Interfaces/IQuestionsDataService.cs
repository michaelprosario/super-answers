
using System.Collections.Generic;
using App.Core.Entities;

namespace App.Core.Interfaces
{
    public interface IQuestionsDataService
    {
        IList<QuestionAnswer> GetAnswersForQuestion(string questionId);
        int GetQuestionVotes(string id);

        bool QuestionVoteAlreadyExists(string userId, string questionId);
    }
}
