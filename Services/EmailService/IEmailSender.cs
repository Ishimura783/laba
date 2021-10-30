using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.EmailService
{
     public interface IEmailSender
    {
        Task SendMessage(string emailTo, string messageBody, string messageSubject);

    }
}
