using System;
using System.Collections.Generic;

namespace Sysolutions.Erp.Application.Services.Sales.Queries.GetSalesOrderByAllQuery
{
    public class GetBaseSalesOrderByAllResponse
    {
        public IEnumerable<GetSalesOrderByAll> SalesOrder { get; set; }

    }

    public class GetSalesOrderByAll
    {
        public int SalesOrderId { get; set; }
        public string Correlative { get; set; }
        public string Comment { get; set; }
        public decimal Total { get; set; }
        public string StateDescription { get; set; }
        public string State { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegisteredUser { get; set; }
        public IEnumerable<GetSalesOrderDetailByAll> Detail { get; set; }
    }

    public class GetSalesOrderDetailByAll
    {
        public int ProductId { get; set; }
        public string Product { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
