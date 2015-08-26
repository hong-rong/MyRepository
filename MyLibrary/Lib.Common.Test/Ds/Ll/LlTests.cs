using Lib.Common.Ds.Ll;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lib.Common.Test.Ds.Ll
{
    [TestClass]
    public class LlTests : LlTestBase
    {
        protected override LinkedList<int> CreateLinkedList()
        {
            var first = CreateNodeHeader();

            return new LinkedList<int>(first);
        }

        protected override LinkedList<int> CreateEmptyLinkedList()
        {
            return new LinkedList<int>();
        }
    }
}