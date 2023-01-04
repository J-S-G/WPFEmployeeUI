using System;
using System.Collections.Generic;

namespace WPFEmployeeUI.DB;

public partial class Salary
{
    public int EmployeeId { get; set; }

    public int? Amount { get; set; }

    public DateTime? Year { get; set; }

    public int? MonthId { get; set; }
}
