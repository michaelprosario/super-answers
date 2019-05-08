using System.Runtime.Serialization;
using App.Core.Enums;
using System.Collections.Generic;
using FluentValidation.Results;

namespace App.Core.Requests
{
    [DataContract]
    public class Response{

        [DataMember]
        public ResponseCode Code {get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public IList<ValidationFailure> ValidationErrors { get; set; }
    }   
}