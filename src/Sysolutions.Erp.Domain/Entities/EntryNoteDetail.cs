namespace Sysolutions.Erp.Domain.Entities
{
    public class EntryNoteDetail
    {
        public int Quantity { get; set; }
        public decimal CostPrice { get; set; }
        public int ProductId { get; set; }
        public int EntryNoteId { get; set; }
        public int ProductPresentationId { get; set; }
    }
}
