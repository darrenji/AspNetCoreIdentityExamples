using AspNetCoreIdentityExamples.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreIdentityExamples.Infrastructure
{
    #region 1
    //public class CustomUserValidator : IUserValidator<AppUser>
    //{
    //    public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
    //    {
    //        if (user.Email.ToLower().EndsWith("@example.com"))
    //        {
    //            return Task.FromResult(IdentityResult.Success);
    //        }
    //        else
    //        {
    //            return Task.FromResult(IdentityResult.Failed(new IdentityError
    //            {
    //                Code = "EmailDomainError",
    //                Description = "Only example.com email addresses are allowed"
    //            }));
    //        }
    //    }
    //} 
    #endregion

    public class CustomUserValidator:UserValidator<AppUser>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            IdentityResult result = await base.ValidateAsync(manager, user);

            List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();

            //if (!user.Email.ToLower().EndsWith("@example.com"))
            //{
            //    errors.Add(new IdentityError {
            //        Code = "EmailDomainError",
            //        Description="Only examplecom email addresses are allowed"
            //    });
            //}

            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }
    }
}
