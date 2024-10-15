using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudApiSolution.Models;

namespace CrudApiSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly UserManagementDbContext dbContext;

        public UserController(UserManagementDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet]
        [Route("List")]

        public async Task<IActionResult> Get()
        {
            try
            {
                var userList = await dbContext.Users.ToListAsync();
                return StatusCode(StatusCodes.Status200OK, userList);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        [Route("Get/{id:int}")]

        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var user = await dbContext.Users.FirstOrDefaultAsync(e => e.Id == id);
                return StatusCode(StatusCodes.Status200OK, user);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost]
        [Route("Create")]

        public async Task<IActionResult> Create([FromBody] User newUser)
        {
            try
            {
                await dbContext.Users.AddAsync(newUser);
                await dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok" });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPut]
        [Route("Update")]

        public async Task<IActionResult> Update([FromBody] User updateUser)
        {
            try
            {
                dbContext.Users.Update(updateUser);
                await dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, new { message = "ok" });
            }
            catch (Exception ex)
            {

                throw ex;
            }
 
        }

        [HttpGet]
        [Route("Delete/{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var deleteUser = await dbContext.Users.FirstOrDefaultAsync(e => e.Id == id);
                if (deleteUser != null)
                {
                    dbContext.Users.Remove(deleteUser);
                    await dbContext.SaveChangesAsync();
                }
                return StatusCode(StatusCodes.Status200OK, new { message = "ok" });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
