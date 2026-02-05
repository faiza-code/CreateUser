using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CreateUser.Configurations
{
    public class CreateUserConfigration : IEntityTypeConfiguration<CreateUser>
    {
        public void Configure(EntityTypeBuilder<CreateUser> builder)
        {
          
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(50);

        }
    
    }
}
