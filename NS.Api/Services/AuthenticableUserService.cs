using System;
using NS.Core;
using AutoMapper;
using System.Text;
using NS.Services;
using NS.DTO.Acount;
using NS.Api.Helpers;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using NS.Core.Services;

namespace NS.Api.Services
{
    public interface IAuthenticableUserService : IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    }

    public class AuthenticableUserService : UserService, IAuthenticableUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public AuthenticableUserService(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings, IMapper mapper) : base(unitOfWork)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._appSettings = appSettings.Value;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = await _unitOfWork.Users.SingleOrDefaultAsync(x => x.Username == model.Username && x.Password == model.Password);

            var userModel = _mapper.Map<Core.Models.User, UserModel>(user);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(userModel);

            return new AuthenticateResponse(userModel, token);
        }

        // helper methods
        private string generateJwtToken(UserModel user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}