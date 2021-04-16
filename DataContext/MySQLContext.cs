using API.IMDB.Config;
using API.IMDB.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace API.IMDB.DataContext
{
    public interface IMySQLContext
    {
        DbSet<Employee> Employees { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<DepartmentEmployee> DepartmentEmployee { get; set; }
    }

    public class MySQLContext : DbContext, IMySQLContext {
        private readonly ConnectionStrings _connectionStrings;

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentEmployee> DepartmentEmployee { get; set; }

        public MySQLContext(DbContextOptions<MySQLContext> options, IOptions<ConnectionStrings> connectionStrings)
            : base(options)
        {
            this._connectionStrings = connectionStrings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
            options.UseMySQL(this._connectionStrings.MySQL);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Title>().HasKey(t => new { t.EmployeeId });
            builder.Entity<Salary>().HasKey(s => new { s.EmployeeId });

            builder.Entity<DepartmentEmployee>().HasKey(d => new { d.EmployeeId, d.DepartmentId });
            builder.Entity<DepartmentManager>().HasKey(d => new { d.EmployeeId, d.DepartmentId });

            builder.Entity<Employee>().HasKey(e => new { e.EmployeeId });
            builder.Entity<Department>().HasKey(d => new { d.DepartmentId });

            builder.Entity<Employee>()
                .HasMany(e => e.Titles)
                .WithOne(t => t.Employee);
            builder.Entity<Employee>()
                .HasMany(e => e.Salaries)
                .WithOne(s => s.Employee);

            builder.Entity<DepartmentEmployee>()
                .HasOne(de => de.Employee)
                .WithMany(e => e.DepartmentsEmployed)
                .HasForeignKey(de => de.DepartmentId);
            builder.Entity<DepartmentEmployee>()
                .HasOne(de => de.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(de => de.EmployeeId);

            builder.Entity<DepartmentManager>()
                .HasOne(de => de.Employee)
                .WithMany(e => e.DepartmentsManaging)
                .HasForeignKey(de => de.DepartmentId);
            builder.Entity<DepartmentManager>()
                .HasOne(dm => dm.Department)
                .WithMany(d => d.Managers)
                .HasForeignKey(dm => dm.EmployeeId);
        }
    }
}