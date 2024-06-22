using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace models;

public partial class HnecEvotingContext : DbContext
{
    public HnecEvotingContext()
    {
    }

    public HnecEvotingContext(DbContextOptions<HnecEvotingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Vote> Votes { get; set; }

    public virtual DbSet<Voter> Voters { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vote>(entity =>
        {
            entity.ToTable("votes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CandidateId).HasColumnName("candidate_id");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.VoterId).HasColumnName("voter_id");
            entity.Property(e => e.VotingDate).HasColumnName("voting_date");

            entity.HasOne(d => d.Voter).WithMany(p => p.Votes)
                .HasForeignKey(d => d.VoterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_votes_voters");
        });

        modelBuilder.Entity<Voter>(entity =>
        {
            entity.ToTable("voters");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.CardExpDate).HasColumnName("card_exp_date");
            entity.Property(e => e.CardNo)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("card_no");
            entity.Property(e => e.CardPin)
                .HasMaxLength(100)
                .HasColumnName("card_pin");
            entity.Property(e => e.CityId).HasColumnName("city_id");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("full_name");
            entity.Property(e => e.MunicipalityId).HasColumnName("municipality_id");
            entity.Property(e => e.NationalNo)
                .HasMaxLength(50)
                .HasColumnName("national_no");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(50)
                .HasColumnName("phone_no");
            entity.Property(e => e.PlaceOfBirth)
                .HasMaxLength(50)
                .HasColumnName("place_of_birth");
            entity.Property(e => e.Status)
                .HasDefaultValue((short)1)
                .HasColumnName("status");
            entity.Property(e => e.VotingCenterId).HasColumnName("voting_center_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
