using System;
using System.IO;
using BackEnd.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Infrastructure.Data
{
    public class PostDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        private readonly string _dbPath;

        public PostDbContext()
        {
            _dbPath = Path.Combine(Environment.CurrentDirectory + "/posts.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={_dbPath}", x => x.MigrationsAssembly("BackEnd.Api"));
    }
}