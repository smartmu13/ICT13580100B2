using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICT13580100B2.models;

namespace ICT13580100B2.Helpers
{
    public class dbHelpers
    {
        SQLiteConnection db;
        public dbHelpers(String dbPath)
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Product>();
        }
        public int AppProduct(Product product)
        {
             db.Insert(product);
            return product.Id;
        }

        public List<Product> GetProducts()
        {
            return db.Table<Product>().ToList();
        }
        public int UpdateProduct(Product product)
        {
            return db.Update(product);
        }
        public int DeleteProduct(Product product)
        {
            return db.Delete(product);
        }
    }
}
