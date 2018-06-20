using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using SampleWebAPI.Core.Models;
using SampleWebAPI.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using SampleWebAPI.Core;

namespace SampleWebAPI.Tests
{
    public class Tests : IDisposable
    {
        private readonly TestContext testContext;
        protected readonly UserRepository repository;
        protected readonly SampleDbContext db;
       

        public Tests()
        {

            testContext = new TestContext();

            var options = new DbContextOptionsBuilder<SampleDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

             db = new SampleDbContext(options);

            db.Database.EnsureCreated();

            repository = new UserRepository(db);

           
            //SEED THE DATABASE

            var users = new[]
            {
                new User {Id=50, Username="username1",Password="password1",DepartmentId=50},
                new User {Id=51, Username="username2",Password="password2"},
                new User {Id=53, Username="username3",Password="password3"}
            };
            var department = new Department { Id = 50, Name = "Dep1" };
            db.Departments.Add(department);
            db.Users.AddRange(users);
            db.SaveChanges();
           
        }

        [Fact]
        public async Task GetOneUserFromDepartment()
        {
            
            var result = await repository.GetSingleUserInDepartment(50, 50);
            
            int newuser = 0;
            if (result != null)
                newuser = 1;
            
            newuser.Should().Be(1);
            
        }

        [Fact]
        public async Task GetUserListOfDepartment()
        {
            var result = await repository.GetUserListByDepartment(50);
            result.Count.Should().Be(1);
        }

        [Fact]
        public async Task DoesUserLoginSuccessfully()
        {
            var result = await repository.Login("username1","password1");

            int newuser = 0;
            if (result != null)
                newuser = 1;

            newuser.Should().Be(1);
        }

        [Fact]
        public void DoesUserRegisterSuccessfully()
        {
            var user = new User { Id = 54, Username = "newusername1", Password = "newpassword1", DepartmentId = 50 };
           repository.Add(user);
            db.SaveChanges();
            var registeredUser = db.Users.Find(54);

            int newuser = 0;
            if (registeredUser != null)
                newuser = 1;

            newuser.Should().Be(1);
        }

        [Fact]
        public async void DoesUserUpdatesHisProfile()
        {
            var user = await repository.GetUser(51);
            user.Firstname = "firstname";
            user.Lastname = "lastname";
            db.SaveChanges();
            

            int newuser = 0;
            if (user.Firstname != null)
                newuser = 1;

            newuser.Should().Be(1);
        }

        public void Dispose()
        {
            db.Database.EnsureDeleted();
            db.Dispose();
        }
    }
}
