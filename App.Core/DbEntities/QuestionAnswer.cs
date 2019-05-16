using App.Core.SharedKernel;
using System.Runtime.Serialization;
using System;
using App.Core.Interfaces;

namespace App.Core.DbEntities {
    [DataContract]
    public class QuestionAnswer : BaseEntity, ITimeStampedEntity
    {
        [DataMember]
        public string QuestionId { get; set; }
        
        [DataMember]
        public string Answer { get; set; }
        
        [DataMember]
        public DateTime CreatedAt { get; set; }
        
        [DataMember]
        public string CreatedBy { get; set; }
        
        [DataMember]
        public DateTime UpdatedAt { get; set; }
        
        [DataMember]
        public string UpdatedBy { get; set; }
        
        [DataMember]
        public int Votes { get; set; }
            
    } 
}

