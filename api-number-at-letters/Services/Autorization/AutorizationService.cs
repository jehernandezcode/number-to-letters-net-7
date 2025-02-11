﻿using api_number_at_letters.Config;
using api_number_at_letters.Exceptions;
using api_number_at_letters.Models.Dto.Request;
using api_number_at_letters.Models.Dto.Response;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace api_number_at_letters.Services.Autorization
{
    public class AutorizationService : IAuthorizationService
    {
        private readonly ILogger<AutorizationService> _logger;
        private readonly KeyConfig _keyConfig;

        public AutorizationService(ILogger<AutorizationService> logger, IOptions<KeyConfig> keyConfiguration)
        {
            _logger = logger;
            _keyConfig = keyConfiguration.Value;
        }


        private string GetToken(string userName)
        {
            var privateKey = _keyConfig.KeySecret;
            var keyBytes = Encoding.ASCII.GetBytes(privateKey);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, userName));

            var credentialToken = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = credentialToken,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescription);

            string token = tokenHandler.WriteToken(tokenConfig);

            return token;
        }

        public async Task<LoginResponseDto> Token(LoginRequestDto credentials)
        {
                string token;
                if(credentials == null)
                {
                    throw new UnAuthorizationException("not authorized");
                }

                if (credentials.UserName == "userConverter" && credentials.Password == "123456789")
                {
                    token = GetToken(credentials.UserName);
                }else
                {
                    throw new UnAuthorizationException("incorrect username or password");
                }

                return new LoginResponseDto { Token = token}; 
        }
    }
}
