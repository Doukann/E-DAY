using KD25_BitirmeProjesi.CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD25_BitirmeProjesi.InfrastructureLayer.Configurations
{
    class Company_CFG : BaseConfiguration<Company>, IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(x => x.CompanyName)
                   .HasColumnType("nvarchar")
                   .HasMaxLength(20)
                   .IsRequired();
        }
    }
}
