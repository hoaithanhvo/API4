using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAPI.Data
{
    public partial class NIDEC_IOT_TESTContext : DbContext
    {
        public NIDEC_IOT_TESTContext()
        {
        }

        public NIDEC_IOT_TESTContext(DbContextOptions<NIDEC_IOT_TESTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public virtual DbSet<TIotMoldMaster> TIotMoldMasters { get; set; }
        public virtual DbSet<TIotPressMasterTest> TIotPressMasterTests { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=10.234.1.24;Initial Catalog=NIDEC_IOT_TEST;Persist Security Info=True;User ID=sa;Password=sa;Encrypt=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.ToTable("RefreshToken");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ExpiredAt).HasColumnType("datetime");

                entity.Property(e => e.IssuedAt).HasColumnType("datetime");

                entity.Property(e => e.JwtId)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<TIotMoldMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_IOT_MOLD_MASTER");

                entity.Property(e => e.CavQty)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("cav_qty");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MachineCd)
                    .HasMaxLength(50)
                    .HasColumnName("machine_cd");

                entity.Property(e => e.MachineStatus).HasColumnName("machine_status");

                entity.Property(e => e.MaintenanceQty)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("maintenance_qty");

                entity.Property(e => e.MaintenanceShot)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("maintenance_shot");

                entity.Property(e => e.MaterialType)
                    .HasMaxLength(50)
                    .HasColumnName("material_type");

                entity.Property(e => e.MaterialUsage)
                    .HasMaxLength(50)
                    .HasColumnName("material_usage");

                entity.Property(e => e.MoldName)
                    .HasMaxLength(50)
                    .HasColumnName("mold_name");

                entity.Property(e => e.MoldNo)
                    .HasMaxLength(50)
                    .HasColumnName("mold_no");

                entity.Property(e => e.MoldSerial)
                    .HasMaxLength(50)
                    .HasColumnName("mold_serial");

                entity.Property(e => e.ReycleRatio)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("reycle_ratio");

                entity.Property(e => e.ScrapQty)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("scrap_qty");

                entity.Property(e => e.ScrapShot)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("scrap_shot");

                entity.Property(e => e.StackQty)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("stack_qty");
            });

            modelBuilder.Entity<TIotPressMasterTest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("T_IOT_PRESS_MASTER_TEST");

                entity.Property(e => e.CavQty)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("cav_qty");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MachineCd)
                    .HasMaxLength(50)
                    .HasColumnName("machine_cd");

                entity.Property(e => e.MachineStatus).HasColumnName("machine_status");

                entity.Property(e => e.MaintenanceQty)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("maintenance_qty");

                entity.Property(e => e.MaintenanceShot)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("maintenance_shot");

                entity.Property(e => e.MaterialType)
                    .HasMaxLength(50)
                    .HasColumnName("material_type");

                entity.Property(e => e.MaterialUsage)
                    .HasMaxLength(50)
                    .HasColumnName("material_usage");

                entity.Property(e => e.MoldName)
                    .HasMaxLength(50)
                    .HasColumnName("mold_name");

                entity.Property(e => e.MoldNo)
                    .HasMaxLength(50)
                    .HasColumnName("mold_no");

                entity.Property(e => e.MoldSerial)
                    .HasMaxLength(50)
                    .HasColumnName("mold_serial");

                entity.Property(e => e.ReycleRatio)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("reycle_ratio");

                entity.Property(e => e.ScrapQty)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("scrap_qty");

                entity.Property(e => e.ScrapShot)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("scrap_shot");

                entity.Property(e => e.StackQty)
                    .HasColumnType("numeric(18, 0)")
                    .HasColumnName("stack_qty");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email).HasMaxLength(150);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.PassWord).HasMaxLength(150);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
