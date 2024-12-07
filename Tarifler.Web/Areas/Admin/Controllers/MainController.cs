using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarifler.Core.Entity;
using Tarifler.Service.Abstract;
using Tarifler.Web.Areas.Admin.Models;

namespace Tarifler.Web.Areas.Admin.Controllers
{
    public class MainController : Controller
    {
        private readonly IService<User> _serviceUser;
        private readonly IService<YemekTarif> _serviceTarif;
        private readonly IService<Mesaj> _serviceMesaj;

        public MainController(IService<User> serviceUser, IService<YemekTarif> serviceTarif, IService<Mesaj> serviceMesaj)
        {
            _serviceUser = serviceUser;
            _serviceTarif = serviceTarif;
            _serviceMesaj = serviceMesaj;
        }

        [Area("Admin")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Index()
        {

            //OrderByDescending ile Son kayıttan başlayarak sırala
            //Take ile ilk 5 kayıt al
            //var post = await _postRepository.Posts.OrderByDescending(p => p.PublishedOn).Take(5).ToListAsync();

            var msg = await _serviceMesaj.GetAllWhereAsync(i =>i.Durum == false);
            var tarif = await _serviceTarif.GetQueryable().Include(x => x.User).Where(x=>x.IsActive==false).ToListAsync();
            var user = await _serviceUser.GetAllWhereAsync(i => i.IsActive == false);

            var model = new MainModelView()
            {
                yemekTarifleri = tarif,
                Kullanicilar = user,
                Mesajlar  = msg,
            };
            

            return View(model);
        }
    }
}
