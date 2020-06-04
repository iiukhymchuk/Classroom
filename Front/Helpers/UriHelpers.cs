using Front.Common;
using System;

namespace Front.Helpers
{
    public static class UriHelpers
    {
        public static string ReplaceWithParameter(this string path, string substitution, UriParameter parameter)
        {
            var nameAndType = substitution.Trim('{', '}').Split(':');

            if (nameAndType.Length == 0 || nameAndType.Length > 2)
                throw new InvalidOperationException();

            var name = nameAndType[0].ToLower();

            string type = null;

            if (nameAndType.Length == 2)
                type = nameAndType[1].ToLower();

            if (!name.Equals(parameter.Name, StringComparison.OrdinalIgnoreCase))
                throw new InvalidOperationException();

            var uriValue = parameter.Value.ToUri(type);
            return path.Replace(substitution, uriValue);
        }

        static string ToUri(this object value, string type)
        {
            if (type is null)
                return value.ToString();

            switch (type)
            {
                case "guid":
                    return ((Guid)value).ToString("N");
                default:
                    return value.ToString();
            }
        }
    }
}
