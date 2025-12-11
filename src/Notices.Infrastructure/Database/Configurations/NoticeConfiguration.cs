using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notices.Domain.Entities;

public class NoticeConfiguration : IEntityTypeConfiguration<Notice>
{
    public void Configure(EntityTypeBuilder<Notice> builder)
    {
        builder.HasKey(n => n.Id);

        builder.Property(n => n.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(n => n.Content)
            .IsRequired();

        // Owner (User)
        builder.HasOne(n => n.NoticeOwner)
            .WithMany()
            .HasForeignKey("OwnerId")
            .IsRequired();

        // Offers (child entities)
        builder.OwnsMany(n => n.Offers, offers =>
        {
            offers.WithOwner().HasForeignKey("NoticeId");
            offers.HasKey(o => o.Id);

            offers.Property(o => o.Price).IsRequired();
            offers.Property(o => o.EducationLevel).IsRequired();
        });

    }
}