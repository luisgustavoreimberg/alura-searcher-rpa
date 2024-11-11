namespace AluraSearcherRPA.Infrastructure.Queries
{
    internal class SearchQueries
    {
        public static string InsertQuery
        {
            get
            {
                return "INSERT INTO SearchResult (SearchedValue, SearchDate, Title, Instructor, Duration, Description) "
                     + "VALUES(@SearchedValue, @SearchDate, @Title, @Instructor, @Duration, @Description)";
            }
        }
        public static string SelectAllQuery
        {
            get
            {
                return "SELECT * FROM SearchResult";
            }
        }
        public static string SelectByIdQuery
        {
            get
            {
                return "SELECT * FROM SearchResult WHERE Id = @Id";
            }
        }
        public static string SelectBySearchValueQuery
        {
            get
            {
                return "SELECT * FROM SearchResult WHERE SearchValue = @SearchValue";
            }
        }
    }
}
