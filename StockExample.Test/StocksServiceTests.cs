using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockExample.Model;
using StockExample.Services;

namespace StockExample.Test
{
    [TestClass]
    public class StocksServiceTests
    {
              
        [TestMethod]
        public void CalculateGBCEAllShareIndexTest()
        {
            var stocks = TestData.GetStocksForGeometricMeanCalculations();
            StocksService stockService = new StocksService(stocks);
            const int marketPriceOne = 100;
            const int marketPriceTwo = 200;
            
            double expectedValue = marketPriceOne * marketPriceTwo;
            expectedValue = Math.Pow(expectedValue, 1.0 / 2);

            var actualValue = stockService.CalculateGBCEAllShareIndex();

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void CalculateGBCEAllShareIndexZeroTest()
        {
            var stocks = new List<Stock>();
            StocksService stockService = new StocksService(stocks);
            const int expected = 0;
            var actual = stockService.CalculateGBCEAllShareIndex();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetDividendYieldForCommonStockTest()
        {
            var stock = TestData.GetTestCommonStock();
            var stockService = new StocksService();
            const double marketPrice = 100;
            const double lastDividend = 2.54;

            const double expectedValue = lastDividend / marketPrice;
            var actualValue = stockService.GetDividendYield(stock, marketPrice);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void GetDividendYieldForPreferredStockTest()
        {
            var stockService = new StocksService();

            var stock = TestData.GetTestPreferredStock();
            const double marketPrice = 313;
            const double fixedDividend = 0.03;
            const double parValue = 100;

            const double expectedValue = (fixedDividend * parValue) / marketPrice;

            var actualValue = stockService.GetDividendYield(stock, marketPrice);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ZeroLastDividendCalculatePERatioReturnNullTest()
        {
            var stock = TestData.GetTestCommonStock();
            stock.LastDividend = 0;
            var stockService = new StocksService();
            const double marketPrice = 100;
            double? expected = null;

            var actual = stockService.GetPERatio(stock, marketPrice);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPERatioTest()
        {
            var stock = TestData.GetTestCommonStock();
            var stockService = new StocksService();
            const double marketPrice = 989;
            const double lastDividend = 2.54;

            const double expectedValue = marketPrice / lastDividend;

            
            var actualValue = stockService.GetPERatio(stock, marketPrice);

            Assert.AreEqual(expectedValue, actualValue);
        }
    }

}
