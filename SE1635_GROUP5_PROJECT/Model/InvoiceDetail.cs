using System;
using System.Collections.Generic;

namespace SE1635_GROUP5_PROJECT.Model;

public partial class InvoiceDetail
{
    public int Mahddt { get; set; }

    public int Mahd { get; set; }

    public int Masp { get; set; }

    public int Soluong { get; set; }

    public decimal Dongia { get; set; }

    public float Giamgia { get; set; }

    public decimal Thanhtien { get; set; }

    public virtual Invoice MahdNavigation { get; set; }

    public virtual Product MaspNavigation { get; set; }
}
