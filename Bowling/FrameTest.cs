using NUnit.Framework;

namespace Frame.Test {
    [TestFixture]
    public class FrameTest {
        private Frame f;

        [SetUp]
        public void SetUp() {
            f = new Frame();
        }

        [Test]
        public void Test() {
            Assert.AreEqual(f.Score, 0);
            f.Add(5);
            Assert.AreEqual(f.Score, 5);
        }
    }
}
