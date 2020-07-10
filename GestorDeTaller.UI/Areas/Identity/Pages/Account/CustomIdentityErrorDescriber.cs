using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;

namespace GestorDeTaller.UI.Areas.Identity.Pages.Account
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    { 
    /// <summary>
    /// Used to access at the localization messages
    /// </summary>
    private IStringLocalizer<CustomIdentityErrorDescriber> _localizer;
    /// <summary>
    /// Used for inject the <see cref="IStringLocalizer{CustomIdentityErrorDescriber}"/> and the localization resources files
    /// </summary>
    /// <param name="localizer">Instance to use for access at the localization messages</param>
    public CustomIdentityErrorDescriber(IStringLocalizer<CustomIdentityErrorDescriber> localizer) : base()
    {
        _localizer = localizer;
    }
    /// <summary>
    /// Allows get the message realted at the spefied code from the localization resourse files
    /// </summary>
    /// <param name="code">The code name of the error</param>
    /// <param name="arguments">the arguments to replace into the found mesage</param>
    /// <returns>A new <see cref="IdentityError"/> instance with the found localization message</returns>
    protected virtual IdentityError CreateError(string code, params object[] arguments)
    {
        return new IdentityError()
        {
            Code = code,
            Description = _localizer[code, arguments].Value
        };
    }

    public override IdentityError DefaultError() => CreateError(nameof(DefaultError));
    public override IdentityError ConcurrencyFailure() => CreateError(nameof(ConcurrencyFailure));
    public override IdentityError PasswordMismatch() => CreateError(nameof(PasswordMismatch));
    public override IdentityError InvalidToken() => CreateError(nameof(InvalidToken));
    public override IdentityError LoginAlreadyAssociated() => CreateError(nameof(LoginAlreadyAssociated));
    public override IdentityError InvalidUserName(string userName) => CreateError(nameof(InvalidUserName), userName);
    public override IdentityError InvalidEmail(string email) => CreateError(nameof(InvalidEmail), email);
    public override IdentityError DuplicateUserName(string userName) => CreateError(nameof(DuplicateUserName), userName);
    public override IdentityError DuplicateEmail(string email) => CreateError(nameof(DuplicateEmail), email);
    public override IdentityError InvalidRoleName(string role) => CreateError(nameof(InvalidRoleName), role);
    public override IdentityError DuplicateRoleName(string role) => CreateError(nameof(DuplicateRoleName), role);
    public override IdentityError UserAlreadyHasPassword() => CreateError(nameof(UserAlreadyHasPassword));
    public override IdentityError UserLockoutNotEnabled() => CreateError(nameof(UserLockoutNotEnabled));
    public override IdentityError UserAlreadyInRole(string role) => CreateError(nameof(UserAlreadyInRole), role);
    public override IdentityError UserNotInRole(string role) => CreateError(nameof(UserNotInRole), role);
    public override IdentityError PasswordTooShort(int length) => CreateError(nameof(PasswordTooShort), length);
    public override IdentityError PasswordRequiresNonAlphanumeric() => CreateError(nameof(PasswordRequiresNonAlphanumeric));
    public override IdentityError PasswordRequiresDigit() => CreateError(nameof(PasswordRequiresDigit));
    public override IdentityError PasswordRequiresLower() => CreateError(nameof(PasswordRequiresLower));
    public override IdentityError PasswordRequiresUpper() => CreateError(nameof(PasswordRequiresUpper));
}
}
