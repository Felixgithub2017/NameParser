﻿using System.Text.RegularExpressions;
using static BinaryFog.NameParser.RegexNameComponents;

namespace BinaryFog.NameParser.Patterns
{
    internal class FirstInitialLastPattern : IPattern
    {
        private static readonly Regex Rx = new Regex(
            @"^" + First + Space + Initial + Space + Last + @"$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public ParsedName Parse(string rawName)
        {
            var match = Rx.Match(rawName);
            if (!match.Success) return null;
            var pn = new ParsedName(this.GetType().Name)
            {
                FirstName = match.Groups["first"].Value,
                MiddleName = match.Groups["initial"].Value.Replace(".", string.Empty),
                LastName = match.Groups["last"].Value,
                DisplayName = $"{match.Groups["first"].Value} {match.Groups["last"].Value}",
                Score =100
            };
            return pn;
        }
    }
}
