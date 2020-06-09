using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookingAdminUi.Models
{
    public partial class SmbDbContext : DbContext
    {
        public SmbDbContext(DbContextOptions<SmbDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppointmentBookingIncentiveCampaign> AppointmentBookingIncentiveCampaign { get; set; }
        public virtual DbSet<AppointmentBookingNonMonetaryIncentiveCampaign> AppointmentBookingNonMonetaryIncentiveCampaign { get; set; }
        public virtual DbSet<AppointmentBookingReportedForIncentive> AppointmentBookingReportedForIncentive { get; set; }
        public virtual DbSet<AppointmentBookingWhitelistedIncentiveAccounts> AppointmentBookingWhitelistedIncentiveAccounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentBookingIncentiveCampaign>(entity =>
            {
                entity.HasKey(e => e.CampaignCode)
                    .HasName("Pk_AppointmentBookingIncentiveCampaign");

                entity.Property(e => e.CampaignCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BillingSystem)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ElecAmount).HasDefaultValueSql("((15))");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.GasAmount).HasDefaultValueSql("((15))");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AppointmentBookingNonMonetaryIncentiveCampaign>(entity =>
            {
                entity.HasKey(e => e.CampaignCode)
                    .HasName("Pk_AppointmentBookingNonMonetaryIncentiveCampaign");

                entity.Property(e => e.CampaignCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BillingSystem)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Item)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SendAddress)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<AppointmentBookingReportedForIncentive>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BillingSystem)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasColumnType("datetime");
            });

            modelBuilder.Entity<AppointmentBookingWhitelistedIncentiveAccounts>(entity =>
            {
                entity.Property(e => e.BillingSystem)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CampaignCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JobType)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.NonMonetaryCampaignCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CampaignCodeNavigation)
                    .WithMany(p => p.AppointmentBookingWhitelistedIncentiveAccounts)
                    .HasForeignKey(d => d.CampaignCode)
                    .HasConstraintName("FK_AppointmentBookingIncentiveCampaign_CampaignCode");

                entity.HasOne(d => d.NonMonetaryCampaignCodeNavigation)
                    .WithMany(p => p.AppointmentBookingWhitelistedIncentiveAccounts)
                    .HasForeignKey(d => d.NonMonetaryCampaignCode)
                    .HasConstraintName("FK_AppointmentBookingNonMonetaryIncentiveCampaign_CampaignCode");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
