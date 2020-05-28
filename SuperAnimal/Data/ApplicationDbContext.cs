using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperAnimal.Models;

namespace SuperAnimal.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Image> Images { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostPhoto> PostPhotos { get; set; }

        public DbSet<Sex> Sexs { get; set; }

        public DbSet<Chat> Chats { get; set; }

        public DbSet<Message> Messages { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUser>().Property(x => x.UserName).IsRequired();
            base.OnModelCreating(builder);
        }


    }
}
