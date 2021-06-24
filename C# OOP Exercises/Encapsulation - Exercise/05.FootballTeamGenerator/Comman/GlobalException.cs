using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator.Comman
{
    public static class GlobalException
    {
        public const string InvalidTypeOfStatsExceptionMessage = "{0} should be between {1} and {2}.";

        public const string InvalidTeamNameExceptionMessage = "A name should not be empty.";

        public const string RemovingMessingPlayerExceptionMessage = "Player {0} is not in {1} team.";

        public const string MissingTeamExceptionMessage = "Team {0} does not exist.";
    }
}
