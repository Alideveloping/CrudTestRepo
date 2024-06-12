using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudRepos.Data;
using CrudRepos.Domain.Entities.Users;
using CrudRepos.Persistance.Context;
using CrudRepos.Models.ViewModels.User;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using CrudRepos.Application.Services.Users.Query;
using CrudRepos.Application.Services.Users.Command;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace CrudRepos.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContext _db;
        private readonly IGetUsersService _getUsersService;
        private readonly IRegisterUserService _registerUserService;

        public UserController(DatabaseContext db
            , IGetUsersService getUsersService
            , IRegisterUserService registerUserService)
        {
            _db = db;
            _getUsersService = getUsersService;
            _registerUserService = registerUserService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return View(_getUsersService.Execute());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel user)
        {
            var request = new RequestRegisterUserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Age = user.Age,
                NationalCode = user.NationalCode
            };

            var result = _registerUserService.Execute(request);

            if (result.IsSuccess)
            {
                return RedirectToAction("List", "User");
            }

            else
            {
                ViewBag.ErrorMessage = result.Message;
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _db.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel user)
        {
            //todo
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            //todo
            return View();
        }



    }
}
