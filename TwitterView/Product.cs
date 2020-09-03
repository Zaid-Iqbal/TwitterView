using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterView
{
    class Product
    {
        public static List<Product> products = new List<Product>();

        public String Name
        {
            get;
            set;
        }
        public int Price
        {
            get;
            set;
        }
        public int Xprice
        {
            get;
            set;
        }
        public int Dif
        {
            get;
            set;
        }

        public String ID
        {
            get;
            set;
        }
        public int CatID
        {
            get;
            set;
        }
        public String Category
        {
            get;
            set;
        }

        public List<String> Hashes
        {
            get;
            set;
        }


        public Product(String name, int price, int xprice, String id, int catID, List<String> tags)
        {
            Name = name;
            Price = price;
            Xprice = xprice;
            Dif = price - xprice;
            ID = id;
            CatID = catID;
            Category = Formatting.CatIDtoCategory(catID);
            Hashes = tags;
        }

    }
}
