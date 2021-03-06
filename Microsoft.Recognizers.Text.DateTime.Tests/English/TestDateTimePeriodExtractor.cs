﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.Recognizers.Text.DateTime.English.Tests
{
    [TestClass]
    public class TestDateTimePeriodExtractor
    {
        private readonly IExtractor extractor = new BaseDateTimePeriodExtractor(new EnglishDateTimePeriodExtractorConfiguration());

        public void BasicTest(string text, int start, int length)
        {
            var results = extractor.Extract(text);
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(start, results[0].Start);
            Assert.AreEqual(length, results[0].Length);
            Assert.AreEqual(Constants.SYS_DATETIME_DATETIMEPERIOD, results[0].Type);
        }

        [TestMethod]
        public void TestDateTimePeriodExtract()
        {
            // basic match
            BasicTest("I'll be out five to seven today", 12, 19);
            BasicTest("I'll be out five to seven of tomorrow", 12, 25);
            BasicTest("I'll be out from 5 to 6 next sunday", 12, 23);
            BasicTest("I'll be out from 5 to 6pm next sunday", 12, 25);

            // merge to time points 49);

            BasicTest("I'll be out from 4pm to 5pm today", 12, 21);
            BasicTest("I'll be out from 4pm today to 5pm tomorrow", 12, 30);
            BasicTest("I'll be out from 4pm to 5pm of tomorrow", 12, 27);
            BasicTest("I'll be out from 4pm to 5pm of 2017-6-6", 12, 27);
            BasicTest("I'll be out from 4pm to 5pm May 5, 2018", 12, 27);
            BasicTest("I'll be out from 4:00 to 5pm May 5, 2018", 12, 28);
            BasicTest("I'll be out from 4pm on Jan 1, 2016 to 5pm today", 12, 36);
            BasicTest("I'll be out from 2:00pm, 2016-2-21 to 3:32, 04/23/2016", 12, 42);
            BasicTest("I'll be out from today at 4 to next Wedn at 5", 12, 33);

            BasicTest("I'll be out between 4pm and 5pm today", 12, 25);
            BasicTest("I'll be out between 4pm on Jan 1, 2016 and 5pm today", 12, 40);

            BasicTest("I'll go back tonight", 13, 7);
            BasicTest("I'll go back this night", 13, 10);
            BasicTest("I'll go back this evening", 13, 12);
            BasicTest("I'll go back this morning", 13, 12);
            BasicTest("I'll go back this afternoon", 13, 14);
            BasicTest("I'll go back next night", 13, 10);
            BasicTest("I'll go back last night", 13, 10);
            BasicTest("I'll go back tomorrow night", 13, 14);
            BasicTest("I'll go back next monday afternoon", 13, 21);
            BasicTest("I'll go back May 5th night", 13, 13);

            BasicTest("I'll go back last 3 minute", 13, 13);
            BasicTest("I'll go back past 3 minute", 13, 13);
            BasicTest("I'll go back previous 3 minute", 13, 17);
            BasicTest("I'll go back previous 3mins", 13, 14);
            BasicTest("I'll go back next 5 hrs", 13, 10);
            BasicTest("I'll go back last minute", 13, 11);
            BasicTest("I'll go back next hour", 13, 9);
        }
    }
}