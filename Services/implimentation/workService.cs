using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using works.Models;
using works.Services.Contract;
using works.Utilities;

namespace works.Services.implimentation
{
    public class workService : Iwork
    {
        private readonly WorkContext _context;
        private readonly IConfiguration _configuration;
        public workService(WorkContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public Loginrequest AddToList(Loginrequest loginrequest)
        {
            try
            {
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(loginrequest.LoginPassWord);
                var newCustomer = new LoginDetail
                {
                    LoginPassWord = hashedPassword,
                    LoginEmail = loginrequest.LoginEmail
                };
                _context.LoginDetails.Add(newCustomer);
                _context.SaveChanges();
                loginrequest.LoginPassWord = hashedPassword;
                return loginrequest;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResponseAPI<Loginrequest> verify(Loginrequest h20LoginPage)
        {
            var email = h20LoginPage.LoginEmail;
            var password = h20LoginPage.LoginPassWord;
            var storedCustomer = _context.LoginDetails.FirstOrDefault(x => x.LoginEmail == email);
            ResponseAPI<Loginrequest> response = new ResponseAPI<Loginrequest>();
            var token = createToken(storedCustomer);
            if (storedCustomer.LoginEmail != email)
            {
                response.Status = false;
                response.Msg = "Not Found";

            }
            if (!BCrypt.Net.BCrypt.Verify(password, storedCustomer.LoginPassWord))
            {
                response.Status = false;
                response.Msg = "Wrong Password";
            }

            response.Status = true;
            response.Msg = $"{token}";


            return response;
        }

        public string createToken(LoginDetail login)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,login.LoginEmail)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(2),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        public List<Vegetable> GetAllDetails()
        {
            try
            {
                List<Vegetable> list = new List<Vegetable>();
                list = _context.Vegetables.ToList();
                return list;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CustomerDetail AddToList(CustomerDetail customerDetail)
        {
            try
            {
                _context.CustomerDetails.Add(customerDetail);
                _context.SaveChanges();
                return customerDetail;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
