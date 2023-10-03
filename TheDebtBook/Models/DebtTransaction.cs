using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDebtBook.Models
{
    public class Transaction
    {
        public int Id { get; set; } // Unique identifier for database purposes
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; } // Enum representing Debit or Credit
    }

    public enum TransactionType
    {
        Debit,
        Credit
    }

}
