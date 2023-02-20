using System;
using System.Collections.Generic;

namespace Sysolutions.Erp.Application.Services.EntryNotes.Queries.GetEntryNotesByAllQuery
{
    public class GetBaseEntryNoteByAllResponse
    {
        public IEnumerable<GetEntryNotesByAll> EntryNotes { get; set; }
    }

    public class GetEntryNotesByAll
    {
        public int EntryNoteId { get; set; }
        public string Correlative { get; set; }
        public decimal CostPriceTotal { get; set; }
        public string StateDescription { get; set; }
        public string State { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string RegisteredUser { get; set; }
        public IEnumerable<GetEntryNotesDetailByAll> Details { get; set; }
    }

    public class GetEntryNotesDetailByAll
    {
        public int ProductId { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal CostPrice { get; set; }
    }
}
