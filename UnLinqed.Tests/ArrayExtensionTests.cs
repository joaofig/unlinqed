using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnLinqed;

namespace UnLinqed.Tests
{
    [TestClass]
    public class ArrayExtensionTests
    {
        [TestMethod]
        public void SkipAndTake_Splices_Start_Succeeds()
        {
            int[] test      = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] first3    = test.SkipAndTake(0, 3);

            Assert.AreEqual(test[0], first3[0]);
            Assert.AreEqual(test[1], first3[1]);
            Assert.AreEqual(test[2], first3[2]);
        }

        [TestMethod]
        public void SkipAndTake_Splices_Middle_Succeeds()
        {
            int[] test = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] mid3 = test.SkipAndTake(3, 3);

            Assert.AreEqual(test[3], mid3[0]);
            Assert.AreEqual(test[4], mid3[1]);
            Assert.AreEqual(test[5], mid3[2]);
        }

        [TestMethod]
        public void SkipAndTake_Splices_End_Succeeds()
        {
            int[] test = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] mid3 = test.SkipAndTake(7, 3);

            Assert.AreEqual(test[7], mid3[0]);
            Assert.AreEqual(test[8], mid3[1]);
            Assert.AreEqual(test[9], mid3[2]);
        }

        [TestMethod]
        public void SkipAndTake_Splices_OverflowEnd_Succeeds()
        {
            int[] test = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] end2 = test.SkipAndTake(8, 3);

            Assert.AreEqual(test[8], end2[0]);
            Assert.AreEqual(test[9], end2[1]);
        }

        [TestMethod]
        public void RemoveNulls_Removes_Start_Succeeds()
        {
            string[] array = new string[] { null, "1", "2" };
            string[] test = array.RemoveNulls();

            Assert.AreEqual(array[1], test[0]);
            Assert.AreEqual(array[2], test[1]);
            Assert.AreEqual(test.Length, 2);
        }

        [TestMethod]
        public void RemoveNulls_Removes_Middle_Succeeds()
        {
            string[] array = new string[] { "0", null, "2" };
            string[] test = array.RemoveNulls();

            Assert.AreEqual(array[0], test[0]);
            Assert.AreEqual(array[2], test[1]);
            Assert.AreEqual(test.Length, 2);
        }

        [TestMethod]
        public void RemoveNulls_Removes_End_Succeeds()
        {
            string[] array = new string[] { "0", "1", null };
            string[] test = array.RemoveNulls();

            Assert.AreEqual(array[0], test[0]);
            Assert.AreEqual(array[1], test[1]);
            Assert.AreEqual(test.Length, 2);
        }
    }
}
