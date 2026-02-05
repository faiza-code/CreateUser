using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CreateUser.Configurations
{
    public class AddUserConfigration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(t => t.Name)
                 .IsRequired()
                 .HasMaxLength(70);

            builder.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(t => t.PhoneNumber)
               .IsRequired();

            builder.Property(t => t.BOD)
                .HasDefaultValue(DateTime.UtcNow);

    

        }
    
    }
}
