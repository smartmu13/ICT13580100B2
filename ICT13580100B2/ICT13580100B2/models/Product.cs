using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT13580100B2.models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        [MaxLength(200)]
        public String name { get; set; }
        [NotNull]
        [MaxLength(100)]
        public String Description { get; set; }
        public String Category { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal SellPrice { get; set; }
        public int Stock { get; set; }
    }
}
