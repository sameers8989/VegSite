using System;
using System.Collections.Generic;

namespace works.Models;

public partial class CustomerDetail
{
    public int CustomerId { get; set; }

    public int? LoginDetailsId { get; set; }

    public int? VegetableId { get; set; }

    public int? Price { get; set; }

    public virtual LoginDetail? LoginDetails { get; set; }

    public virtual Vegetable? Vegetable { get; set; }
}
