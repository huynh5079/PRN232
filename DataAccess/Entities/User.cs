using DataAccess.Enum;
using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public UserRole Role { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
