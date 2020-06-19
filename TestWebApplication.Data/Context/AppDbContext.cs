using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TestWebApplication.Data.Models;

namespace TestWebApplication.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base( options )
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
