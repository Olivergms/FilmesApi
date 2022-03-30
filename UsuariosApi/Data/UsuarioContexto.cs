using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.Data
{
    //IdentitydbContext possui um identity user, identificado pelo id int
    // um papel identificado por inteiro
    // e será identificado por um inteiro
    public class UsuarioContexto : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public UsuarioContexto(DbContextOptions<UsuarioContexto> opt)
            : base(opt) { }
    }
}
