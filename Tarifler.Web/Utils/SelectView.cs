using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tarifler.Core.Entity;
using Tarifler.Service.Abstract;

namespace Tarifler.Web.Utils
{
    public class SelectView
    {
        private readonly IService<YemekTarif> _serviceTarif;
        private readonly IService<User> _serviceUser;
        private readonly IService<Tur> _serviceTur;
        private readonly IService<Kategori> _serviceKategori;

        public SelectView(IService<YemekTarif> serviceTarif, IService<User> serviceUser, IService<Tur> serviceTur, IService<Kategori> serviceKategori)
        {
            _serviceTarif = serviceTarif;
            _serviceUser = serviceUser;
            _serviceTur = serviceTur;
            _serviceKategori = serviceKategori;
        }

        public  Dictionary<string, SelectList> SelectFill()
        {
            var kategori = new SelectList(_serviceKategori.GetQueryable(), "KategoriId", "KategoriAdi");
            var tur= new SelectList(_serviceTur.GetQueryable(), "TurId", "TurAdi");
            var user = new SelectList(_serviceUser.GetQueryable(), "UserId", "FirstName");

            var liste = new Dictionary<string, SelectList>() {
                {"kategori", kategori},
                {"tur", tur },
                {"user", user }
                };

            return liste;
        }
        public  Dictionary<string,SelectList> SelectFill(int KategoriId, int TurId, int UserId)
        {
            var kategori = new SelectList(_serviceKategori.GetQueryable(), "KategoriId", "KategoriAdi",KategoriId);
            var tur = new SelectList(_serviceTur.GetQueryable(), "TurId", "TurAdi", TurId);
            var user = new SelectList(_serviceUser.GetQueryable(), "UserId", "FirstName", UserId);

            var liste = new Dictionary<string,SelectList>() {
                {"kategori", kategori},
                {"tur", tur }, 
                {"user", user }
                };

            return liste;
        }

    }
}
