using Hust.Datn.Service.Entity;
using Hust.Datn.Service.Interfaces;
using Hust.Datn.Service.Interfaces.Repos;
using Hust.Datn.Service.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hust.Datn.Service.Services
{
    public class AuthService : BaseService<User>, IAuthService
    {
        #region Declare
        protected readonly IAuthRepo _authRepo;
        #endregion

        #region Constructor
        public AuthService(IAuthRepo authRepo, IFileSystemService fileSystemService, IConfiguration configuration) : base(authRepo, fileSystemService, configuration)
        {
            _authRepo = authRepo;
        }
        #endregion

        #region Methods
        public async Task<ServiceResult> Login(string userName, string password)
        {
            var result = new ServiceResult();

            // Kiểm tra user
            var user = await _authRepo.GetUser(userName, Encrypt(password));

            if (user != null)
            {
                // Tạo token
                var token = GenToken(userName);
                if (token != null)
                {
                    result.Success = true;
                    result.Data = new
                    {
                        UserID = user.UserID,
                        UserName = userName,
                        FullName = user.FullName,
                        Token = token
                    };
                }
                else
                {
                    result.Success = false;
                    result.DevMsg = "Không tạo được token";
                    result.UserMsg = "Có lỗi xảy ra, vui lòng thử lại sau";
                }
            }
            else
            {
                result.Success = false;
                result.UserMsg = "Tài khoản hoặc mật khẩu không chính xác";
            }

            return result;
        }

        public async Task<ServiceResult> Register(User user)
        {
            var result = new ServiceResult();

            // Kiểm tra tên đăng nhập đã tồi tại chưa
            var sqlCheck = @"SELECT
                              CASE EXISTS(SELECT
                                  u.UserID
                                FROM User u
                                WHERE u.UserName = @UserName) WHEN 1 THEN 1 ELSE 0 END a; ";
            var existUserName = await _authRepo.CheckUserName(sqlCheck, new { user.UserName });
            if (existUserName)
            {
                // Thêm user
                var sqlInsert = @"INSERT INTO User (UserID, FullName, Role, UserName, Password, CreatedBy, ModifiedBy, CreatedDate, ModifiedDate)
                                    VALUES (UUID(), @FullName, 4, @UserName, @Password, '', '', NOW(), NOW());";
                var param = new
                {
                    FullName = user.FullName,
                    UserName = user.UserName,
                    Password = Encrypt(user.Password)
                };

                var insertUser = await _authRepo.InsertUser(sqlInsert, param);

                if (insertUser != 1)
                {
                    result.Success = false;
                    result.UserMsg = "Đăng ký tài khoản không thành công. Vui lòng thử lại sau!";
                }
            }
            else
            {
                result.Success = false;
                result.UserMsg = "Tên đăng nhập đã tồn tại trên hệ thống!";
            }

            return result;
        }

        private string GenToken(string userName)
        {
            var configJwt = _configuration.GetSection("Jwt").Get<ConfigJwt>();
            var issuer = configJwt.Issuer;
            var audience = configJwt.Audience;
            var key = Encoding.ASCII.GetBytes(configJwt.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, userName),
                new Claim(JwtRegisteredClaimNames.Email, userName),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
             }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

        private string Encrypt(string clearText)
        {
            string encryptionKey = "MAKV2SPBNI99212DATN";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }

            return clearText;
        }

        private string Decrypt(string cipherText)
        {
            string encryptionKey = "MAKV2SPBNI99212DATN";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }

            return cipherText;
        }
        #endregion
    }
}
