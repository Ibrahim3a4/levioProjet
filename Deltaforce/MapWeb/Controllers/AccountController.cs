using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ServicePattern;
using MapWeb.Models;
using Domain.Entity;
using Service.Identity;
using Data;
namespace MapWeb.Contollers
{
    [Authorize]
    public class AccountController : Controller
    {
        //===========================//
        //--------- MANAGERS ----------
        //===========================//

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private readonly ServiceUser _userService = new ServiceUser();


        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        //===========================//
        //--------- LOGIN ----------
        //===========================//

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        // [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    ModelState.AddModelError("", "Connected.");
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                default:
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
            }
        }

        //===========================//
        //--------- LOG OUT ---------
        //===========================//

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        //===========================//
        //--------- REGISTER --------
        //===========================//

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            LevioMapCtx ct = new LevioMapCtx();

            if (ModelState.IsValid)
            {

                IdentityResult result;

                // Switch on Selected Account type
                switch (model.AccountType)
                {
                    // Volunteer Account type selected:
                    case EAccountType.Client:
                        {
                            // create new volunteer and map form values to the instance
                            Client v = new Client { UserName = model.Email, Email = model.Email, FirstName = model.FirstName };
                            v.EmailConfirmed = true;
                            v.SecurityStamp = null;
                            result = await UserManager.CreateAsync(v, model.Password);

                            // Add User role to the new User
                            if (result.Succeeded)
                            {
                                // UserManager.AddToRole(v.Id, EAccountType.Patient.ToString());
                                await SignInManager.SignInAsync(v, isPersistent: false, rememberBrowser: false);
                                // Email confirmation here

                                return RedirectToAction("Index", "Home");
                            }
                            AddErrors(result);
                        }
                        break;

                    // Ressource Account type selected:
                    case EAccountType.Ressource:
                        {
                            Resource ngo = new Resource { UserName = model.Email, Email = model.Email, FirstName = model.FirstName/*, InterMandateId = 1 */};
                            result = await UserManager.CreateAsync(ngo, model.Password);
                            ngo.EmailConfirmed = true;
                           
                            //ngo.SecurityStamp = null;
                            // Add Ngo role to the new User
                            if (result.Succeeded)
                            {
                                //     UserManager.AddToRole(ngo.Id, EAccountType.Doctor.ToString());
                                await SignInManager.SignInAsync(ngo, isPersistent: false, rememberBrowser: false);

                                return RedirectToAction("Index", "Home");
                            }
                            // AddErrors(result);
                        }
                        break;
                }

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        //===========================//
        //--------- HELPERS ---------
        //===========================//


        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        // FOR REFERENCE
        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
        // Send an email with this link
        // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
        // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
        // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");


    }
}