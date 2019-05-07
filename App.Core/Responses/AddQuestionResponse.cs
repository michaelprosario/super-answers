using App.Core.Requests;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace App.Core.Responses
{
    public class AddQuestionResponse : Response
    {
        [DataMember]
        public string Id { get; set; }
    }
}
