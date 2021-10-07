using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LifeTracker.Business.Options
{
    public class AuthOption
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Secret { get; set; }
        public int TokenLifetime { get; set; } //minutes

        public SymmetricSecurityKey SymmetricSecurityKey => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
    }
}
