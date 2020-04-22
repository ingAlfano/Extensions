using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Extensions;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class SortByTests
    {
        public IEnumerable<DateTime> UnsortedData
        {
            get
            {
                {
                    yield return new DateTime(2020, 01, 01);
                    yield return new DateTime(2019, 01, 01);
                    yield return new DateTime(2021, 01, 01);
                    yield return new DateTime(2020, 02, 01);
                    yield return new DateTime(2019, 02, 01);
                    yield return new DateTime(2021, 02, 01);
                }
            }
        }

        public IEnumerable<DateTime> SortedDataByMonthDayYear
        {
            get
            {
                {
                    yield return new DateTime(2019, 01, 01);
                    yield return new DateTime(2020, 01, 01);
                    yield return new DateTime(2021, 01, 01);
                    yield return new DateTime(2019, 02, 01);
                    yield return new DateTime(2020, 02, 01);
                    yield return new DateTime(2021, 02, 01);
                }
            }
        }

        public IEnumerable<DateTime> SortedDataByYear
        {
            get
            {
                yield return new DateTime(2019, 01, 01);
                yield return new DateTime(2019, 02, 01);
                yield return new DateTime(2020, 01, 01);
                yield return new DateTime(2020, 02, 01);
                yield return new DateTime(2021, 01, 01);
                yield return new DateTime(2021, 02, 01);
            }
        }

        [TestMethod]
        public void SortByShouldSortWithNoException()
        {
            var result = UnsortedData.SortBy(t => t.Month, t => t.Day, t => t.Year);

            Assert.IsTrue(result.SequenceEqual(SortedDataByMonthDayYear));
        }

        [TestMethod]
        public void SortByShouldNotThrowWithNoStatements()
        {
            var result = UnsortedData.SortBy<DateTime, DateTime>();
            Assert.IsTrue(result.SequenceEqual(UnsortedData));
        }

        [TestMethod]
        public void SortByShouldNotThrowWithNullStatements()
        {
            var result = UnsortedData.SortBy(null,null, t => t.Year);
            Assert.IsTrue(result.SequenceEqual(SortedDataByYear));
        }

        [TestMethod]
        public void SortByShouldNotThrowWithOneStatement()
        {
            var result = UnsortedData.SortBy(t => t.Year);
            Assert.IsTrue(result.SequenceEqual(SortedDataByYear));
        }
    }
}