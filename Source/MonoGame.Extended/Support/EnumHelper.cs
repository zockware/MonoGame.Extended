﻿using System;

namespace MonoGame.Extended.Support
{

    /// <summary>Helper methods for enumerations</summary>
    public static class EnumHelper
    {

        /// <summary>Returns the highest value encountered in an enumeration</summary>
        /// <typeparam name="EnumType">
        ///   Enumeration of which the highest value will be returned
        /// </typeparam>
        /// <returns>The highest value in the enumeration</returns>
        public static EnumType GetHighestValue<EnumType>() where EnumType : IComparable
        {
            EnumType[] values = GetValues<EnumType>();

            // If the enumeration is empty, return nothing
            if (values.Length == 0)
            {
                return default(EnumType);
            }

            // Look for the highest value in the enumeration. We initialize the highest value
            // to the first enumeration value so we don't have to use some arbitrary starting
            // value which might actually appear in the enumeration.
            EnumType highestValue = values[0];
            for (int index = 1; index < values.Length; ++index)
            {
                if (values[index].CompareTo(highestValue) > 0)
                {
                    highestValue = values[index];
                }
            }

            return highestValue;
        }

        /// <summary>Returns the lowest value encountered in an enumeration</summary>
        /// <typeparam name="EnumType">
        ///   Enumeration of which the lowest value will be returned
        /// </typeparam>
        /// <returns>The lowest value in the enumeration</returns>
        public static EnumType GetLowestValue<EnumType>() where EnumType : IComparable
        {
            EnumType[] values = GetValues<EnumType>();

            // If the enumeration is empty, return nothing
            if (values.Length == 0)
            {
                return default(EnumType);
            }

            // Look for the lowest value in the enumeration. We initialize the lowest value
            // to the first enumeration value so we don't have to use some arbitrary starting
            // value which might actually appear in the enumeration.
            EnumType lowestValue = values[0];
            for (int index = 1; index < values.Length; ++index)
            {
                if (values[index].CompareTo(lowestValue) < 0)
                {
                    lowestValue = values[index];
                }
            }

            return lowestValue;
        }

        /// <summary>Retrieves a list of all values contained in an enumeration</summary>
        /// <typeparam name="EnumType">
        ///   Type of the enumeration whose values will be returned
        /// </typeparam>
        /// <returns>All values contained in the specified enumeration</returns>
        /// <remarks>
        ///   This method produces collectable garbage so it's best to only call it once
        ///   and cache the result.
        /// </remarks>
        public static EnumType[] GetValues<EnumType>()
        {
            return (EnumType[])Enum.GetValues(typeof(EnumType));
        }
    }

}