using System;
using System.Collections.Generic;

namespace works.Models;

public partial class LoginDetail
{
    public int Id { get; set; }

    public string? LoginEmail { get; set; }

    public string? LoginPassWord { get; set; }

    public virtual ICollection<CustomerDetail> CustomerDetails { get; set; } = new List<CustomerDetail>();
}
