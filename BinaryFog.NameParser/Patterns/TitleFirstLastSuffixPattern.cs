﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BinaryFog.NameParser.Patterns
{
    internal class TitleFirstLastSuffixPattern : IPattern
    {
        public ParsedName Parse(string rawName)
        {
            //Title should be Mr or Mr. or Ms or Ms. or Mrs or Mrs.
            //Suffix should be I or II or III or Jr. or Jr or Sr. or Sr
            Match match = Regex.Match(rawName, @"^(?<title>(mr|mr\W?|ms|ms\W?|mrs|mrs\W?)) (?<first>\w+) (?<last>\w+) (?<suffix>(i|ii|iii|jr|jr\W?|sr|sr\W?\W?))$", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                ParsedName pn = new ParsedName()
                {
                    Title = match.Groups["title"].Value,
                    FirstName = match.Groups["first"].Value,
                    LastName = match.Groups["last"].Value,
                    DisplayName = String.Format("{0} {1}", match.Groups["first"].Value, match.Groups["last"].Value),
                    Suffix = match.Groups["suffix"].Value,
                    Score = 100
                };
                return pn;
            }

            return null;
        }
    }
}
