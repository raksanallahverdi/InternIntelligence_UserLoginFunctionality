using Business.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class TokenBlacklistService : ITokenBlacklistService
    {
        private readonly List<string> _blacklistedTokens = new(); 

        public Task AddToBlacklistAsync(string token)
        {
            _blacklistedTokens.Add(token); // Add token to blacklist
            return Task.CompletedTask;
        }

        public Task<bool> IsTokenBlacklistedAsync(string token)
        {
         
            return Task.FromResult(_blacklistedTokens.Contains(token));
        }
    }
}
