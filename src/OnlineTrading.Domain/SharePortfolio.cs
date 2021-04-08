using System.Linq;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;

namespace OnlineTrading.Domain
{
    public class SharePortfolio
    {
        private List<Share> shares = new List<Share>();
        public ReadOnlyCollection<Share> Shares => shares.AsReadOnly();

        public void AddShares(IEnumerable<Share> sharesToAdd) {
            shares.AddRange(sharesToAdd);
        }

        public void DoubleAllSharePrices() {
            foreach (var share in shares) {
                share.UnitPrice = share.UnitPrice * 2;
            }
        }

        public bool QualifiesForGoldClub()
        {
            var total = shares.Sum(s => s.UnitPrice * s.Quantity);

            return total > 50;
        }
        
        public Share GetTotalQuanityOfShares()
        {
            var firstShare = shares.OrderBy(s => s.Ticker).FirstOrDefault();

            return firstShare;
        }
    }
}