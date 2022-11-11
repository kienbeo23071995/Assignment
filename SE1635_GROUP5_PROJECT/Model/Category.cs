using System;
using System.Collections.Generic;

namespace SE1635_GROUP5_PROJECT.Model;

public partial class Category
{
    public int Maloai { get; set; }

    public string Loaisp { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
