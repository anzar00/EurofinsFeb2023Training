using AiRecommendationEngine.CoreRecommender;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Recommender.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        IRecommender recommender;
        [TestInitialize]

        public void TestInitialize()
        {
            recommender = new PearsonCorrelation();
        }

        [TestMethod]
        public void GetCorrelation_BothListsHaveSameLength_ReturnsValidCorrelation()
        {
            // Arrange
            var baseData = new List<int>() { 1, 2, 3, 4, 5 };
            var otherData = new List<int>() { 5, 4, 3, 2, 1 };
            var expectedCorrelation = -1.0;

            // Act
            var correlation = recommender.GetCorrelation(baseData, otherData);

            // Assert
            Assert.AreEqual(expectedCorrelation, correlation);
        }

        [TestMethod]
        public void GetCorrelation_OtherListIsSmaller_Adds1ForRemainingElementsInOtherList()
        {
            // Arrange
            var baseData = new List<int>() { 1, 2, 3, 4, 5 };
            var otherData = new List<int>() { 5, 4 };
            var expectedCorrelation = -0.8922;

            // Act
            var correlation = recommender.GetCorrelation(baseData, otherData);

            // Assert
            Assert.AreEqual(expectedCorrelation, correlation, 0.0001);
        }

        [TestMethod]
        public void GetCorrelation_OtherListIsLarger_TrimOtherListWithSizeOfBaseList()
        {
            // Arrange
            var baseData = new List<int>() { 1, 2, 3, 4, 5 };
            var otherData = new List<int>() { 5, 4, 3, 2, 1, 0 };
            var expectedCorrelation = -1.0;

            // Act
            var correlation = recommender.GetCorrelation(baseData, otherData);

            // Assert
            Assert.AreEqual(expectedCorrelation, correlation);
        }

        [TestMethod]
        public void GetCorrelation_BaseDataContainsZero_Adds1ToBothCorrespondingElements()
        {
            // Arrange
            var baseData = new List<int>() { 1, 2, 3, 0, 5 };
            var otherData = new List<int>() { 5, 4, 3, 2, 1 };
            var expectedCorrelation = -0.8461;

            // Act
            var correlation = recommender.GetCorrelation(baseData, otherData);

            // Assert
            Assert.AreEqual(expectedCorrelation, correlation, 0.0001);
        }

        [TestMethod]
        public void GetCorrelation_OtherDataContainsZero_Adds1ToBothCorrespondingElements()
        {
            // Arrange
            var baseData = new List<int>() { 1, 2, 3, 4, 5 };
            var otherData = new List<int>() { 5, 4, 0, 2, 1 };
            var expectedCorrelation = -0.9715;

            // Act
            var correlation = recommender.GetCorrelation(baseData, otherData);

            // Assert
            Assert.AreEqual(expectedCorrelation, correlation, 0.0001);
        }
    }
}


