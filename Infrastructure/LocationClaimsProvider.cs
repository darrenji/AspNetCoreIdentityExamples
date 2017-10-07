using System;

using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace AspNetCoreIdentityExamples.Infrastructure
{
    public static class LocationClaimsProvider
    {
        public static Task<ClaimsPrincipal> AddClaims(ClaimsTransformationContext context)
        {
            //上下文中有一个Principal不奇怪
            ClaimsPrincipal principal = context.Principal;
            if(principal != null && !principal.HasClaim(c => c.Type == ClaimTypes.PostalCode))
            {
                //从Principal中获取ClaimsIdentity
                ClaimsIdentity identity = principal.Identity as ClaimsIdentity;

                if(identity!=null && identity.IsAuthenticated && identity.Name != null)
                {
                    if (identity.Name.ToLower() == "sunny")
                    {
                        identity.AddClaims(new Claim[] {
                            CreateClaim(ClaimTypes.PostalCode, "DC 20500"),
                            CreateClaim(ClaimTypes.StateOrProvince, "DC")
                        });
                    }
                    else
                    {
                        identity.AddClaims(new Claim[] {
                            CreateClaim(ClaimTypes.PostalCode, "NY 10036"),
                            CreateClaim(ClaimTypes.StateOrProvince, "NY")
                        });
                    }
                }

            }
            return Task.FromResult(principal);
        }

        private static Claim CreateClaim(string type, string value) =>
            new Claim(type, value, ClaimValueTypes.String, "RemoteClaims");
    }

   
}
