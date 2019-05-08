using App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Utilities
{
    public class HandlerUtilities
    {
        public static void TimeStampRecord(object record, string userId, bool newRecordOperation)
        {
            if (record is ITimeStampedEntity)
            {
                ITimeStampedEntity timeStampedEntity = (ITimeStampedEntity)record;
                if (newRecordOperation)
                {
                    timeStampedEntity.CreatedAt = DateTime.Now;
                    timeStampedEntity.CreatedBy = userId;
                }
                else
                {
                    timeStampedEntity.UpdatedAt = DateTime.Now;
                    timeStampedEntity.UpdatedBy = userId;
                }
            }
        }
    }
}
