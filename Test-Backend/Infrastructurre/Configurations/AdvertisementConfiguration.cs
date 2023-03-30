using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System.Reflection.Emit;

using Test_Backend.Domain.Models;

namespace Test_Backend.Infrastructurre.Configurations
{
    public class AdvertisementConfiguration : IEntityTypeConfiguration<AdvertisementModel>
    {
        public void Configure(EntityTypeBuilder<AdvertisementModel> builder)
        {
            builder.HasKey(e => e.AdvertisementId)
                .HasName("advertisement_pkey");

            builder.Property(e => e.AuthorId)
                .IsRequired()
            .HasColumnName("author_id");

            builder
                .HasOne(x => x.Author)
                .WithMany(x => x.Advertisements)
                .HasForeignKey(x => x.AuthorId);

            builder.Property(e => e.AdvertisementId)
                .HasColumnName("advertisement_id");

            builder.Property(e => e.Title)
                .HasColumnName("title");

            builder.Property(e => e.Content)
                .HasColumnName("content");

            builder.Property(e => e.CreationDate)
                .HasColumnName("creation_date");

            builder.Property(e => e.ModifiedDate)
                .HasColumnName("modified_date");

            builder.Property(e => e.ActionStartDate)
                .HasColumnName("action_start_date");

            builder.Property(e => e.ActionEndDate)
                .HasColumnName("action_end_date");

            builder.ToTable("advertisements");
        }
    }
}
