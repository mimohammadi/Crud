using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Crud.Repository.Configurations.PersonalInfo
{
    internal class PersonalInfoEfConfig : IEntityTypeConfiguration<Crud.Domain.Models.PersonalInfo.PersonalInfo>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.PersonalInfo.PersonalInfo> builder)
        {
            builder.HasQueryFilter(a => a.IsDeleted == false);
            builder.Property(a => a.NationalId).IsRequired().HasMaxLength(10);
        }
    }
}
