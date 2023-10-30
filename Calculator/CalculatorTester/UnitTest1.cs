using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Calculator;

namespace CalculatorTester
{
    [TestClass]
    public class UnitTest1
    {
        private Calculation c;
        [TestInitialize]// thiet lap du lieu dung chung cho TC
        public void SetUp()
        {
            c = new Calculation(10, 5);
        }
        [TestMethod]//TC1: a =10, b = 5, kq= 15

        public void Test_Cong()
        {
            int expected, actual;
            // Caculation c = new Caculation(a,b);
            expected = 15;
            actual = c.Execute("+");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]//TC2: a =10, b = 5, kq= 5
        public void Test_Tru()
        {
            int expected, actual;
            expected = 5;
            actual = c.Execute("-");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]//TC3: a =10, b = 5, kq= 50
        public void Test_Nhan()
        {
            int expected, actual;
            expected = 10;
            actual = c.Execute("*");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]//TC4: a =10, b = 5, kq= 2, Fail do e != a
        public void Test_Chia()
        {
            int expected, actual;
            expected = 10;
            actual = c.Execute("/");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]//TC5: a =10, b = 0, kq=Khong chia duoc 
        [ExpectedException(typeof(DivideByZeroException))]
        public void Test_ChiaZero()
        {
            c = new Calculation(10, 0);
            c.Execute("/");
        }
    }
}
