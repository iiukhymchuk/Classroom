﻿namespace Front.Common
{
    public static class RouteConstants
    {
        public const string Classes = "/classes";
        public const string CreateClass = "/classes/new";
        public const string Class = "/classes/{id:guid}";
        public const string Courses = "/courses";
        public const string CreateCourse = "/courses/new";
        public const string Course = "/courses/{id:guid}";
        public const string Error = "/error/{code:int}";
    }
}