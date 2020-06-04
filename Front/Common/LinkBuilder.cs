using Front.Helpers;
using System;

namespace Front.Common
{
    public static class LinkBuilder
    {
        public static string BuildLinkWithIdParam(string path, Guid id)
        {
            var parsed = BuildPath(path, new UriParameter { Name = "Id", Value = id });
            return BuildLink(parsed);
        }

        public static string BuildPath(string path, UriParameter parameter)
        {
            path = NormalizePath(path);
            var start = path.IndexOf('{');
            var end = path.IndexOf('}');
            if (start < 0 || end < 0 || start > end)
                throw new InvalidOperationException();

            var substitution = path.Substring(start, end - start + 1);

            return path.ReplaceWithParameter(substitution, parameter);
        }

        public static string BuildLink(string path)
        {
            return $"/{NormalizePath(path)}";
        }

        public static string NormalizePath(string path)
        {
            return path.Trim('/', '\\');
        }
    }
}