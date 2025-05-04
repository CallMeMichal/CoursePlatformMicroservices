using LoginRegisterMicroservice.Repositories.DatabaseModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace LoginRegisterMicroservice.Services
{
    public class JwtTokenGenerator /*: IJwtTokenGenerator*/
    {
        /*private readonly IDateTimeProvider _dateTimeProvider;
        private readonly JwtSettings _jwtSettings;

        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtSettings)
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtSettings = jwtSettings.Value;
        }*/

        public string GenerateToken(User user)
        {
            var jwtSettingsSecret = GenerateSecret();
            var jwtSettingsAudience = "https://CoursePlatform.com";
            var jwtSettingsIssuer = "MyApiService";


            var credentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettingsSecret)),
                SecurityAlgorithms.HmacSha256);

            if (user == null ||
                user.Id == 0 ||
                string.IsNullOrWhiteSpace(user.FirstName) ||
                string.IsNullOrWhiteSpace(user.LastName) ||
                string.IsNullOrWhiteSpace(user.Email) ||
                user.RoleId == 0)
            {
                throw new InvalidOperationException("User data is incomplete or null.");
            }


            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("roleId", user.RoleId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var secToken = new JwtSecurityToken(

                issuer: jwtSettingsIssuer,
                audience: jwtSettingsAudience,
                expires: DateTime.UtcNow.AddHours(6),

                signingCredentials: credentials,
                claims: claims

                );

            return new JwtSecurityTokenHandler().WriteToken(secToken);
        }


        private string GenerateSecret(int length = 64)
        {
            var bytes = new byte[length];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            return Convert.ToBase64String(bytes);
        }
    }
}
