using System;
using System.Runtime.CompilerServices;

namespace GameDrones.Core
{
    /// <summary>
    /// Validation util class.
    /// </summary>
    public static class Validate
    {
        #region Null and default validations

        /// <summary>
        /// Validate the provided <paramref name="value"/> is not null.
        /// </summary>
        /// <param name="value">The value to check if it is null</param>
        /// <param name="argumentName">The name of the method argument</param>
        /// <exception cref="ArgumentNullException">If the provided <paramref name="value"/> is null</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotNull(object value, string argumentName = "value")
        {
            if (value == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        #endregion

        #region String Validations

        /// <summary>
        /// Validates that the provided <paramref name="value"/> is not null or white space.
        /// </summary>
        /// <param name="value">The value to check if it is null or white space</param>
        /// <param name="argumentName">The name of the method argument</param>
        /// <exception cref="ArgumentException">If the provided <paramref name="value"/> is null or white space</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void IsNotNullOrWhiteSpace(string value, string argumentName = "value")
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                string message = $"The argument {argumentName} is null or whitespace";

                throw new ArgumentException(message, argumentName);
            }
        }

        #endregion
    }
}