using System;
using System.Collections.Generic;
using System.Text;

using FireOps.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FireOps.Infrastructure.Data
{
    public class FireOpsDbContext : DbContext
    {
        public FireOpsDbContext(DbContextOptions<FireOpsDbContext> options)
            : base(options)
        {

        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Incident> Incidents => Set<Incident>();
    }
}
