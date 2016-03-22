using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendGrid.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var apiKey = ConfigurationManager.AppSettings["SendgridApiKey"];
            var sendgridApi = new SendGridApi(apiKey);

            var task = new Task(async () =>
            {
                var categories = await sendgridApi.Bounces.GetListAsync();
                Console.WriteLine();
            });
            task.RunSynchronously();

            Console.ReadLine();
        }
    }
}
