
using System;
using System.Collections.Generic;

namespace Sysolutions.Erp.Domain.Entities
{
    public class SalesOrder : RequestQueries
    {
        public int SalesOrderId { get; set; }
        public string Correlative { get; set; }
        public string Comment { get; set; }
        public decimal Total { get; set; }
        public string StateDescription { get; set; }
        public string State { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegisteredUser { get; set; }
        public int RegistrationAccountId { get; set; }
        public IEnumerable<SalesOrderDetail> Detail { get; set; }
    }
}
