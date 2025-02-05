using Business.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class BruteForceProtectionService : IBruteForceProtectionService
    {
        private readonly Dictionary<string, (int attempts, DateTime lastAttempt)> _failedAttempts = new();
        private readonly int _maxAttempts = 5;
        private readonly TimeSpan _blockDuration = TimeSpan.FromMinutes(15);

        public void RegisterFailedAttempt(string ipAddress)
        {
            if (_failedAttempts.ContainsKey(ipAddress))
            {
                var (attempts, lastAttempt) = _failedAttempts[ipAddress];
                _failedAttempts[ipAddress] = (attempts + 1, DateTime.UtcNow);
            }
            else
            {
                _failedAttempts[ipAddress] = (1, DateTime.UtcNow);
            }
        }

        public void RegisterSuccessfulLogin(string ipAddress)
        {
            if (_failedAttempts.ContainsKey(ipAddress))
            {
                _failedAttempts.Remove(ipAddress);
            }
        }

        public bool IsIpBlocked(string ipAddress)
        {
            if (_failedAttempts.TryGetValue(ipAddress, out var attemptInfo))
            {
                var (attempts, lastAttempt) = attemptInfo;
                if (attempts >= _maxAttempts && (DateTime.UtcNow - lastAttempt) < _blockDuration)
                {
                    return true;
                }
                if ((DateTime.UtcNow - lastAttempt) >= _blockDuration)
                {
                    _failedAttempts.Remove(ipAddress); 
                }
            }
            return false;
        }
    }

}
