using System;

namespace Sysolutions.Erp.Application.Services.Measures.Queries.GetMeasureByAll
{
    public class GetMeasureByAllResponse
    {
        public int MeasureId { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string State { get; set; }
        public string StateDescription { get; set; }
    }
}
