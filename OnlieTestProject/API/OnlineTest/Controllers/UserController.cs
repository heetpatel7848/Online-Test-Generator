using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineTest.Services.DTO;
using OnlineTest.Services.Interface;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.VisualBasic;
//using OnlineTest.Model;

namespace OnlineTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<UserDTO> Get()
        {
            var data = _userService.GetUsers();
            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post(UserDTO user)
        {
            return Ok(_userService.AddUser(user));
        }


        [HttpPut]
        public IActionResult Put(UserDTO user)
        {
            return Ok(_userService.UpdateUser(user));
        }


        [HttpDelete]
        public IActionResult Delete (int id)
        {
            return Ok(_userService.DeleteUser(id));
        }

        #region Existing Code
        //private readonly OnlineTestContext _context;
        //public UserController(OnlineTestContext context) {
        //    _context= context;
        //}

        //[HttpGet]
        //public async Task<ActionResult<User>> Get()
        //{
        //    var data = await _context.Users.ToListAsync();
        //    return Ok(data);
        //}

        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetById(int id)
        //{
        //    var data = await _context.Users.FindAsync(id);
        //    return data != null ? Ok(data) : NotFound("User Not Found");
        //}

        //[HttpPost]
        //public async Task<ActionResult<User>> Post(User user)
        //{
        //    _context.Users.Add(user);
        //    await _context.SaveChangesAsync();
        //    return Ok();
        //}

        ////[HttpDelete("{id}")]
        //public async Task<ActionResult<User>> Delete(int id)
        //{
        //    var user = await _context.Users.FindAsync(id);
        //    _context.Users.Remove(user);
        //    await _context.SaveChangesAsync();
        //    return user == null ? NotFound() : Ok();
        //}

        ////[HttpPut()]
        //public async Task<ActionResult<User>> Put(int id , User user)
        //{

        //    return Ok();
        //}
        #endregion
    }
}