using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EducationalCenter.Entity
{
    public partial class ADO : DbContext
    {
        public ADO()
            : base("name=ADO")
        {
        }
        private static ADO _instance;
        public static ADO Instance
        {
            get { return _instance ?? (_instance = new ADO()); }
        }

        public virtual DbSet<Day> Day { get; set; }
        public virtual DbSet<EvaluationAndUser> EvaluationAndUser { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAndSubject> UserAndSubject { get; set; }
        public virtual DbSet<Evaluation> Evaluation { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Day>()
                .HasMany(e => e.EvaluationAndUser)
                .WithRequired(e => e.Day)
                .HasForeignKey(e => e.IdDay)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.User)
                .WithOptional(e => e.Group)
                .HasForeignKey(e => e.IdGroup);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.User)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.IdRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.EvaluationAndUser)
                .WithRequired(e => e.Subject)
                .HasForeignKey(e => e.IdSubject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.UserAndSubject)
                .WithRequired(e => e.Subject)
                .HasForeignKey(e => e.IdSubject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.EvaluationAndUser)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserAndSubject)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);
        }
    }
}
