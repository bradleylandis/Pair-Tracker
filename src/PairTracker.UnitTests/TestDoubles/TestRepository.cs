using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PairTracker.Repository;

namespace PairTracker.UnitTests.TestDoubles
{
    public class TestRepository<T> : Repository<T>
    {
        public void Save(T model)
        {
           
        }
    }
}
