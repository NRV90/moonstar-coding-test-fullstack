using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Shared.Extensions
{
    public static class ValidationsExtension
    {
        public static IEnumerable<T> ThrowIfNullOrEmpty<T>(this IEnumerable<T> obj, string argumentName)
        {
            ThrowIfNull(obj, argumentName);

            if (!obj.Any()) throw new ArgumentNullException(argumentName);

            return obj;
        }

        public static string ThrowIfNullOrEmpty(this string obj, string argumentName)
        {
            if (string.IsNullOrEmpty(obj))
            {
                throw new ArgumentNullException(argumentName);
            }

            return obj;
        }

        public static T ThrowIfNull<T>(this T obj, string argumentName)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(argumentName);
            }

            return obj;
        }

        public static IEnumerable<T> ThrowIfEmpty<T>(this IEnumerable<T> obj, string argumentName)
        {
            if (!obj.Any())
            {
                throw new ArgumentException(argumentName);
            }

            return obj;
        }

        public static Guid ThrowIfEmpty(this Guid guid, string argumentName)
        {
            if (Guid.Empty == guid)
            {
                throw new ArgumentException(argumentName);
            }

            return guid;
        }
    }
}
