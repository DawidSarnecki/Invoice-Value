using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TableInvoice.Models
{
    public class SumOfTable
    {
        private LinqValueCalculator calc;

        //construct
        public SumOfTable(LinqValueCalculator calcParam)
        {
            calc = calcParam;
        }

        //colection of products
        public IEnumerable<Product> Products { get; set; }

        // return decimal total value of products
        public decimal CalculateProductTotal()
        {
            return calc.ValueProdcuts(Products);
        }

    }

}