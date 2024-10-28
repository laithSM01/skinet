using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace API.Extensions
{
    // this class is to reduct redundant code such as user?.FindFirstValue(ClaimTypes.Email);
    public static class ClaimsPrincipalExtensions
    {
        public static string RetrieveEmailFromPrincipal(this ClaimsPrincipal user)
        {
            return user?.FindFirstValue(ClaimTypes.Email);
        }
    }
}
