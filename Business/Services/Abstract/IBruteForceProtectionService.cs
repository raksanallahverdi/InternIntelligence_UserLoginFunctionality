using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface IBruteForceProtectionService
    {
        void RegisterFailedAttempt(string ipAddress);
        void RegisterSuccessfulLogin(string ipAddress);
        bool IsIpBlocked(string ipAddress);
    }

}
