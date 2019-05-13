
using System.Runtime.Serialization;
using System;

namespace App.Core.Entities {
    [DataContract]
    public class QuestionTag
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
            
        [DataMember]
        public string Id { get; set; }
    }
}
