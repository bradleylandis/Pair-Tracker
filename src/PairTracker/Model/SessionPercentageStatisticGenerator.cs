using System.Collections.Generic;

namespace PairTracker.Model
{
    public class SessionPercentageStatisticGenerator : StatisticGenerator<IDictionary<Programmer, int>>
    {
        public IDictionary<Programmer, int> Generate(Session session)
        {
            var totalSecondsInSessionByProgrammer = GetTotalSecondsByProgrammer(session);

            return GetPercentageOfSessionByProgrammer(totalSecondsInSessionByProgrammer, session);
        }

        private IDictionary<Programmer, double> GetTotalSecondsByProgrammer(Session session)
        {
            var totalSecondsInSessionByProgrammer = new Dictionary<Programmer, double>();
            foreach (var interval in session.Intervals)
            {
                if (totalSecondsInSessionByProgrammer.ContainsKey(interval.Programmer))
                    totalSecondsInSessionByProgrammer[interval.Programmer] += interval.Length.TotalSeconds;
                else
                    totalSecondsInSessionByProgrammer.Add(interval.Programmer, interval.Length.TotalSeconds);
            }
            return totalSecondsInSessionByProgrammer;
        }

        private IDictionary<Programmer, int> GetPercentageOfSessionByProgrammer(IDictionary<Programmer, double> totalSecondsInSessionByProgrammer, Session session)
        {
            var percentageOfSessionByProgrammer = new Dictionary<Programmer, int>();
            foreach (var item in totalSecondsInSessionByProgrammer)
                percentageOfSessionByProgrammer.Add(item.Key, (int)((double)100 * (item.Value / session.Length.TotalSeconds)));

            return percentageOfSessionByProgrammer;
        }
    }
}
