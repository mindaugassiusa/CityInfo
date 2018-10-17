using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public class LocalMailService : IMailService
    {
        private readonly string _mailTo = Startup.Configuration["mailSettings:mailToAdress"];
        private readonly string _mailFrom = Startup.Configuration["mailSettings:mailFromAdress"];

        public void Send(string subject, string message)
        {
            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with LocalMailService.");
            Debug.WriteLine($"Subject: {subject}");
            Debug.WriteLine($"Message: {message}");
        }
    }
}
