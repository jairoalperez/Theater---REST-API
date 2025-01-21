namespace Actors_RestAPI.Helpers
{
    public class Messages
    {
        public static class API
        {
            public const string Working
                                = "API is working"; 
        }

        public static class Database
        {
            public const string NoConnectionString
                                = "No connection string found in appsettings.json";
            public const string ConnectionSuccess
                                = "Database is connected successfully";
            public const string ConnectionFailed
                                = "Database connection failed";
            public const string ProblemRelated
                                = "Problem Related to the Database Call";
        }

        public static class Actors
        {
            public const string NotFound
                                = "No actors found";
        }
    }
}