using System;
using System.Collections.Generic;

namespace PairTracker.Model
{
    public class SessionPercentageStatisticGenerator : StatisticGenerator<IDictionary<Programmer, Statistic>>
    {
        public IDictionary<Programmer, Statistic> Generate(PairingSession session)
        {
            var totalSecondsInSessionByProgrammer = GetTotalTimeByProgrammer(session);

            return GetPercentageOfSessionByProgrammer(totalSecondsInSessionByProgrammer, session);
        }

        private IDictionary<Programmer, TimeSpan> GetTotalTimeByProgrammer(PairingSession session)
        {
            var totalTimeInSessionByProgrammer = new Dictionary<Programmer, TimeSpan>();
            foreach (var interval in session.Intervals)
            {
                if (totalTimeInSessionByProgrammer.ContainsKey(interval.Programmer))
                    totalTimeInSessionByProgrammer[interval.Programmer] += interval.Length;
                else
                    totalTimeInSessionByProgrammer.Add(interval.Programmer, interval.Length);
            }
            return totalTimeInSessionByProgrammer;
        }

        private IDictionary<Programmer, Statistic> GetPercentageOfSessionByProgrammer(IDictionary<Programmer, TimeSpan> totalSecondsInSessionByProgrammer, PairingSession session)
        {
            var percentageOfSessionByProgrammer = new Dictionary<Programmer, Statistic>();

            //TODO: Clean this up
            TimeSpan timeControlledByNeither = new TimeSpan();
            totalSecondsInSessionByProgrammer.TryGetValue(Programmer.Neither, out timeControlledByNeither);

            var totalSecondsControlledByAProgrammer = session.Length - timeControlledByNeither;
            foreach (var item in totalSecondsInSessionByProgrammer)
                if (item.Key != Programmer.Neither)
                {
                    int percentage =  (int)Math.Round((double)100 * (item.Value.TotalSeconds / totalSecondsControlledByAProgrammer.TotalSeconds));
                    Statistic statistic = new Statistic(percentage, item.Value);
                    percentageOfSessionByProgrammer.Add(item.Key, statistic);
                }

            return percentageOfSessionByProgrammer;
        }
    }
}