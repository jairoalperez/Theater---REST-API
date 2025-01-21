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
        }
    }
}