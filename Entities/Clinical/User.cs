using System;
using System.Collections.Generic;

namespace TestAPI.Entities.Clinical;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public int? Age { get; set; }

    public double? Height { get; set; }
}
