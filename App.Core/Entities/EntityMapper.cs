using System;
using App.Core.DbEntities;

namespace App.Core.Entities
{
    public class EntityMapper
    {
        public static Question GetEntity(DbEntities.Question dbRecord)
        {
            Utilities.Require.ObjectNotNull(dbRecord, "dbRecord should not be null");

            return new Question()
            {
                Id = dbRecord.Id,
                QuestionTitle = dbRecord.QuestionTitle,
                Content = dbRecord.Content,
                Tags = dbRecord.Tags,
                CreatedBy = dbRecord.CreatedBy,
                CreatedAt = dbRecord.CreatedAt,
                UpdatedAt = dbRecord.UpdatedAt,
                UpdatedBy = dbRecord.UpdatedBy
            };
        }

        public static QuestionTag GetEntity(DbEntities.QuestionTag dbRecord)
        {
            return new QuestionTag()
            {
                Id = dbRecord.Id,
                Title = dbRecord.Title,
                CreatedBy = dbRecord.CreatedBy,
                CreatedAt = dbRecord.CreatedAt,
                UpdatedAt = dbRecord.UpdatedAt,
                UpdatedBy = dbRecord.UpdatedBy
            };
        }

        public static QuestionAnswer GetEntity(DbEntities.QuestionAnswer dbRecord)
        {
            var questionAnswer = new QuestionAnswer
            {
                CreatedAt = dbRecord.CreatedAt,
                Answer = dbRecord.Answer,
                CreatedBy = dbRecord.CreatedBy,
                Id = dbRecord.Id,
                QuestionId = dbRecord.QuestionId,
                UpdatedAt = dbRecord.UpdatedAt,
                UpdatedBy = dbRecord.UpdatedBy,
                Votes = dbRecord.Votes
            };

            return questionAnswer;
        }
    }
}
