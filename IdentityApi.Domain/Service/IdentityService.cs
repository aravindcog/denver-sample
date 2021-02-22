using Denver.Infra.Constants;
using IdentityApi.Domain.ApiModels;
using IdentityApi.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IdentityApi.Domain.Service
{
    public partial class Service
    {
        public async Task<AuthenticationResultApiModel> ValidateUser(LoginApiModel credentials, string secret, TimeSpan tokenLifeTime, CancellationToken ct = new CancellationToken())
        {

            User userRes = null; // await _identityRepository.CheckLoginAsync(credentials, ct);
            if (userRes != null)
            {

                string Dpassword = ""; // crpt.DecryptText(userRes.Password, secret, userRes.Salt);
                if (Dpassword.Equals(credentials.Password))
                {
                    return new AuthenticationResultApiModel { Success = true };

                }
                else
                {
                    return new AuthenticationResultApiModel { ErrorMessage = new List<string> { ValidationMessage.InvalidUser }, Success = false };
                }
            }
            else
            {
                return new AuthenticationResultApiModel { Success = false, ErrorMessage = new List<string> { ValidationMessage.InvalidUser } };
            }
        }
    }
}
