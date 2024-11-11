using AluraSearcherRPA.Domain.Entities;
using AluraSearcherRPA.Infrastructure.Interfaces;
using AluraSearcherRPA.Infrastructure.Queries;
using Dapper;
using Npgsql;

namespace AluraSearcherRPA.Infrastructure.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private readonly string _connectionString;
        private NpgsqlConnection _databaseConnection
        {
            get
            {
                return new NpgsqlConnection(_connectionString);
            }
        }

        public SearchRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Insert(SearchResult courseData)
        {
            using (var dbConnection = _databaseConnection)
            {
                courseData = LimitFields(courseData);

                dbConnection.Open();
                dbConnection.Execute(SearchQueries.InsertQuery, courseData);
            }
        }
        public IEnumerable<SearchResult> SelectAll()
        {
            using (var dbConnection = _databaseConnection)
            {
                dbConnection.Open();
                return dbConnection.Query<SearchResult>(SearchQueries.SelectAllQuery);
            }
        }
        public SearchResult? SelectById(long id)
        {
            using (var dbConnection = _databaseConnection)
            {
                dbConnection.Open();
                return dbConnection.QueryFirstOrDefault<SearchResult>(SearchQueries.SelectByIdQuery, new { Id = id });
            }
        }
        public IEnumerable<SearchResult> SelectBySearchValue(string searchedValue)
        {
            using (var dbConnection = _databaseConnection)
            {
                dbConnection.Open();
                return dbConnection.Query<SearchResult>(SearchQueries.SelectBySearchValueQuery, new { SearchValue = searchedValue });
            }
        }

        private SearchResult LimitFields(SearchResult courseData)
        {
            if (courseData.SearchedValue?.Length > 255)
            {
                courseData.SearchedValue = courseData.SearchedValue.Substring(0, 255);
            }

            if (courseData.Title?.Length > 255)
            {
                courseData.Title = courseData.Title.Substring(0, 255);
            }

            if (courseData.Instructor?.Length > 255)
            {
                courseData.Instructor = courseData.Instructor.Substring(0, 255);
            }

            if (courseData.Description?.Length > 255)
            {
                courseData.Description = courseData.Description.Substring(0, 255);
            }

            if (courseData.Duration?.Length > 10)
            {
                courseData.Duration = courseData.Duration.Substring(0, 255);
            }

            return courseData;
        }
    }
}
