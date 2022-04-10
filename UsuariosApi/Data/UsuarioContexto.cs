using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace UsuariosApi.Data
{
    //IdentitydbContext possui um identity user, identificado pelo id int
    // um papel identificado por inteiro
    // e será identificado por um inteiro
    public class UsuarioContexto : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        private IConfiguration _configuration;
        public UsuarioContexto(DbContextOptions<UsuarioContexto> opt, IConfiguration configuration)
            : base(opt)
        {
            _configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            #region Criação de usuario administrador
            IdentityUser<int> admin = new IdentityUser<int>
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com", 
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 99999
            };

            PasswordHasher<IdentityUser<int>> hasher = new PasswordHasher<IdentityUser<int>>();
            admin.PasswordHash = hasher.HashPassword(admin, _configuration.GetValue<string>("adminInfo:password"));

            builder.Entity<IdentityUser<int>>().HasData(admin);

            #endregion

            #region Criação das roles 
            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 99999, Name = "admin", NormalizedName = "ADMIN" }
                );

            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 99998, Name = "regular", NormalizedName = "REGULAR" }
                );
            #endregion

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { RoleId = 99999, UserId = 99999 }
                );
        }
    }
}
