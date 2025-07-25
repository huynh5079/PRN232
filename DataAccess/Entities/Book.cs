using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class Book
{
    public int BookId { get; set; }

    public string Title { get; set; } = null!;

    public string? Author { get; set; }

    public string? Genre { get; set; }

    public int? AssignedTo { get; set; }

    public virtual User? AssignedToNavigation { get; set; }

    public virtual ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();
}
