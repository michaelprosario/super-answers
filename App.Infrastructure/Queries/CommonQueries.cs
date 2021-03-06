﻿namespace App.Infrastructure.Queries
{
    public class CommonQueries
    {
        public static string GetQuestionSql()
        {
            return @"
                    select distinct
                    Id,
                    QuestionTitle,
                    Tags,
                    Content,
                    CreatedBy,
                    CreatedAt,
                    UpdatedBy,
                    UpdatedAt,
                    (select count(*) from QuestionVotes qv where qv.QuestionId = questions.Id) Votes,
                    (select count(*) from QuestionViews qview where qview.QuestionId = questions.Id) Views,
                    (select count(*) from QuestionAnswers qa where qa.QuestionId = questions.Id and IsDeleted = 0) AnswerCount
                    from questions
                    where IsDeleted = 0
                    ";
        }
    }
}