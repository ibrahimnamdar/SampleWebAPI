using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Controllers.Resources;
using SampleWebAPI.Core;
using SampleWebAPI.Core.Models;

namespace SampleWebAPI.Controllers
{
    [Route("/api/users")]
    public class UsersController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUserRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public UsersController(IMapper mapper, IUserRepository repository, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("/api/login")]
        public async Task<IActionResult> Login([FromQuery]string username, [FromQuery]string password)
        {
            var user = await repository.Login(username, password);

            if (user==null)
                return NotFound();

            return Ok(user);

        }

        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetUserListByDepartment([FromQuery] int departmentId)
        {
            //var users = await context.Users.Where(x=>x.DepartmentId== departmentId).ToListAsync();
            var users=await repository.GetUserListByDepartment(departmentId);
            return mapper.Map<List<User>, List<UserResource>>(users);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] KeyValuePairUserResource userResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = mapper.Map<KeyValuePairUserResource, User>(userResource);
            repository.Add(user);
            await unitOfWork.CompleteAsync();

            var result = mapper.Map<User, KeyValuePairUserResource>(user);

            return Ok(result);
        }

        [HttpPut("/api/users/edit/{id}")]
        public async Task<IActionResult> UpdateProfile(int id, [FromBody] UserResource userResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await repository.GetUser(id); 
            mapper.Map<UserResource, User>(userResource, user);
            await unitOfWork.CompleteAsync();

            var result = mapper.Map<User, UserResource>(user);

            return Ok(result);
        }


    }
}