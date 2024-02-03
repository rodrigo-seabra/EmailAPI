using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Threading.Tasks;

namespace EmailApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {

        string PASSWORD_EMAIL = Environment.GetEnvironmentVariable("PASSWORD_EMAIL");
        string EMAIL = Environment.GetEnvironmentVariable("EMAIL");


        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest emailRequest)
        {
            try
            {
                // Verificações básicas nos campos da solicitação de e-mail
                if (string.IsNullOrEmpty(emailRequest?.To) || string.IsNullOrEmpty(emailRequest.Subject) || string.IsNullOrEmpty(emailRequest.Body))
                {
                    return BadRequest("Campos de e-mail não podem ser nulos ou vazios.");
                }

                // Configure SMTP client
                using (SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com"))
                {
                    smtpClient.Port = 587;
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(EMAIL, PASSWORD_EMAIL);

                    // Set TLS version to 1.2
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    // Customize certificate validation
                    ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

                    // Create a new email message
                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(EMAIL);
                        mailMessage.To.Add(emailRequest.To);
                        mailMessage.Subject = emailRequest.Subject;
                        mailMessage.Body = emailRequest.Body;

                        // Send the email
                        await smtpClient.SendMailAsync(mailMessage);
                    }
                }

                // Resposta JSON para sucesso
                var resposta = new
                {
                    status = "success",
                    message = "Email enviado com sucesso!"
                };

                return Ok(resposta);
            }
            catch (Exception ex)
            {
                // Resposta JSON para erro
                var erro = new
                {
                    status = "error",
                    message = $"Erro no envio do e-mail: {ex.Message}"
                };

                return StatusCode(500, erro);
            }
        }
    }

    public class EmailRequest
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
