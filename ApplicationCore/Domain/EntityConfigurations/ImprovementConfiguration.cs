using ApplicationCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain.EntityConfigurations
{
    public class ImprovementConfiguration : IEntityTypeConfiguration<Improvement>
    {
        public void Configure(EntityTypeBuilder<Improvement> builder)
        {
            //builder.HasMany(user => user.Student)
            //    .WithOne(specialist => specialist.User)
            //    .HasForeignKey(x => x.Id);




            //.HasForeignKey<Student>(specialist => specialist.Id);
        }
    }
}
