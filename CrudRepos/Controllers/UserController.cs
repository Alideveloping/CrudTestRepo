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

namespace CrudRepos.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContext _db;

        public UserController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return View(await _db.Users.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserViewModel user)
        {
            return View();
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
