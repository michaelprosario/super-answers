using System;

namespace App.Core.Utilities
{
    public class Require
    {
        public static void ObjectNotNull(Object currentObject, string message)
        {
            if (currentObject == null)
            {
                throw new ArgumentNullException(message);
            }
        }

        public static void NotNullOrEmpty(string input, string message)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException(message);
            }
        }
    }
}
