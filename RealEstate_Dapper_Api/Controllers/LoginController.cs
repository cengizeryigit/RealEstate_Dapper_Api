using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.LoginDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Tools;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDto loginDto)
        {
            string query = "Select * from AppUser Where Username = @username and Password = @password";
            var parameters = new DynamicParameters();
            parameters.Add("username", loginDto.Username);
            parameters.Add("password", loginDto.Password);

            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QueryFirstOrDefaultAsync<GetAppUserDto>(query, parameters);
                if (user == null)
                {
                    return Unauthorized("Invalid username or password.");
                }

                GetCheckAppUserViewModel model = new GetCheckAppUserViewModel
                {
                    Username = user.Username,
                    Id = user.UserId,
                };
                var token = JwtTokenGenerator.GenerateToken(model);

                return Ok(token);
            }
        }
    }
}
