using System;
using System.Collections.Generic;

namespace SE1635_GROUP5_PROJECT.Model;

public partial class Product
{
    public int Masp { get; set; }

    public string Tensp { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public decimal Buy { get; set; }

    public string Image { get; set; }

    public int Maloai { get; set; }

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; } = new List<InvoiceDetail>();

    public virtual Category MaloaiNavigation { get; set; }
}
