using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TableInvoice.Models
{
    //clas for calculate value of collection Product
    public class LinqValueCalculator : IValueCalculator
    {
        private IDiscountHelper discounter;
        private static int counter = 0;

        public LinqValueCalculator(IDiscountHelper discountParam)
        {
            discounter = discountParam;
            //printing counter of objects instance in VS console
            System.Diagnostics.Debug.WriteLine(string.Format("Created instace no {0}", ++counter));
        }
        
    
        // Method for sum all value properties "Price" 
        // of all objects Product transfered to method
        // with using lambda expressions
        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return discounter.ApplyDiscount(products.Sum(p => p.Price));
        }

    }
}