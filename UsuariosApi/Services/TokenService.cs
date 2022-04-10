using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsuariosApi.Modelos;

namespace UsuariosApi.Services
{
    public class TokenService
    {
        public Token CreateToken(CustomIdentityUser usuario, string role)
        {
            Claim[] direitoUsuario = new Claim[]
            {
                new Claim("username", usuario.UserName),
                new Claim("id", usuario.Id.ToString()),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.DateOfBirth, usuario.DataNascimento.ToString())
            };
            #region Gerando token
            var chave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("Curs0Alura0Identity0d0tnetc1inc0"));
            //Encoding.UTF8.GetBytes("0asdjas09dja09djasdjsadajsd09asjd09sajcnzxn"));

            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: direitoUsuario,
                signingCredentials: credenciais,
                expires: DateTime.UtcNow.AddHours(1)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return new Token(tokenString);
            #endregion

        }
    }
}
