using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleWebAPI.Controllers.Resources;
using SampleWebAPI.Core;
using SampleWebAPI.Core.Models;
using SampleWebAPI.Persistence;

namespace SampleWebAPI.Controllers
{
    [Route("/api/departments")]
    public class DepartmentsController : Controller
    {
        private readonly SampleDbContext context;
        private readonly IMapper mapper;
        private readonly IUserRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public DepartmentsController(SampleDbContext context, IMapper mapper, IUserRepository repository, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.mapper = mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserInDepartment(int id,[FromQuery]int userId)
        {
            var user = await repository.GetSingleUserInDepartment(id, userId);

            if (user == null)
                return NotFound();

            var result= mapper.Map<User, UserResource>(user);
            return Ok(result);
        }
    }
}