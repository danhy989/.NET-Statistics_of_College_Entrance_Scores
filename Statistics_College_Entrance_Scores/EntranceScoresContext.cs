﻿using Statistics_College_Entrance_Scores.entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Statistics_College_Entrance_Scores
{
    public class EntranceScoresContext : DbContext, IDisposable
	{
		public EntranceScoresContext()
		{
		}

		public EntranceScoresContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<CollegeEntity> collegeEntities { get; set; }
		public DbSet<MajorEntity> majorEntities { get; set; }
		public DbSet<MajorCollege> majorColleges { get; set; }
		public DbSet<Province> provinces { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			string host = Environment.GetEnvironmentVariable("db_entrance_scores_host");
			string username = Environment.GetEnvironmentVariable("db_entrance_scores_username");
			string password = Environment.GetEnvironmentVariable("db_entrance_scores_password");
			optionsBuilder.UseNpgsql(
				@"Host="+host+";Port=5432;Username="+username+";Password="+password+";Database=uit;");
			optionsBuilder.EnableSensitiveDataLogging();
		}

        
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Configure default schema
			modelBuilder.HasDefaultSchema("Entrance_Scores");
			modelBuilder.Entity<Province>()
				.HasMany(p => p.collegeEntities)
				.WithOne(c => c.province)
				.HasForeignKey(p => p.province_id)
				.HasConstraintName("ForeignKey_Province_CollegeEntity");
		}

        public void Dispose() => GC.SuppressFinalize(this);
    }
}

