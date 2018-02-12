using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockExample.Services;
using System;

namespace StockExample.Test
{
    [TestClass]
    public class TradesServiceTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Trades cannot be null")]
        public void CheckNullTradeServiceTest()
        {
            new TradesService(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Trade cannot be null")]
        public void CheckNullTradeTest()
        {
            var tradeService = new TradesService();
            tradeService.RecordTrade(null, 0, 0.0);
        }

        [TestMethod]
        public void CheckAddTrades()
        {
            var tradeService = new TradesService();
            var expected = tradeService.Trades.Count + 1;
            tradeService.RecordTrade(TestData.GetTeaBuyStockSample() , 100, 50);

            var actual = tradeService.Trades.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAllTradesInLastFifteenMinutesTest()
        {
            var tradeService = new TradesService(TestData.GetListOfTrades());
            const int expected = 1;
            var tradesLastFifteen = tradeService.GetAllTradesWithinInterval("TEA");

            var actual = tradesLastFifteen.Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateVolumeWeightedStockPriceTest()
        {
            var tradeService = new TradesService();
            tradeService.Trades.Add(TestData.GetBuyTradeQty100Price50WithSymbolTEA());
            tradeService.Trades.Add(TestData.GetBuyTradeQty50Price10WithSymbolTEA());

            const double tradeOnePrice = 50;
            const double tradeOneQty = 100;
            const double tradeOneTotalValue = tradeOneQty * tradeOnePrice;

            const double tradeTwoPrice = 10;
            const double tradeTwoQty = 50;
            const double tradeTwoTotalValue = tradeTwoQty * tradeTwoPrice;

            const double totalValue = tradeOneTotalValue + tradeTwoTotalValue;
            const double totalQty = tradeOneQty + tradeTwoQty;

            const double expected = totalValue / totalQty;

            var actual = tradeService.CalculateVolumeWeightedStockPrice("TEA");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateVolumeWeightedStockPriceTest2()
        {
            var tradeService = new TradesService();
            tradeService.Trades.Add(TestData.GetBuyTradeQty100Price50WithSymbolTEA());
            tradeService.Trades.Add(TestData.GetBuyTradeQty50Price10WithSymbolTEA());
            tradeService.Trades.Add(TestData.GetBuyTradeQty100Price50WithSymbolTEST());

            const double tradeOnePrice = 50;
            const double tradeOneQty = 100;
            const double tradeOneTotalValue = tradeOneQty * tradeOnePrice;

            const double tradeTwoPrice = 10;
            const double tradeTwoQty = 50;
            const double tradeTwoTotalValue = tradeTwoQty * tradeTwoPrice;

            const double totalValue = tradeOneTotalValue + tradeTwoTotalValue;
            const double totalQty = tradeOneQty + tradeTwoQty;

            const double expected = totalValue / totalQty;

            var actual = tradeService.CalculateVolumeWeightedStockPrice("TEA");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CalculateVolumeWeightedStockPriceZeroQuantityTest()
        {
            var tradeService = new TradesService();
            tradeService.Trades.Add(TestData.GetBuyTradeQty50Price10WithSymbolTEA());
            tradeService.Trades.Add(TestData.GetSellTradeQty50Price200WithSymbolTEA());
            const int expected = 0;
            var actual = tradeService.CalculateVolumeWeightedStockPrice("TEA");

            Assert.AreEqual(expected, actual);
        }

    }

}
