using System;
using System.Collections.Generic;

namespace SE1635_GROUP5_PROJECT.Model;

public partial class Invoice
{
    public int Mahd { get; set; }

    public string Manv { get; set; }

    public DateTime Ngayban { get; set; }

    public int Makh { get; set; }

    public decimal Tongtien { get; set; }

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; } = new List<InvoiceDetail>();

    public virtual Customer MakhNavigation { get; set; }

    public virtual Account ManvNavigation { get; set; }
}
