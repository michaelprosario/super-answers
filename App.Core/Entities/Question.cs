using System;
using System.Runtime.Serialization;

namespace App.Core.Entities
{
    [DataContract]
    public class Question
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string QuestionTitle { get; set; }

        [DataMember]
        public string Tags { get; set; }

        [DataMember]
        public string[] TagArray
        {
            get
            {
                string[] array = Tags.Split(',');
                return array;
            }
        }

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
        [DataMember]
        public int Votes { get; set; }
    }
}
