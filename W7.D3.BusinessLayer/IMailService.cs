using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W7.D3.BusinessLayer
{
    public interface IMailService
    {
        void SendMail(string to, string subject, string body);
    }
}
