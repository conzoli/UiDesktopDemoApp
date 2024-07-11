using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UiDesktopDemoApp.Models
{
    public class Product
    {

        public int ProductId { get; set; }

        public int ProductCode { get; set; }

        public string ProductName { get; set; } = string.Empty;

        public string QuantityPerUnit { get; set; } = string.Empty;

        public double UnitPrice { get; set; }

        public string UnitPriceString => UnitPrice.ToString("F2");

        public int UnitsInStock { get; set; }

        public bool IsVirtual { get; set; }

    }
}
