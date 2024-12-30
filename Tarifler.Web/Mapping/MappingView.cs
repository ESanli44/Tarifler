using AutoMapper;
using Tarifler.Core.Entity;
using Tarifler.Web.Areas.Admin.Models;
using Tarifler.Web.Models;

namespace Tarifler.Web.Mapping
{
    public class MappingView : Profile
    {
        public MappingView()
        {
            CreateMap<YemekTarif, TarifModelView>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
            CreateMap<User, LoginViewModel>().ReverseMap();
            CreateMap<Mesaj, IletisimViewModel>().ReverseMap();
            CreateMap<YemekTarif, YemekViewModel>().ReverseMap();
            CreateMap<Yorum, YorumViewModel>().ReverseMap();
            CreateMap<Begeni, BegeniViewModel>().ReverseMap();
            CreateMap<User, SifreGuncelleViewModel>().ReverseMap();
            CreateMap<User, BilgilerimViewModel>().ReverseMap();
            CreateMap<YemekTarif, tarifUptadateViewModel>().ReverseMap();
        }
    }
}
