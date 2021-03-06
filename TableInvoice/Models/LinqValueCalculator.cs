﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TableInvoice.Models
{
    //clas for calculate value of collection Product
    public class LinqValueCalculator
    {
        // method for sum all value properties "Price" 
        // of all objects Product transered to method
        // with using lambda expressions
        public decimal ValueProdcuts(IEnumerable<Product> products)
        {
            return products.Sum(p => p.Price);
        }

    }
}