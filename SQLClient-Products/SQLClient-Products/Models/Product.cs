using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQLClient_Products.Models
{
    public class Product
    {

        //TODO: fill in the product class. 
        // It should have at least the following properties:
        //     Id, Name, Description, Price, ImageUrl
        public int ProductId
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public decimal Price
        {
            get;
            set;
        }
        public string ImageUrl
        {
            get;
            set;
        }


        public override string ToString()
        {
            return string.Format("Name: {0}, Description: {1}, Price: {2}",
                Name, Description, Price);
        }
    }
}