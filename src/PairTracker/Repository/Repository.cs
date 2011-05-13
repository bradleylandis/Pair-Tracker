using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PairTracker.Repository
{
    public interface Repository<T>
    {
        void Save(T model);
    }
}
