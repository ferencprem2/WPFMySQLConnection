using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppSQLTermekek
{
    public class Products
    {
        string category;
        string manifacturer;
        string name;
        int price;
        int warranty;

        public Products(string category, string manifacturer, string name, int price, int warranty)
        {
            this.category = category;
            this.manifacturer = manifacturer;
            this.name = name;
            this.price = price;
            this.warranty = warranty;
        }

        public static String ToCSVString(Products product)
        {
            return $"{product.category};{product.manifacturer};{product.name};{product.price};{product.warranty}";
        }


        public string Category { get => category; set => category = value; }
        public string Manifacturer { get => manifacturer; set => manifacturer = value; }
        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
        public int Warranty { get => warranty; set => warranty = value; }

    }
}