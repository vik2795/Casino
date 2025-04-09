﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CasinoProject.Models;

public partial class CasinoContext : DbContext
{
    public CasinoContext()
    {
    }

    public CasinoContext(DbContextOptions<CasinoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<Play> Plays { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Database\\casino.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("games");

            entity.Property(e => e.Game1).HasColumnName("game");
            entity.Property(e => e.Id)
                .HasColumnType("INT")
                .HasColumnName("id");
        });

        modelBuilder.Entity<Play>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("plays");

            entity.Property(e => e.Amount)
                .HasColumnType("INT")
                .HasColumnName("amount");
            entity.Property(e => e.GameId)
                .HasColumnType("INT")
                .HasColumnName("gameId");
            entity.Property(e => e.PlayerId)
                .HasColumnType("INT")
                .HasColumnName("playerId");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("players");

            entity.Property(e => e.Amount)
                .HasColumnType("INT")
                .HasColumnName("amount");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Id)
                .HasColumnType("INT")
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
