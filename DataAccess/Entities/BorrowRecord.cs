using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class BorrowRecord
{
    public int RecordId { get; set; }

    public int? BookId { get; set; }

    public int? BorrowerId { get; set; }

    public DateTime? BorrowDate { get; set; }

    public bool? IsReturned { get; set; }

    public virtual Book? Book { get; set; }

    public virtual Borrower? Borrower { get; set; }
}
