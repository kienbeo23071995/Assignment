using System;
using System.Collections.Generic;

namespace SE1635_GROUP5_PROJECT.Model;

public partial class Customer
{
    public int Makh { get; set; }

    public string Tenkh { get; set; }

    public string Diachi { get; set; }

    public string DienThoai { get; set; }

    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();
}
