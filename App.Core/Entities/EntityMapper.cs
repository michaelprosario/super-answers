﻿namespace App.Core.Entities
{
    public class EntityMapper
    {
        public static Question GetEntity(DbEntities.Question dbRecord)
        {
            return new Question()
            {
                Id = dbRecord.Id,
                QuestionTitle = dbRecord.QuestionTitle,
                Content = dbRecord.Content,
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
    }
}
