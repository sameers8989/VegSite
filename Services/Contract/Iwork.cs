using works.Models;
using works.Utilities;

namespace works.Services.Contract
{
    public interface Iwork
    {
        public Loginrequest AddToList(Loginrequest loginrequest);
        public ResponseAPI<Loginrequest> verify(Loginrequest loginrequest);
        public string createToken(LoginDetail h20LoginPage);
        public List<Vegetable> GetAllDetails();
        public string AddToList(CustomerDetailrequest customerdetailrequest);
    }
}
