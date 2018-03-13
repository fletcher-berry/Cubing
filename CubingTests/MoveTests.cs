using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cubing;

namespace CubingTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CorrectByteFromString()
        {
            byte b = new Move("R").ToByte();
            Assert.AreEqual(0, b);
        }

        [TestMethod]
        public void CorrectByteFromStringWith180Degree()
        {
            Move m = new Move("R2");
            byte b = m.ToByte();
            Assert.AreEqual(1, b);
        }

        [TestMethod]
        public void CorrectByteFromStringCounterClockwise()
        {
            byte b = new Move("F'").ToByte();
            Assert.AreEqual(18, b);
        }

        [TestMethod]
        public void CorrectByteFromStringSliceMove()
        {
            byte b = new Move("M2").ToByte();
            Assert.AreEqual(97, b);
        }
    }
}
