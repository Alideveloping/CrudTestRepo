using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CrudRepos.Domain.Entities.Users;

namespace CrudRepos.Data
{
    public class CrudReposContext : DbContext
    {
        public CrudReposContext (DbContextOptions<CrudReposContext> options)
            : base(options)
        {
        }

        public DbSet<CrudRepos.Domain.Entities.Users.User> User { get; set; } = default!;
    }
}
