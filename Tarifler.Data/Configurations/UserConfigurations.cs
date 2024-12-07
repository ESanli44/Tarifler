using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tarifler.Core.Entity;

namespace Tarifler.Data.Configurations
{
    internal class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new List<User>
            {
                new(){ UserId=1, FirstName="Emrah", LastName="Şanlı", UserName="Esanli", UserEmail="Esanli@gmail.com", UserPhone="11111111111",
                IsActive=true, IsAdmin=true, IsGuest=false, IsMember=false, UserPassword="Emrah.123"},

                new(){ UserId=2, FirstName="Aylin", LastName="Şanlı", UserName="Asanli", UserEmail="Asanli@gmail.com", UserPhone="11111111111",
                IsActive=true, IsAdmin=false, IsGuest=false, IsMember=true, UserPassword="Aylin.123"},

                new(){ UserId=3, FirstName="Umay", LastName="Şanlı", UserName="Usanli", UserEmail="Usanli@gmail.com", UserPhone="11111111111",
                IsActive=true, IsAdmin=false, IsGuest=false, IsMember=true, UserPassword="Umay.123"},

                new(){ UserId=4, FirstName="Zehra", LastName="Şanlı", UserName="Zsanli", UserEmail="Zsanli@gmail.com", UserPhone="11111111111",
                IsActive=true, IsAdmin=false, IsGuest=true, IsMember=false, UserPassword="Zehra.123"},
            });
        }
    }
}
