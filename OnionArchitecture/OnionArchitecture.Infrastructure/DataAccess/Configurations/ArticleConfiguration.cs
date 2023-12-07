using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnionArchitecture.Domain.Core;

namespace OnionArchitecture.Infrastructure.DataAccess.Configurations
{
    public class CountryConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}
