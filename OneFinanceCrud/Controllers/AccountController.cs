using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneFinanceCrud.Context;
using OneFinanceCrud.DTO;
using OneFinanceCrud.Models;

namespace OneFinanceCrud.Controllers
{
    public class AccountController: ControllerBase
    {
        private readonly ProductDbContext _context;
        readonly IMapper _mapper;
        public AccountController(ProductDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

         
            [Route("api/Register")]
            [HttpPost]
            public async Task<ActionResult> Register(RegistrationDto users)
            {
                User user = _mapper.Map<User>(users);
                var error = await _context.Users.AddAsync(user);
                int result = await _context.SaveChangesAsync();
                if (result <= 0)
                {


                    return BadRequest(error);
                }
                return Ok();
            }

            [Route("api/Login")]
            [HttpPost]
            public async Task<IActionResult> Login([FromBody]LoginDto loginDto)
            {
                User? user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
                if (user != null)
                {
                    if (user.Password == loginDto.Password)
                    {
                        return Ok(true);
                    }
                }
                return BadRequest(false);
            }
        }
    }