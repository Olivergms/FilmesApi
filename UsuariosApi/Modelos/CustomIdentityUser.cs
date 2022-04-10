using Microsoft.AspNetCore.Identity;
using System;

namespace UsuariosApi.Modelos
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public DateTime DataNascimento { get; set; }
    }
}
