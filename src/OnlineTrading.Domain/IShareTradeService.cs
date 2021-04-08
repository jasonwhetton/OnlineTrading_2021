namespace OnlineTrading.Domain
{
    public interface ITradingService
    {
        GetQuoteResponse GetQuoteForTicker(string ticker);
        bool BuySharesFromQuote(string quoteId, int quantity);
    }

    public class GetQuoteResponse {
        public bool Success {get;set;}
        public decimal Price {get;set;}
        public string QuoteId {get;set;}
    }
}