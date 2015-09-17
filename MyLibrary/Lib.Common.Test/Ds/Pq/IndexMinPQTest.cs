using Lib.Common.Al.Graph;
using Lib.Common.Ds.Pq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Common.Test.Ds.Pq
{
    [TestClass]
    public class IndexMinPQTest
    {
        private IndexMinPQ<Distance> _target;

        [TestInitialize]
        public void Initialize()
        {
            _target = new IndexMinPQ<Distance>(5);
        }

        [TestMethod]
        public void Insert_Test()
        {
            _target.Insert(0, new Distance { V = 0, Dist = 3 });
            _target.Insert(1, new Distance { V = 1, Dist = 2 });
            _target.Insert(2, new Distance { V = 2, Dist = 1 });

            Assert.AreEqual(3, _target.Size());
            Assert.AreEqual(2, _target.MinIndex());//wrong
            Assert.AreEqual(1, _target.Min().Dist);
        }

        [TestMethod]
        public void DeleteMin_Test()
        {
            _target.Insert(0, new Distance { V = 0, Dist = 3 });
            _target.Insert(1, new Distance { V = 1, Dist = 2 });
            _target.Insert(2, new Distance { V = 2, Dist = 1 });

            var index = _target.DelMin();
            Assert.AreEqual(3, index);
            Assert.AreEqual(2, _target.Size());
            Assert.AreEqual(1, _target.MinIndex());
            Assert.AreEqual(2, _target.Min().Dist);
        }
    }
}