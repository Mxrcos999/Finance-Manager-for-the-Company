using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace FinanceManager.Identity.Configurations
{
    public class EmailConfirmationTokenProvider<TUser> : DataProtectorTokenProvider<TUser>
        where TUser : class
    {

        public EmailConfirmationTokenProvider(
            IDataProtectionProvider dataProtectionProvider,
            IOptions<EmailConfirmationTokenProviderOptions> options)
            : base(dataProtectionProvider, options)
        {
        }

        public override async Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<TUser> manager, TUser user)
        {
            if (await base.CanGenerateTwoFactorTokenAsync(manager, user))
            {
                return await manager.IsEmailConfirmedAsync(user);
            }
            return false;
        }
    }

    public class EmailConfirmationTokenProviderOptions : DataProtectionTokenProviderOptions
    {
        public EmailConfirmationTokenProviderOptions()
        {
            Name = "EmailConfirmationDataProtectorTokenProvider";
            TokenLifespan = TimeSpan.FromDays(1);
        }
    }
}
