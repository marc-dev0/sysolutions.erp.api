using AutoMapper;
using Sysolutions.Erp.Application.Commons;
using Sysolutions.Erp.Domain.Entities;
using Sysolutions.Erp.Infrastructure.Persistences.Interfaces;
using Sysolutions.Erp.Infrastructure.Services;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace Sysolutions.Erp.Application.Services.Accounts.Commands.AddTokenCommand
{
    public class AddTokenHandler : IRequestHandler<AddTokenCommand, Response<AddTokenResponse>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly AddTokenValidator _validationRules;
        private readonly ILogger<AddTokenHandler> _logger;
        private readonly INotify _nofity;

        public AddTokenHandler(IAccountRepository accountRepository, IMapper mapper, IConfiguration configuration, AddTokenValidator validationRules, ILogger<AddTokenHandler> logger/*, INotify nofity*/)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _configuration = configuration;
            _validationRules = validationRules;
            _logger = logger;
            /*_nofity = nofity;*/
        }

        public async Task<Response<AddTokenResponse>> Handle(AddTokenCommand request, CancellationToken cancellationToken)
        {
            var response = new Response<AddTokenResponse>();
            try
            {
                var validationResult = _validationRules.Validate(request);

                if (!validationResult.IsValid)
                {
                    response.Message = "Errores de Validación";
                    response.Errors = validationResult.Errors;
                    _logger.LogInformation(response.Message);
                    //await _nofity.Publish(response.Message);
                    return response;
                }

                var account = await _accountRepository.GetAsync(request.Client);
                if (account is not null)
                {
                    if (BC.Verify(request.Secret, account.Secret))
                    {
                        response.Data = _mapper.Map<AddTokenResponse>(account);
                        response.Data.Token = GenerateToken(account);
                        //response.Data = GenerateToken(account);
                        response.IsSuccess = true;
                        response.Message = "Token Exitoso!!!";
                        _logger.LogInformation(response.Message);
                        //await _nofity.Publish(response.Message);
                        return response;
                    }
                }
                else
                {
                    response.Message = "Cuenta No Valida!!!";
                    _logger.LogInformation(response.Message);
                    //await _nofity.Publish(response.Message);
                    return response;
                }
            }
            catch (Exception ex)
            {                
                response.Message = ex.Message;
                _logger.LogError(ex, response.Message);
            }

            return response;
        }

        private string GenerateToken(Account account)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, account.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, account.LastName),
                new Claim(JwtRegisteredClaimNames.GivenName, account.Client),
                new Claim(JwtRegisteredClaimNames.UniqueName, account.AccountId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, Guid.NewGuid().ToString(), ClaimValueTypes.Integer64),
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:Expires"])),
                notBefore: DateTime.UtcNow,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
