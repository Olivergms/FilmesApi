using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuariosApi.Modelos;

namespace UsuariosApi.Services
{
    public class EmailService
    {
        internal void EnviarEmail(string[] destinatario, string assunto
            , int usuarioId, string code)
        {
            Mensagem mensagem = new Mensagem(destinatario, assunto, usuarioId, code);

            var msgEmail = CriaCorpoEmail(mensagem);

            Enviar(msgEmail);
        }

        private void Enviar(MimeMessage msgEmail)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("conexão a fazer");
                    //todo auth de email
                    client.Send(msgEmail);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private MimeMessage CriaCorpoEmail(Mensagem mensagem)
        {
            var mensagemEmail = new MimeMessage();
            mensagemEmail.From.Add(new MailboxAddress("adicionar o remetente"));
            mensagemEmail.To.AddRange(mensagem.Destinatario);
            mensagemEmail.Subject = mensagem.Assunto;
            mensagemEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = mensagem.Conteudo
            };
            return mensagemEmail;
        }
    }
}
