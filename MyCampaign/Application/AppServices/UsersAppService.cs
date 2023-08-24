using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Interfaces;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.IdentityModel.Tokens;
using Shared.Result;

namespace Application.AppServices
{
    public class AuthAppService : IAuthAppService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly JwtSecret _jwtSecret;

        public AuthAppService(IUsersRepository usersRepository, JwtSecret jwtSecret)
        {
            _usersRepository = usersRepository;
            _jwtSecret = jwtSecret;
        }

        public async Task<Result<TokenResponse>> RegisterUser(UserRegister user)
        {

            var userDb = new User()
            {
                FirstName = user.FirstName,
                BirthDate = user.BirthDate,
                LastName = user.LastName,
                Username = user.Username,
                Password = user.Password,
            };

            if(await UserExists(userDb))
                return new BadRequestResult<TokenResponse>("Username already exists!");

            var userId = await _usersRepository.InsertNewUser(userDb);
            if (userId != 0)
            {
                var token = GenerateToken(userDb);
                return new CreatedResult<TokenResponse>(new TokenResponse(token));
            }
            return new BadRequestResult<TokenResponse>("erro");
        }


        public async Task<Result<TokenResponse>> Login(Login login)
        {
            var userDb = await _usersRepository.GetUserByUserName(login.Username);

            if(userDb == null || userDb.Password != login.Password)
                return new UnauthorizedResult<TokenResponse>();

            var tokenResponse = new TokenResponse(GenerateToken(userDb));

            return new OkResult<TokenResponse>(tokenResponse);
        }


        private async Task<bool> UserExists(User user)
        {
            var userDb = await _usersRepository.GetUserByUserName(user.Username);
            return (userDb != null);
        }
        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSecret.Key));
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Username.ToString()),
                    new Claim("userId",user.Id.ToString()),
                }),
                Expires = DateTime.Now.AddMinutes(30),
                NotBefore = DateTime.Now,
                Issuer = _jwtSecret.Issuer,
                IssuedAt = DateTime.Now,
                SigningCredentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }





        public void Dispose()
        {
            _usersRepository.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}

