using System;
using System.Collections.Generic;
using System.Text;

namespace MMInfra.Service.Interfaces
{
    public interface ISmtpInfra
    {
        void SendMail(string mailTo, string subject, string body);
    }
}
