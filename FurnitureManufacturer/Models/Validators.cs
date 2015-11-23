namespace FurnitureManufacturer.Models
{
    using System;

    public static class Validators
    {
        public static void ValidateNull(string value, string type)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value), string.Format(ModelConstants.CantBeNull, type));
            }
        }

        public static void ValidateNullEmpty(string value, string type)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(string.Format(ModelConstants.CantBeNullEmpty, type), nameof(value));
            }
        }

        public static void ValidateLength(string value, int minLength, string type)
        {
            if (value.Trim().Length < minLength)
            {
                throw new ArgumentException(string.Format(ModelConstants.LengthNotMeet, type, minLength), nameof(value));
            }
        }

        public static void ValidatePositiveNum(dynamic value, string type)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(string.Format(ModelConstants.NumberCantBeNegative, type));
            }
        }
    }
}