using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sysolutions.Erp.Application.Services.Products.Commands.AddProductCommand
{
    public class AddProductRequest
    {
        public int ProductPresentationId { get; set; }
        public int EquivalentQuantity { get; set; }
        public decimal Price { get; set; }
        public string BarCode { get; set; }
        public int MeasureFromId { get; set; }
        public int MeasureToId { get; set; }
        public int ProductId { get; set; }

        public string EquivalentFrom { get; set; }
        public string EquivalentTo { get; set; }
    }
}
