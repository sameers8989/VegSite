using System;
using System.Collections.Generic;

namespace works.Models;

public partial class Vegetable
{
    public int Id { get; set; }

    public string? VegetablesName { get; set; }

    public virtual ICollection<CustomerDetail> CustomerDetails { get; set; } = new List<CustomerDetail>();
}
