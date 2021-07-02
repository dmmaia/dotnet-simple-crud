    using System.Collections.Generic;
    using user_register_test.Model;
    using MySqlConnector;
    using Dapper;
    namespace user_register_test.Repository
    {
        public class UserRepository : IUserRepository
        {
            private readonly string _connectionString;
            public UserRepository(string connectionString)
            {
                _connectionString = connectionString;   // Injetando a string de conexão no construtor da classe
            }
            public IEnumerable<User> GetAll()
            {
                using(MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    return connection.Query<User>("SELECT _id, name, login, password FROM User ORDER BY name ASC");
                }
            }
        }
    }