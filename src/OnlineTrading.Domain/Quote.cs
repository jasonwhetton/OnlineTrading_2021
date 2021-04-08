using System;

namespace OnlineTrading.Domain
{
    public class Quote
    {
        public string Id { get; set; }
        public string Ticker { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string QuoteId { get; set; }
    }
}