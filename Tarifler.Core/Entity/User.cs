using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tarifler.Core.Entity
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string? UserPhone { get; set; }
        public string UserPassword { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsGuest { get; set; }
        public bool IsMember { get; set; }
        public bool IsActive { get; set; }

        public List<YemekTarif> YemekTarifleri { get; set; } = new List<YemekTarif>();
        public List<Yorum> Yorumlar { get; set; } = new List<Yorum>();
    }
}
