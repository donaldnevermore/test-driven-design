using System;
using NUnit.Framework;

namespace MinStack.Test
{
    [TestFixture]
    public class MinStackTest
    {
        [Test]
        public void Test()
        {
            var stack = new MinStack();
            stack.Push(5);
            stack.Push(6);
            stack.Push(4);
            Assert.AreEqual(stack.GetMin(), 4);
        }

        [Test]
        public void TestException()
        {
            var stack = new MinStack();
            Assert.Throws<Exception>(() => { stack.GetMin(); });
        }
    }
}
