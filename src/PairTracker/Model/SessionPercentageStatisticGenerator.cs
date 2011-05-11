using System.Collections.Generic;
using System;

namespace PairTracker.Model
{
    public class SessionPercentageStatisticGenerator : StatisticGenerator<IDictionary<Programmer, int>>
    {
        public IDictionary<Programmer, int> Generate(Session session)
        {
            var totalSecondsInSessionByProgrammer = GetTotalSecondsByProgrammer(session);

            return GetPercentageOfSessionByProgrammer(totalSecondsInSessionByProgrammer, session);
        }

        private IDictionary<Programmer, TimeSpan> GetTotalSecondsByProgrammer(Session session)
        {
            var totalSecondsInSessionByProgrammer = new Dictionary<Programmer, TimeSpan>();
            foreach (var interval in session.Intervals)
            {
                if (totalSecondsInSessionByProgrammer.ContainsKey(interval.Programmer))
                    totalSecondsInSessionByProgrammer[interval.Programmer] += interval.Length;
                else
                    totalSecondsInSessionByProgrammer.Add(interval.Programmer, interval.Length);
            }
            return totalSecondsInSessionByProgrammer;
        }

        private IDictionary<Programmer, int> GetPercentageOfSessionByProgrammer(IDictionary<Programmer, TimeSpan> totalSecondsInSessionByProgrammer, Session session)
        {
            var percentageOfSessionByProgrammer = new Dictionary<Programmer, int>();

            //TODO: Clean this up
            TimeSpan timeControlledByNeither = new TimeSpan();
            totalSecondsInSessionByProgrammer.TryGetValue(Programmer.Neither, out timeControlledByNeither);

            var totalSecondsControlledByAProgrammer = session.Length - timeControlledByNeither;
            foreach (var item in totalSecondsInSessionByProgrammer)
                if(item.Key != Programmer.Neither)
                    percentageOfSessionByProgrammer.Add(item.Key, (int)((double)100 * (item.Value.TotalSeconds / totalSecondsControlledByAProgrammer.TotalSeconds)));

            return percentageOfSessionByProgrammer;
        }
    }
}
