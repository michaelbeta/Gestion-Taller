using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;

namespace GestorDeTaller.UI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ResetPasswordModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IEmailSender _emailSender;
        public ResetPasswordModel(UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
          
            [Required(ErrorMessage = "Este campo es  requrido")]
            [EmailAddress(ErrorMessage = "El correo  electrónico ingresado no es una dirreción de correo  electrónico válida")]
            [Display(Name = "Correo  electrónico")]
            public string Email { get; set; }
            [Required(ErrorMessage = "Este campo es requrido")]
            [RegularExpression("^[a-zA-Z ]*$",
             ErrorMessage = "Solo se permite letras")]
            [Display(Name = "Nombre")]
            public string Name { get; set; }

            [Required (ErrorMessage = "Este campo es requrido")]
            [StringLength(100, ErrorMessage = "El {0} debe tener al menos {2} y un máximo de {1} caracteres de longitud.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }
            [Required(ErrorMessage = "Este campo es requrido")]
            [DataType(DataType.Password)]
            [Display(Name = "Confirmar contraseña")]
            [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
            public string ConfirmPassword { get; set; }

            [Display(Name = "Código")]
            public string Code { get; set; }
        }

        public IActionResult OnGet(string code = null)
        {
            if (code == null)
            {
                return BadRequest("Se debe proporcionar un código para restablecer la contraseña.");
            }
            else
            {
                Input = new InputModel
                {
                    Code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code))
                };
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.FindByNameAsync(Input.Name);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToPage("./ResetPasswordConfirmation");
            }

            var result = await _userManager.ResetPasswordAsync(user, Input.Code, Input.Password);
            if (result.Succeeded)
            {
                await _emailSender
                       .SendEmailAsync(user.Email, "Asunto: Cambio de clave",
                       "Le informamos que el cambio de clave de la cuenta del usuario  " + user.UserName
                       + "se ejecutó satisfactoriamente")
                      .ConfigureAwait(false);

                return RedirectToPage("./ResetPasswordConfirmation");
            }

           
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Page();
        }
    }
}
