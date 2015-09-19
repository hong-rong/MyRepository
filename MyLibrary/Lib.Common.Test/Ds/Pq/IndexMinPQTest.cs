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
            _target.Insert(0, new Distance { V = 0, Dist = 3 });
            _target.Insert(1, new Distance { V = 1, Dist = 2 });
            _target.Insert(2, new Distance { V = 2, Dist = 1 });
        }

        [TestMethod]
        public void Insert_Test()
        {
            Assert.AreEqual(3, _target.Size());
            Assert.AreEqual(2, _target.MinIndex());
            Assert.AreEqual(1, _target.Min().Dist);
        }

        [TestMethod]
        public void ChangeKey_Test()
        {
            _target.ChangeKey(1, new Distance { V = 1, Dist = 0 });
            Assert.AreEqual(1, _target.MinIndex());
            Assert.AreEqual(0, _target.Min().Dist);
        }

        [TestMethod]
        public void DeleteMin_Test()
        {
            var index = _target.DelMin();
            Assert.AreEqual(2, index);
            Assert.AreEqual(2, _target.Size());
            Assert.AreEqual(1, _target.MinIndex());
            Assert.AreEqual(2, _target.Min().Dist);
        }

        [TestMethod]
        public void Delete_Test()
        {
            _target.Delete(1);
            Assert.AreEqual(2, _target.Size());
            Assert.AreEqual(2, _target.MinIndex());
            Assert.AreEqual(1, _target.Min().Dist);
        }

        [TestMethod]
        public void Min_Test()
        {
            var tKey = _target.Min();
            Assert.AreEqual(1, tKey.Dist);
        }

        [TestMethod]
        public void MinIndex_Test()
        {
            var index = _target.MinIndex();
            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void Contains_Test()
        {
            Assert.IsTrue(_target.Contains(0));
            Assert.IsFalse(_target.Contains(3));
        }

        [TestMethod]
        public void IsEmpty_Test()
        {
            Assert.IsFalse(_target.IsEmpty());
            _target.DelMin();
            _target.DelMin();
            _target.DelMin();
            Assert.IsTrue(_target.IsEmpty());
        }

        [TestMethod]
        public void Size_Test()
        {
            Assert.AreEqual(3, _target.Size());
        }
    }
}