using System;
using System.Collections.Generic;

namespace TestAPI.Entities.Clinical;

public partial class Address
{
    public int Id { get; set; }

    public string? Line1 { get; set; }

    public string? Line2 { get; set; }

    public int? PostCode { get; set; }
}
