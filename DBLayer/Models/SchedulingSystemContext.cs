using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DBLayer.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DBLayer.Models
{
    public partial class SchedulingSystemContext : DbContext
    {
        public SchedulingSystemContext()
        {
        }

        public SchedulingSystemContext(DbContextOptions<SchedulingSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentClassMapper> StudentClassMappers { get; set; }

        public DbSet<ClassMappingDto> ClassMappingDto { get; set; }
        public DbSet<StudentMappingDTO> StudentMappingDTO { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=KSRB\\SQLEXPRESS;Database=SchedulingSystem;Trusted_Connection=True");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("Class");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<StudentClassMapper>(entity =>
            {
                entity.HasKey(e => e.MapperId)
                    .HasName("PK_Mapper");

                entity.ToTable("StudentClassMapper");

                entity.HasIndex(e => new { e.StudentId, e.ClassId }, "UQ__StudentC__2E74B802ABD22CDC")
                    .IsUnique();

                entity.Property(e => e.MapperId).HasColumnName("MapperID");

                entity.Property(e => e.AssignedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AssignedDate).HasColumnType("datetime");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                //entity.HasOne(d => d.Class)
                //    .WithMany(p => p.StudentClassMappers)
                //    .HasForeignKey(d => d.ClassId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__StudentCl__Class__4D94879B");

                //entity.HasOne(d => d.Student)
                //    .WithMany(p => p.StudentClassMappers)
                //    .HasForeignKey(d => d.StudentId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__StudentCl__Stude__4CA06362");
            });
           
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public async Task<IEnumerable<StudentMappingDTO>> GetStudentMappingByClassId(int classID)
        {
            // Initialization.  
            List<StudentMappingDTO> lst = new List<StudentMappingDTO>();

            try
            {
                // Settings.  
                SqlParameter idParam = new SqlParameter("@Id", classID.ToString() ?? (object)DBNull.Value);

                // Processing.  
                string sqlQuery = "EXEC [dbo].[usp_GetStudentMappingByClassId] @Id";
                lst = await this.Set<StudentMappingDTO>().FromSqlRaw(sqlQuery, idParam).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lst;
        }

        public async Task<IEnumerable<ClassMappingDto>> GetClassMappingByStuedntId(int studentID)
        {
            // Initialization.  
            List<ClassMappingDto> lst = new List<ClassMappingDto>();

            try
            {
                // Settings.  
                SqlParameter idParam = new SqlParameter("@Id", studentID.ToString() ?? (object)DBNull.Value);

                // Processing.  
                string sqlQuery = "EXEC [dbo].[usp_GetClassMappingByStudentId] @Id";

                lst = await this.Set<ClassMappingDto>().FromSqlRaw(sqlQuery, idParam).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lst;
        }
    }
}
