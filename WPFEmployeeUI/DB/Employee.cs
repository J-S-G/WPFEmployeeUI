using System;
using System.Collections.Generic;

namespace WPFEmployeeUI.DB;

public partial class Employee
{
    public int Id { get; set; }

    public int UserNum { get; set; }

    public string Name { get; set; } = null!;

    public string SurName { get; set; } = null!;

    public string ImagePath { get; set; } = null!;

    public int DepartmentId { get; set; }

    public int PositionId { get; set; }

    public int Salary { get; set; }

    public DateTime? Birthday { get; set; }

    public string? Address { get; set; }

    public string? Password { get; set; }

    public byte[]? IsAdmin { get; set; }
}
