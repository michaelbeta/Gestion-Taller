using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GestorDeTaller.UI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly IEmailSender _emailSender;
        private DateTime Horalocal = DateTime.Now;
        public LoginModel(SignInManager<IdentityUser> signInManager, 
            ILogger<LoginModel> logger,
            UserManager<IdentityUser> userManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

       [TempData] 
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Este campo es requerido")]

            [Display(Name = "Nombre")]
            public string Name{ get; set; }

            [Required(ErrorMessage = "Este campo es requerido")]
            //[RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", 
            // ErrorMessage = "La clave debe tener al menos 8 caracteres y contener 3 de 4 de los siguientes: mayúsculas(A - Z), minúsculas(a - z), números(0 - 9) y caracteres especiales(p.Ej.! @ # $% ^ & *) ")]
            [DataType(DataType.Password)]
            [Display(Name = "Clave")]
           
            public string Password { get; set; }

            [Display(Name = "Recuerdame?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage=""))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage="Intento de inicio de sesión no válido");
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/CatalogoDeArticulos/ListarCatalogoDeArticulos");
           
            if (ModelState.IsValid)
            {
               
                var result = await _signInManager.PasswordSignInAsync(Input.Name, Input.Password, Input.RememberMe, lockoutOnFailure: true);
               

                if (result.Succeeded)
                {
                    _logger.LogInformation("Usuario logueado");

                    var userABuscar = await _userManager.FindByNameAsync(Input.Name);
                  
                    await _emailSender
                        .SendEmailAsync(userABuscar.Email, "Asunto:  Inicio de sesión usuario  "+ userABuscar.UserName,
                        "Usted inicio sesión día" + Horalocal)
                       .ConfigureAwait(false);

                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    var usuarioBuscar = await _userManager.FindByNameAsync(Input.Name);
                    
                    await _emailSender
                        .SendEmailAsync(usuarioBuscar.Email, "Asunto: Usuario Bloqueado",
                        "Le informamos que la cuenta del usuario " +usuarioBuscar.UserName+
                        "se encuentra bloqueada por 10 minutos.Por favor ingrese el día" + Horalocal.Date+
                        "a las"+ Horalocal.ToLocalTime()+10)
                       .ConfigureAwait(false);

                    _logger.LogWarning("Cuenta de usuario blockeada");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Intento de inicio de sesión no válido");
                    return Page();
                }
            }

          
            return Page();
        }
    }
}
