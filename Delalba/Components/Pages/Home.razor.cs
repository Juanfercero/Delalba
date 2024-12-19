using System;
using System.Threading.Tasks;
using Delalba.Components.Account.Pages.Manage;
using Delalba.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using Delalba.Components.Pages;
using Microsoft.AspNetCore.Components;
using System.Net.Mail;

namespace Delalba.Components.Pages
{
    public partial class Home
    {
        static void Main(string[] args)
        {
            
        }


        // Inyectamos IConfiguration en el constructor


        //El Execute antes era private
        static async Task Execute()
        {
            var apiKey = Environment.GetEnvironmentVariable("ApiKey");

            //Console.WriteLine($"{apiKey}");

            if (string.IsNullOrEmpty(apiKey))
            {
                Console.WriteLine("Error: API Key no configurada.");
                return;
            }

            //API entre las comillas
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("juanfer.cero@gmail.com", "Juan");
            var subject = "Nuevo pedido de Delalba!";
            var to = new EmailAddress("nicoproserpioriver@gmail.com", "Nicolas");
            var plainTextContent = $"Se piden estos productos: {ProductosMail}";
            var htmlContent = $"<strong>Se piden estos productos: {ProductosMail}</strong>";

            //Con el MailHelper se construye el correo
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            
            //Acá se envía el correo
            var response = await client.SendEmailAsync(msg);

            //Console.WriteLine(response.StatusCode);
            //Console.WriteLine("\n\nPress <Enter> to continue.");
            //Console.ReadKey();

        }

    }
}
