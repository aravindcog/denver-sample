using IdentityApi.Domain.ApiModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IdentityApi.Domain.Service
{
    public interface IService
    {       
        Task<AuthenticationResultApiModel> ValidateUser(LoginApiModel credentials, string secret, TimeSpan tokenLifeTime, CancellationToken ct = new CancellationToken());
    }
}
