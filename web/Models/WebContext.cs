using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace webnet.Models
{
    public class WebContext : DbContext
    {
        public DbSet<Goods> Good { get; set; } = null!;
        public DbSet<Users> User { get; set; } = null!;
        public WebContext(DbContextOptions options) : base(options) { }
    }
}