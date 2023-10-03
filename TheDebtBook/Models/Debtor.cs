using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDebtBook.Models
{
    public class Debtor
    {
        public int Id { get; set; } // Unique identifier for database purposes
        public string Name { get; set; }
        public double TotalAmountOwed { get; set; }
        public ObservableCollection<Transaction> Transactions { get; set; } = new ObservableCollection<Transaction>();
    }

}
