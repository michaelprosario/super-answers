using System.Runtime.Serialization;

namespace App.Core.SharedKernel
{
    public abstract class BaseEntity
    {
        [DataMember]
        public string Id { get; set; }
    }
}