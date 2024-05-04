using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace MAUI_API_TESTING.Models;

public partial class RdpContext : DbContext
{
    public RdpContext()
    {
    }

    public RdpContext(DbContextOptions<RdpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Criterion> Criteria { get; set; }

    public virtual DbSet<RatingCriterion> RatingCriteria { get; set; }


    public virtual DbSet<RatingMonth> RatingMonths { get; set; }

    public virtual DbSet<Scoring> Scorings { get; set; }

    public virtual DbSet<Users> Users { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Criterion>(entity =>
        {
            entity.HasKey(e => e.Criteriaid).HasName("criteria_pkey");

            entity.ToTable("criteria");

            entity.Property(e => e.Criteriaid)
                .HasMaxLength(255)
                .HasColumnName("criteriaid");
            entity.Property(e => e.Datecreated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datecreated");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<RatingCriterion>(entity =>
        {
            entity.HasKey(e => e.Rcid).HasName("rating_criteria_pkey");

            entity.ToTable("rating_criteria");

            entity.Property(e => e.Rcid)
                .HasMaxLength(255)
                .HasColumnName("rcid");
            entity.Property(e => e.Criteriaid)
                .HasMaxLength(255)
                .HasColumnName("criteriaid");
            entity.Property(e => e.Ratingmonthid)
                .HasMaxLength(255)
                .HasColumnName("ratingmonthid");
            entity.Property(e => e.Scoreidintern)
                .HasMaxLength(255)
                .HasColumnName("scoreidintern");
            entity.Property(e => e.Scoreidsupervisor)
                .HasMaxLength(255)
                .HasColumnName("scoreidsupervisor");

            entity.HasOne(d => d.Criteria).WithMany(p => p.RatingCriteria)
                .HasForeignKey(d => d.Criteriaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rating_criteria_criteriaid_fkey");

            entity.HasOne(d => d.Ratingmonth).WithMany(p => p.RatingCriteria)
                .HasForeignKey(d => d.Ratingmonthid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rating_criteria_ratingmonthid_fkey");

            entity.HasOne(d => d.ScoreidinternNavigation).WithMany(p => p.RatingCriterionScoreidinternNavigations)
                .HasForeignKey(d => d.Scoreidintern)
                .HasConstraintName("rating_criteria_scoreidintern_fkey");

            entity.HasOne(d => d.ScoreidsupervisorNavigation).WithMany(p => p.RatingCriterionScoreidsupervisorNavigations)
                .HasForeignKey(d => d.Scoreidsupervisor)
                .HasConstraintName("rating_criteria_scoreidsupervisor_fkey");
        });

        modelBuilder.Entity<RatingMonth>(entity =>
        {
            entity.HasKey(e => e.Ratingmonthid).HasName("rating_month_pkey");

            entity.ToTable("rating_month");

            entity.Property(e => e.Ratingmonthid)
                .HasMaxLength(255)
                .HasColumnName("ratingmonthid");
            entity.Property(e => e.Month)
                .HasMaxLength(255)
                .HasColumnName("month");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("status");
            entity.Property(e => e.Userid)
                .HasMaxLength(255)
                .HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.RatingMonths)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rating_month_userid_fkey");
        });

        modelBuilder.Entity<Scoring>(entity =>
        {
            entity.HasKey(e => e.Scoreid).HasName("scoring_pkey");

            entity.ToTable("scoring");

            entity.Property(e => e.Scoreid)
                .HasMaxLength(255)
                .HasColumnName("scoreid");
            entity.Property(e => e.Comment)
                .HasMaxLength(255)
                .HasColumnName("comment");
            entity.Property(e => e.Criteriaid)
                .HasMaxLength(255)
                .HasColumnName("criteriaid");
            entity.Property(e => e.Score).HasColumnName("score");

            entity.HasOne(d => d.Criteria).WithMany(p => p.Scorings)
                .HasForeignKey(d => d.Criteriaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("scoring_criteriaid_fkey");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Userid)
                .HasMaxLength(255)
                .HasColumnName("userid");
            entity.Property(e => e.Enddate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("enddate");
            entity.Property(e => e.Isintern).HasColumnName("isintern");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Role)
                .HasMaxLength(255)
                .HasColumnName("role");
            entity.Property(e => e.Startdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("startdate");
            entity.Property(e => e.Supervisoruserid)
                .HasMaxLength(255)
                .HasColumnName("supervisoruserid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
