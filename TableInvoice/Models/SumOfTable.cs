using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TableInvoice.Models
{
    public class SumOfTable
    {

        // using iterface:
        private IValueCalculator calc;

        //construct
        public SumOfTable(IValueCalculator calcParam)
        {
            calc = calcParam;
        }

        //colection of products
        public IEnumerable<Product> Products { get; set; }

        // return decimal total value of products
        public decimal CalculateProductTotal()
        {
            return calc.ValueProducts(Products);
        }

    }

}