    using System.Collections.Generic;
    using user_register_test.Model;
    
    namespace user_register_test.Repository
    {
        public interface IUserRepository
        {
            IEnumerable<User> GetAll();
        }
    }