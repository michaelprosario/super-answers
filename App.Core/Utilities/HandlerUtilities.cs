using App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Utilities
{
    public class HandlerUtilities
    {
        public static void TimeStampRecord(object record, string userId)
        {
            if (record is ITimeStampedEntity)
            {
                ITimeStampedEntity timeStampedEntity = (ITimeStampedEntity)record;
                timeStampedEntity.CreatedAt = DateTime.Now;
                timeStampedEntity.UpdatedAt = DateTime.Now;
                timeStampedEntity.CreatedBy = userId;
                timeStampedEntity.UpdatedBy = userId;
            }
        }
    }
}
