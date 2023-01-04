using System;
using System.Collections.Generic;

namespace WPFEmployeeUI.DB;

public partial class Position
{
    public int Id { get; set; }

    public string PositionName { get; set; } = null!;

    public int DepartmentId { get; set; }
}
