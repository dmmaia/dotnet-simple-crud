    using user_register_test.Model;
    using user_register_test.Repository;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    namespace user_register_test.Controller
    {
        [ApiController]
        [Route("/api/[controller]")]
        public class UserController : ControllerBase
        {
            private readonly IUserRepository _userRepository;
            public UserController(IUserRepository userRepository)
            {
                _userRepository = userRepository;
            }
            [HttpGet]
            [Produces(typeof(User))]
            public IActionResult Get()
            {
                var users = _userRepository.GetAll();
                if (users.Count() == 0)
                    return NoContent();
                return Ok(users);
            }
        }
    }