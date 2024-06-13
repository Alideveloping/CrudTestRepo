using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        private readonly IRemoveUserService _removeUserService;
        private readonly IEditUserService _editUserService;
        private readonly IGetUserByIdService _getUserByIdService;
        public UserController(DatabaseContext db
            , IGetUsersService getUsersService
            , IRegisterUserService registerUserService
            , IRemoveUserService removeUserService
            , IEditUserService editUserService
            , IGetUserByIdService getUserByIdService)
        {
            _db = db;
            _getUsersService = getUsersService;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;
            _editUserService = editUserService;
            _getUserByIdService = getUserByIdService;
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
        public async Task<IActionResult> Edit(int Id)
        {
            var user = _getUserByIdService.Execute(Id);
            var editUserDto = new RequestEditUserDto
            {
                UserId = user.User.Id,
                FirstName = user.User.FirstName,
                LastName = user.User.LastName,
                Age = user.User.Age,
                NationalCode = user.User.NationalCode,
                Email = user.User.Email
            };

            return View(editUserDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel user)
        {
            var request = new RequestEditUserDto
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Age = user.Age,
                NationalCode = user.NationalCode
            };

            var result = _editUserService.Execute(request);

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

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = _removeUserService.Execute(id);

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
        public async Task<IActionResult> Details(int Id)
        {
            var user = _getUserByIdService.Execute(Id);
            var editUserDto = new RequestEditUserDto
            {
                UserId = user.User.Id,
                FirstName = user.User.FirstName,
                LastName = user.User.LastName,
                Age = user.User.Age,
                NationalCode = user.User.NationalCode,
                Email = user.User.Email
            };

            return View(editUserDto);
        }

    }
}
