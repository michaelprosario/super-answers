using System;

namespace App.Core.Interfaces
{
    public interface ILogicalDelete
    {
        string DeletedBy { get; set; }
        DateTime? DeleteAt { get; set; }
        bool IsDeleted { get; set; }
    }
}
