using System;
using System.Threading.Tasks;
using Delalba.Components.Account.Pages.Manage;
using Delalba.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Delalba.Components.Pages
{
    public partial class Home
    {
        static void Main(string[] args)
        {
            
        }

        static async Task Execute()
        {
            //API entre las comillas
            var client = new SendGridClient("");

            var from = new EmailAddress("juanfer.cero@gmail.com", "juancho9955");
            var subject = "Hello World from the Twilio SendGrid CSharp Library Helper!";
            var to = new EmailAddress("juanfer.cero@gmail.com", "juancho9955");
            var plainTextContent = "Hello, Email from the helper [SendSingleEmailAsync]!";
            var htmlContent = "<strong>Hello, Email from the helper! [SendSingleEmailAsync]</strong>";

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
