using System;
using System.Collections.Generic;

namespace SE1635_GROUP5_PROJECT.Model;

public partial class Account
{
    public string Username { get; set; }

    public string Password { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Address { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public bool IsAdmin { get; set; }

    public bool Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();
}
