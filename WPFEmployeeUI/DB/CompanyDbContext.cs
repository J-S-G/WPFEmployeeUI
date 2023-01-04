using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WPFEmployeeUI.DB;

public partial class CompanyDbContext : DbContext
{
    public CompanyDbContext()
    {
    }

    public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Permissionstate> Permissionstates { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<Salarymonth> Salarymonths { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<Taskstate> Taskstates { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
# warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        
        => optionsBuilder.UseSqlServer("Server=jsg96.database.windows.net;User Id=jsg96;password=CheeseDick1996!;Database=CompanyDB;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_department_ID");

            entity.ToTable("department", "company");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DepartmentName).HasMaxLength(50);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_employee_ID");

            entity.ToTable("employee", "company");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.Birthday).HasColumnType("date");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.ImagePath).HasMaxLength(200);
            entity.Property(e => e.IsAdmin)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("isAdmin");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(200);
            entity.Property(e => e.PositionId).HasColumnName("PositionID");
            entity.Property(e => e.SurName).HasMaxLength(50);
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_permission_ID");

            entity.ToTable("permission", "company");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.PermissionEndDate).HasColumnType("date");
            entity.Property(e => e.PermissionExplanation).HasMaxLength(100);
            entity.Property(e => e.PermissionStartDate).HasColumnType("date");
        });

        modelBuilder.Entity<Permissionstate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_permissionstate_ID");

            entity.ToTable("permissionstate", "company");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.StateName).HasMaxLength(50);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_position_ID");

            entity.ToTable("position", "company");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.PositionName).HasMaxLength(50);
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK_salary_EmployeeID");

            entity.ToTable("salary", "company");

            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.MonthId).HasColumnName("MonthID");
            entity.Property(e => e.Year).HasColumnType("date");
        });

        modelBuilder.Entity<Salarymonth>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_salarymonth_ID");

            entity.ToTable("salarymonth", "company");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.MonthName).HasMaxLength(100);
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_task_ID");

            entity.ToTable("task", "company");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.TaskContent).HasMaxLength(50);
            entity.Property(e => e.TaskDeliveryDate).HasColumnType("date");
            entity.Property(e => e.TaskStartDate).HasColumnType("date");
            entity.Property(e => e.TaskTitle).HasMaxLength(50);
        });

        modelBuilder.Entity<Taskstate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_taskstate_ID");

            entity.ToTable("taskstate", "company");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.StateName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
