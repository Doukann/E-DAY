using KD25_BitirmeProjesi.CoreLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD25_BitirmeProjesi.InfrastructureLayer.Configurations
{
    class AppUser_CFG : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasIndex(x => x.UserName); // Unique yaptık

            builder.Property(x => x.FirstName)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(x => x.SecondName)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(20);

            builder.Property(x => x.Surname)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(x => x.SecondSurname)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(20);

            builder.Property(x => x.Avatar)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(150)
                   .HasDefaultValue("avatar.png");

            builder.Property(x => x.BirthDate)
                   .HasColumnType("smalldatetime");

            builder.Property(x => x.BirthPlace)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(30);

            builder.HasIndex(x => x.NationalID);
            builder.Property(x => x.NationalID)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(20)
                   .IsRequired();

            builder.Property(x => x.StartDate)
                   .HasColumnType("smalldatetime");

            builder.Property(x => x.EndDate)
                   .HasColumnType("smalldatetime");

            builder.Property(x => x.Proficiency)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(20);

            builder.Property(x => x.Address)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(20);

            builder.Property(x => x.Salary)
                   .HasColumnType("money")
                   .HasMaxLength(20);




            // Gerekli default User'lar ekleniyor
            AppUser user = new AppUser
            {
                Id = 1,
                FirstName = "Admin",
                Surname = "Admin",
                NationalID = "12345678910",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = false,

            };
            user.PasswordHash = new PasswordHasher<AppUser>().HashPassword(user, "Admin123.");

            builder.HasData(user);


        }
    }
}
