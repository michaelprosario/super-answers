using System;
using App.Core.Interfaces;
using App.Core.SharedKernel;

namespace App.Core.DbEntities
{
    public class Question : BaseEntity, ITimeStampedEntity
    {
        public string Id { get; set; }

        public string QuestionTitle { get; set; }

        public string Content { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
