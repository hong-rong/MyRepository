﻿using Lib.Common.Al.Graph;
using Lib.Common.Ds.Pq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Common.Test.Ds.Pq
{
    [TestClass]
    public class MinPQTest
    {
        private MinPQ<Distance> _target;

        [TestInitialize]
        public void Initialize()
        {
            _target = new MinPQ<Distance>();
        }

        [TestMethod]
        public void Test()
        {
            var d1 = new Distance { V = 0, Dist = 3 };
            var d2 = new Distance { V = 0, Dist = 2 };
            var d3 = new Distance { V = 0, Dist = 1 };

            _target.Insert(d1);
            _target.Insert(d2);
            _target.Insert(d3);

            Assert.AreEqual(d3, _target.DelRoot());
            Assert.AreEqual(d2, _target.DelRoot());
            Assert.AreEqual(d1, _target.DelRoot());
        }
    }
}
