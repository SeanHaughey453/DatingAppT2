using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){//when making somthing async you need to wrap it in a task
            return await _context.Users.ToListAsync();//also when making async you need to use await and  the ToListAsync instead of ToList
        }//alternativley you can use .results at the end of the toListAsync instead of await but await is better practise
        //api/users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUsers(int id){//using ienumerbale because you just need a basic list reutrned using list gives too much possible features
            return await _context.Users.FindAsync(id);//instead of storing to user and returning the variable we can just use a return statment to directly reutrn the contents
        }
    }
}