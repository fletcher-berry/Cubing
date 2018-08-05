using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cubing;

namespace CubingTests
{
    [TestClass]
    public class RecognitionTests
    {
        [TestMethod]
        public void PllTests()
        {
            OneLookLLCube cube = new OneLookLLCube();
            for(int k = 0; k < 72; k++)
            {
                cube.Solve();
                cube.SetUpPll(k);
                int pllNum = cube.GetPllNum();
                Assert.AreEqual(k, pllNum, "failed on position " + k);
            }
        }

        [TestMethod]
        public void OneLookTests()
        {
            OneLookLLCube cube = new OneLookLLCube();
            for (int k = 0; k < cube.GetNumPositions(); k++)
            {
                cube.Solve();
                cube.SetUpPosition(k);
                if(!((k >= 460 && k < 480) || (k >= 940 && k < 980)))
                    cube.RandomUMove();
                int posNum = cube.GetPosNum();
                Assert.AreEqual(k, posNum, "failed on position " + k);
            }
        }

        [TestMethod]
        public void ZbllTests()
        {
            OneLookLLCube cube = new OneLookLLCube();
            for (int k = 0; k < 480; k++)
            {
                cube.Solve();
                cube.SetUpPosition(k);
                cube.Ui();
                int posNum = cube.GetPosNum();
                Assert.AreEqual(k, posNum, "failed on position " + k);
            }
        }

        [TestMethod]
        public void DotTests()
        {
            OneLookLLCube cube = new OneLookLLCube();
            for (int k = 480; k < 960; k++)
            {
                cube.Solve();
                cube.SetUpPosition(k);
                cube.Ui();
                int posNum = cube.GetPosNum();
                Assert.AreEqual(k, posNum, "failed on position " + k);
            }
        }

        [TestMethod]
        public void TwoEdgeTests()
        {
            OneLookLLCube cube = new OneLookLLCube();
            for (int k = 960; k < 3552; k++)
            {
                cube.Solve();
                cube.SetUpPosition(k);
                cube.RandomUMove();
                int posNum = cube.GetPosNum();
                Assert.AreEqual(k, posNum, "failed on position " + k);
            }
        }

        [TestMethod]
        public void HCaseTests()
        {
            OneLookLLCube cube = new OneLookLLCube();
            for (int k = 3552; k < 3776; k++)
            {
                cube.Solve();
                cube.SetUpPosition(k);
                //cube.RandomUMove();
                int posNum = cube.GetPosNum();
                Assert.AreEqual(k, posNum, "failed on position " + k);
            }
        }

        [TestMethod]
        public void EllcpTests()
        {
            OneLookLLCube cube = new OneLookLLCube();
            for (int k = 3776; k < cube.GetNumPositions(); k++)
            {
                cube.Solve();
                cube.SetUpPosition(k);
                cube.RandomUMove();
                int posNum = cube.GetPosNum();
                Assert.AreEqual(k, posNum, "failed on position " + k);
            }
        }

        [TestMethod]
        public void Sample()
        {
            OneLookLLCube cube = new OneLookLLCube();
            cube.Solve();
            cube.SetUpPosition(3776);
            int posNum = cube.GetPosNum();
            Assert.AreEqual(3776, posNum, "failed no auf");
            cube.Solve();
            cube.SetUpPosition(3776);
            cube.U();
            posNum = cube.GetPosNum();
            Assert.AreEqual(3776, posNum, "failed U");
            cube.Solve();
            cube.SetUpPosition(3776);
            cube.U2();
            posNum = cube.GetPosNum();
            Assert.AreEqual(3776, posNum, "failed U2");
            cube.Solve();
            cube.SetUpPosition(3776);
            cube.Ui();
            posNum = cube.GetPosNum();
            Assert.AreEqual(3776, posNum, "failed U'");
        }

        [TestMethod]
        public void CornerOrientationTests()
        {
            int num;
            OneLookLLCube cube = new OneLookLLCube();
            for (int k = 0; k < 480; k+= 24)
            {
                cube.Solve();
                cube.SetUpPosition(k);
                cube.RandomUMove();
                num = cube.GetCornerOrientationNum();
                Assert.AreEqual(k / 72, num, "failed on position " + k);
            }
            cube.Solve();
            cube.HOrientation();
            num = cube.GetCornerOrientationNum();
            Assert.AreEqual(6, num, "failed on h orientation");
            cube.U();
            num = cube.GetCornerOrientationNum();
            Assert.AreEqual(6, num, "failed on h orientation");
            cube.Solve();
            num = cube.GetCornerOrientationNum();
            Assert.AreEqual(7, num, "failed with corners oriented");
        }

        [TestMethod]
        public void EdgeOrientationTests()
        {
            OneLookLLCube cube = new OneLookLLCube();
            for (int k = 0; k < 36; k ++)
            {
                int posNum = 72 * k + 960;
                cube.Solve();
                cube.SetUpPosition(posNum);
                cube.RandomUMove();
                cube.AufToDefault();
                int num = cube.GetEdgeOrientationNum();
                Assert.AreEqual(k % 6, num, "failed on position " + k);
            }
        }

        [TestMethod]
        public void OrientTests()
        {
            OneLookLLCube cube = new OneLookLLCube();
            for (int k = 0; k < 30; k++)
            {
                cube.Solve();
                cube.SetUpPosition(72 * k + 960);
                cube.AufToDefault();
                cube.Orient();
                int num = cube.GetPllNum();
                Assert.AreEqual(0, num, "failed on position " + 72 * k + 960);
            }
        }

        [TestMethod]
        public void OllTests()
        {
            OllCube cube = new OllCube();
            for (int k = 0; k < 57; k++)
            {
                cube.Solve();
                cube.SetUpPosition(k);
                cube.AufToDefault();
                int num = cube.GetPosNum();
                Assert.AreEqual(k, num, "failed on position " + k);
            }
        }

        [TestMethod]
        public void OllcpTests()
        {
            OllcpCube cube = new OllcpCube();
            for (int k = 0; k < 329; k++)
            {
                cube.Solve();
                cube.SetUpPosition(k);
                cube.AufToDefault();
                int num = cube.GetPosNum();
                Assert.AreEqual(k, num, "failed on position " + k);
            }
        }

        [TestMethod]
        public void DifferentAngle()
        {
            OneLookLLCube cube = new OneLookLLCube();
            
            cube.Solve();
            cube.SetUpPosition(447);
            cube.U2();
            int num = cube.GetPosNum();
            Assert.AreEqual(447, num);
            
        }






    }
}
