using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Calculator;

namespace CalculatorTester
{
    [TestClass]
    public class UnitTest1
    {

        private Calculation c;
        public TestContext TestContext { get; set; }
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
            expected = 50;
            actual = c.Execute("*");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]//TC4: a =10, b = 5, kq= 2, Fail do e != a
        public void Test_Chia()
        {
            int expected, actual;
            expected = 2;
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


        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\Data\TestData.csv", "TestData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestWithDataSource()
        {
            int a = int.Parse(TestContext.DataRow[0].ToString());
            int b = int.Parse(TestContext.DataRow[1].ToString());
            int expected = int.Parse(TestContext.DataRow[2].ToString());

            Calculation c = new Calculation(a, b);
            int actual = c.Execute("+");
            Assert.AreEqual(expected, actual);
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\Data\DataTest_cotToantu.csv", "DataTest_cotToantu#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestWithDataSourceHaveOperator()
        {
            int a = int.Parse(TestContext.DataRow[0].ToString());
            int b = int.Parse(TestContext.DataRow[1].ToString());
            string op = TestContext.DataRow[2].ToString();
            int expected = int.Parse(TestContext.DataRow[3].ToString());

            Calculation c = new Calculation(a, b);
            int actual = c.Execute(op.Replace("'", ""));
            Assert.AreEqual(expected, actual);
        }

        static double Power(double x, int n)
        {
            if (n == 0)
                return 1.0;
            else if (n > 0)
                return n * Power(x, n - 1);
            else
                return Power(x, n + 1) / x;
        }
        [TestMethod]
        public void TestPower()
        {
            int n = 0;
            Assert.AreEqual(Power(1, n), 1);
            n = 3;
            Assert.AreEqual(Power(2, n), 8);
            n = -1;
            Assert.AreEqual(Power(2, n), (0.5));
        }
    }
}
