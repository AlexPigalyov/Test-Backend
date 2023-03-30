using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Test_Backend.Domain.Models;

namespace Test_Backend.Infrastructurre.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<AuthorModel>
    {
        public void Configure(EntityTypeBuilder<AuthorModel> builder)
        {
            builder.HasKey(e => e.AuthorId)
                .HasName("author_pkey");

            builder.Property(e => e.AuthorId)
                .HasColumnName("author_id");

            builder.Property(e => e.FirstName)
                .HasColumnName("first_name");

            builder.Property(e => e.LastName)
                .HasColumnName("last_name");

            builder.Property(e => e.Rating)
                .HasColumnName("rating");

            builder.ToTable("authors");
        }
    }
}
