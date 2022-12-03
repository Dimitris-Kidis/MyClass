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
    public class ClassTeacherConfiguration : IEntityTypeConfiguration<ClassTeacher>
    {
        public void Configure(EntityTypeBuilder<ClassTeacher> builder)
        {
        }
    }
}
