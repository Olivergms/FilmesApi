using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Data.Requests;
using UsuariosApi.Modelos;

namespace UsuariosApi.Services
{
    public class CadastroService
    {
        private IMapper _mapper;
        //Gerenciador de usuario, irá gerenciar o identityUser
        private UserManager<IdentityUser<int>> _userManager;
        private EmailService _emailService;
        private RoleManager<IdentityRole<int>> _roleManager;

        public CadastroService(IMapper mapper, UserManager<IdentityUser<int>> userManager, EmailService emailService, RoleManager<IdentityRole<int>> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
            _roleManager = roleManager;
        }

        public Result CadastraUsuario(CreateUsuarioDto createDto)
        {
            Usuario usuario = _mapper.Map<Usuario>(createDto);
            IdentityUser<int> usuarioIdentity = _mapper.Map<IdentityUser<int>>(usuario);
            //cria um usuario de forma assincrona
            var resultadoIdentity = _userManager
                .CreateAsync(usuarioIdentity, createDto.Password).Result;

            _userManager.AddToRoleAsync(usuarioIdentity, "regular");


            if (resultadoIdentity.Succeeded)
            {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(usuarioIdentity).Result;

                var encodedCode = HttpUtility.UrlEncode(code);

                _emailService.EnviarEmail(new[] { usuarioIdentity.Email },
                    "Link de ativação",
                    usuarioIdentity.Id,
                    encodedCode);
                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("Falha ao cadastrar o usuário");
        }

        public Result AtivaContaUsuario(AtivaContaRequest request)
        {
            //identifica usuario
            var identityUser = _userManager
                .Users
                .FirstOrDefault(u => u.Id == request.UsuarioId);

            var identityResult = _userManager.ConfirmEmailAsync(identityUser, request.CodigoAtivacao).Result;

            if (identityResult.Succeeded) return Result.Ok();

            return Result.Fail("Falha na ativação da conta");
        }
    }
}
