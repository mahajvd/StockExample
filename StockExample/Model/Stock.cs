namespace StockExample.Model
{
    public class Stock
    {
        private double _fixedDividend;

        public double FixedDividend
        {
            get
            {
                return _fixedDividend / 100;
            }
            set
            {
                _fixedDividend = value;
            }
        }

        public string Symbol { get; set; }
        public StockType StockType { get; set; }
        public double LastDividend { get; set; }
        public double ParValue { get; set; }
        public double MarketPrice { get; set; }
    }
}
