﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return
                $"Name: {Name}; " +
                $" Price: {Price}; " +
                $" Count: {Count}; " +
                $" Country: {Country}; ";

        }
    }
}
