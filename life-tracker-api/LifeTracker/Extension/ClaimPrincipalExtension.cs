using System;
using System.Security.Claims;

namespace LifeTrackerApi.Extension
{
    internal static class ClaimsPrincipalExtensions
    {
        public static Guid GetId(this ClaimsPrincipal claimsPrincipal)
        {
            var id = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Guid.Parse(id);
        }
    }
}
