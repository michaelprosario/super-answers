using App.Core.SharedKernel;
using System.Runtime.Serialization;
using System;
using App.Core.Interfaces;

namespace App.Core.DbEntities {
    [DataContract]
    public class QuestionTag : BaseEntity, ITimeStampedEntity
    {
        [DataMember]
        public string Title { get; set; }
        
        [DataMember]
        public DateTime CreatedAt { get; set; }
        
        [DataMember]
        public string CreatedBy { get; set; }
        
        [DataMember]
        public DateTime UpdatedAt { get; set; }
        
        [DataMember]
        public string UpdatedBy { get; set; }            
    } 
}
