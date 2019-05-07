using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Interfaces
{
    interface ITimeStampedEntity
    {
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}
