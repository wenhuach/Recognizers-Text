﻿using System.Text.RegularExpressions;
using Microsoft.Recognizers.Text.DateTime.Utilities;

namespace Microsoft.Recognizers.Text.DateTime
{
    public interface IDateTimeExtractorConfiguration
    {
        Regex NowRegex { get; }

        Regex SuffixRegex { get; }

        Regex TimeOfTodayAfterRegex { get; }

        Regex SimpleTimeOfTodayAfterRegex { get; }

        Regex TimeOfTodayBeforeRegex { get; }

        Regex SimpleTimeOfTodayBeforeRegex { get; }

        Regex NightRegex { get; }

        Regex TheEndOfRegex { get; }

        Regex UnitRegex { get; }

        IExtractor DurationExtractor { get; }

        IExtractor DatePointExtractor { get; }

        IExtractor TimePointExtractor { get; }

        bool IsConnector(string text);

        IDateTimeUtilityConfiguration UtilityConfiguration { get; }
    }
}