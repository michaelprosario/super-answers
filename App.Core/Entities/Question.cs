
using System;
using System.Runtime.Serialization;
using App.Core.Interfaces;
using App.Core.SharedKernel;

namespace App.Core.Entities
{
    [DataContract]
    public class Question : BaseEntity, ITimeStampedEntity
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string QuestionTitle { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public string CreatedBy { get; set; }
        [DataMember]
        public string UpdatedBy { get; set; }
        [DataMember]
        public DateTime CreatedAt { get; set; }
        [DataMember]
        public DateTime UpdatedAt { get; set; }
    }
}
