using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Observer_Design_Pattern.DAL.Entities;
using Observer_Design_Pattern.Models;
using Observer_Design_Pattern.ObserverDesignPattern;

namespace Observer_Design_Pattern.Controllers
{
    public class DefaultController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly UserObserverObject _userObserverObject;
        public DefaultController(UserManager<AppUser> userManager, UserObserverObject userObserverObject)
        {
            _userManager = userManager;
            _userObserverObject = userObserverObject;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterUserViewModel registerUserViewModel)
        {
            var appuser = new AppUser()
            {
                Name = registerUserViewModel.Name,
                Surname = registerUserViewModel.Surname,
                Email = registerUserViewModel.Mail,
                UserName = registerUserViewModel.Username
            };
            var result = await _userManager.CreateAsync(appuser, registerUserViewModel.Password);
            if (result.Succeeded)
            {
                _userObserverObject.NotifyObserver(appuser);
                ViewBag.Message = "Üyelik Başarıyla Oluşturuldu";
            }
            else
            {
                ViewBag.Message = "Bir hata oluştu";
            }
            return View();
        }
    }
}
