using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;
namespace demo.unitests
{
    [TestClass]
    public class ShapeTests
    {
        theShapes s1, s2;

        [TestInitialize]
        public void TestInit()
        {
            s1 = new theShapes(1, 2);
            s2 = new theShapes(0, 0);
        }
        [TestMethod]
        public void TestAreaIsCorrect()
        {
            //Arrange
            
            double actual;
            double expect = 2.0;

            //act
            actual = s1.Area();
            //assert
            Assert.AreEqual(expect, actual);
           // Assert.AreNotEqual(expect, actual);
        }
        [TestMethod]
        [TestCategory("exceptions")]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestAreaThrowsException()
        {
            double actual;
            double expect = 2.0;

            actual = s2.Area();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            s1 = s2 = null;
        }
    }
}
