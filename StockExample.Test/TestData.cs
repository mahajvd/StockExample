using StockExample.Model;
using System;
using System.Collections.Generic;

namespace StockExample.Test
{
    public static class TestData
    {
        public static Stock GetTestCommonStock()
        {
            return new Stock
            {
                Symbol = "TestCommonStock",
                StockType = StockType.Common,
                LastDividend = 2.54,
                ParValue = 100
            };
        }

        public static Stock GetTestPreferredStock()
        {
            return new Stock
            {
                Symbol = "TestPreferredStock",
                StockType = StockType.Preferred,
                LastDividend = 8.5,
                FixedDividend = 3.0,
                ParValue = 100
            };
        }

        public static List<Stock> GetStocksForGeometricMeanCalculations()
        {
            return new List<Stock>
            {
                new Stock {Symbol = "T1", StockType = StockType.Common, MarketPrice = 100},
                new Stock {Symbol = "T2", StockType = StockType.Preferred, MarketPrice = 200}
            };            
        }

        public static List<Stock> GetListOfStocks()
        {
            return new List<Stock>
            {
                new Stock {Symbol = "TEA", StockType = StockType.Common, LastDividend = 0, ParValue = 100},
                new Stock {Symbol = "POP", StockType = StockType.Common, LastDividend = 8, ParValue = 100},
                new Stock {Symbol = "ALE", StockType = StockType.Common, LastDividend = 23, ParValue = 60},
                new Stock {Symbol = "GIN", StockType = StockType.Preferred, LastDividend = 8, FixedDividend = 2, ParValue = 100},
                new Stock {Symbol = "JOE", StockType = StockType.Common, LastDividend = 13, ParValue = 250}
            };
            
        }

        public static List<Trade> GetListOfTrades()
        {
            var trades = new List<Trade>
            {
                new Trade(new Stock {Symbol = "TEA", StockType = StockType.Common, LastDividend = 0, ParValue = 100},100,50),
                new Trade(new Stock {Symbol = "POP", StockType = StockType.Common, LastDividend = 0, ParValue = 100},50,20),

            };

            var timedTrade = new Trade(new Stock { Symbol = "TEA", StockType = StockType.Common, LastDividend = 0, ParValue = 100 }, 50, 20);            
            timedTrade.TradeTimeStamp = DateTime.Now.AddMinutes(-100);
            trades.Add(timedTrade);

            return trades;
        }

        public static Stock GetTeaBuyStockSample()
        {
            return new Stock { Symbol = "TEA", StockType = StockType.Common, LastDividend = 0, ParValue = 100 };
        }


        public static Trade GetBuyTradeQty100Price50WithSymbolTEA()
        {
            return new Trade(
                new Stock { Symbol = "TEA", StockType = StockType.Common, LastDividend = 0, ParValue = 100 }, 100, 50);
        }

        public static Trade GetBuyTradeQty100Price50WithSymbolTEST()
        {
            return new Trade(
                new Stock { Symbol = "TEST", StockType = StockType.Common, LastDividend = 0, ParValue = 100 }, 100, 50);
        }

        public static Trade GetBuyTradeQty50Price10WithSymbolTEA()
        {
            return new Trade(
                new Stock { Symbol = "TEA", StockType = StockType.Common, LastDividend = 0, ParValue = 100 }, 50, 10);
        }

        public static Trade GetTeaSellStockSample()
        {
            return new Trade(
                new Stock { Symbol = "TEA", StockType = StockType.Common, LastDividend = 0, ParValue = 100 }, -50, 200);
        }

        public static Trade GetSellTradeQty50Price200WithSymbolTEA()
        {
            return new Trade(
                new Stock { Symbol = "TEA", StockType = StockType.Common, LastDividend = 0, ParValue = 100 }, -50, 200);
        }

        public static Trade GetSellTradeQty150Price20WithSymbolTEA()
        {
            return new Trade(
                new Stock { Symbol = "TEA", StockType = StockType.Common, LastDividend = 0, ParValue = 100 }, -150, 20);
        }
    }

}
