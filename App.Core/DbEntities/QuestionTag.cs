﻿using App.Core.SharedKernel;

namespace App.Core.DbEntities
{
    public class QuestionTag : BaseEntity
    {
        public string QuestionId { get; set; }
        public string TopicTagId { get; set; }
    }
}