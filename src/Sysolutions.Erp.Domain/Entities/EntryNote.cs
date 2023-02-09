using System.Collections.Generic;

namespace Sysolutions.Erp.Domain.Entities
{
    public class EntryNote : RequestQueries
    {
        public int EntryNoteId { get; set; }
        public string Correlative { get; set; }
        public string State { get; set; }
        public decimal CostPriceTotal { get; set; }
        public int RegistrationAccountId { get; set; }
        public IEnumerable<EntryNoteDetail> EntryDetails { get; set; }
    }
}
