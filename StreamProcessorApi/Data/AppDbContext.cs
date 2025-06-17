using Microsoft.EntityFrameworkCore;
using StreamProcessorApi.Models;
using System.Collections.Generic;

namespace StreamProcessorApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Person> People { get; set; }
    }
}
