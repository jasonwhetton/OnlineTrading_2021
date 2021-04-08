﻿using System;
using System.Linq;

namespace OnlineTrading.Domain
{
    public class TransactionService
    {
        readonly ITradingService shareTradeService;
        readonly QuoteRepositoryFake repository;

        public TransactionService(QuoteRepositoryFake repository, 
                                        ITradingService shareTradeService)
        {
            this.shareTradeService = shareTradeService;
            this.repository = repository;
        }

        public void RequestQuoteFor(string ticker, int quantity, string id)
        {
            var response = this.shareTradeService.GetQuoteForTicker(ticker);

            if (response.Success == false) throw new InvalidOperationException("Failed to retrieve a quote.");

            repository.AddQuote(new Quote {
                Id = id,
                Quantity = quantity,
                UnitPrice = response.Price,
                QuoteId = response.QuoteId
            });
        }

        public void AcceptQuote(string id)
        {
            var reservation = repository.GetById(id);

            if (reservation == null) return;
            
            shareTradeService.BuySharesFromQuote(reservation.QuoteId, reservation.Quantity);
        }
    }
}