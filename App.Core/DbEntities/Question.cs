﻿using System;
using App.Core.Interfaces;
using App.Core.SharedKernel;

namespace App.Core.DbEntities
{
    public class Question : BaseEntity, ITimeStampedEntity, ILogicalDelete
    {
        public string QuestionTitle { get; set; }

        public string Tags { get; set; }

        public string Content { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeleteAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
