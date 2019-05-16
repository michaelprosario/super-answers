
using System.Runtime.Serialization;
using System;

namespace App.Core.Entities
{
    [DataContract]
    public class QuestionAnswer
    {
        [DataMember] public string QuestionId { get; set; }
        [DataMember] public string Answer { get; set; }
        [DataMember] public DateTime CreatedAt { get; set; }
        [DataMember] public string CreatedBy { get; set; }
        [DataMember] public DateTime UpdatedAt { get; set; }
        [DataMember] public string UpdatedBy { get; set; }
        [DataMember] public int Votes { get; set; }
        [DataMember] public string Id { get; set; }
    }
}
