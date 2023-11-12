using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Calculator;
using System.Collections.Generic;
using static Calculator.TrungTamGiaSu;

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
                return x * Power(x, n - 1);
            else
                return Power(x, n + 1) / x;
        }

        [TestMethod]
        public void TestZero()
        {
            //set x, n
            double x = 2;
            int n = 0;

            //set expected = x^n = 2^0 = 1 
            double expected = 1.0;

            //use Power(2, 0) cal actual
            double actual = Power(x, n);

            //compare expected & actual
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPositive()
        {
            //set x, n
            double x = 2;
            int n = 3;

            //set expected = x^n = 2^3 = 8
            double expected = 8.0;

            //use Power(2, 3) cal actual
            double actual = Power(x, n);

            //compare expected & actual
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNegative()
        {
            //set x, n
            double x = 2;
            int n = -3;

            //set expected = x^n = 2^-3 = 0.125
            double expected = 0.125;

            //use Power(2, -3) cal actual
            double actual = Power(x, n);

            //compare expected & actual
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestZeroBase()
        {
            //set x, n
            double x = 0;
            int n = 3;

            //set expected = x^n = 0^3 = 0
            double expected = 0;

            //use Power(0, 3) cal actual
            double actual = Power(x, n);

            //compare expected & actual
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInfinityBase()
        {
            //set x = ∞, n
            double x = double.PositiveInfinity;
            int n = 3;

            //set expected = x^n = ∞^3 = ∞
            double expected = double.PositiveInfinity;

            //use Power(∞, 3) cal actual
            double actual = Power(x, n);

            //compare expected & actual
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNaNBase()
        {
            //set x = NaN, n
            double x = double.NaN;
            int n = 3;

            //set expected = x^n = NaN^3 = NaN
            double expected = double.NaN;

            //use Power(NaN, 3) cal actual
            double actual = Power(x, n);

            //compare expected & actual
            Assert.AreEqual(expected, actual);
        }

        private Polynomial p;

        [TestMethod]
        public void TestValidConstructor()
        {
            // set n
            int n = 2;
            List<int> a = new List<int>() { 1, 2, 3 }; // 1 + 2x + 3x^2

            p = new Polynomial(n, a);

            // compare n, p.n
            Assert.AreEqual(n, p.getN);
            // compare a, p.a
            Assert.AreEqual(a, p.getA);
        }

        [TestMethod]
        public void TestInvalidConstructor()
        {
            // set n
            int n = 2;
            List<int> a = new List<int>() { 1, 2 }; // Invalid list length

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => new Polynomial(n, a));
        }

        [TestMethod]
        public void TestCal()
        {
            // set n 
            int n = 2;
            // set a
            List<int> a = new List<int>() { 1, 2, 3 }; // 1 + 2x + 3x^2
            Polynomial p = new Polynomial(n, a);
            // set x
            double x = 2;
            //set expected = 17
            int expected = 17; // 1 + 2*2 + 3*2^2

            // use Cal(2) cal actual = 17
            int actual = p.Cal(x);

            // compare expected and actual
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCalZero()
        {
            // set n 
            int n = 2;
            // set a
            List<int> a = new List<int>() { 1, 2, 3 }; // 1 + 2x + 3x^2
            Polynomial p = new Polynomial(n, a);
            // set x
            double x = 0;
            //set expected = 1
            int expected = 1; // 1 + 2*0 + 3*0^2

            // use Cal(0) cal actual = 1
            int actual = p.Cal(x);

            // compare expected and actual
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCalInfinity()
        {
            // set n
            int n = 2;
            // set a
            List<int> a = new List<int>() { 1, 2, 3 }; // 1 + 2x + 3x^2
            Polynomial p = new Polynomial(n, a);
            // set x
            double x = double.PositiveInfinity;
            // set expected
            int expected = 1;

            // x = Infinity => Cal(x) return 1
            int actual = p.Cal(x);

            // compare expected and actual
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCalNaN()
        {
            // set n
            int n = 2;
            // set a
            List<int> a = new List<int>() { 1, 2, 3 }; // 1 + 2x + 3x^2
            Polynomial p = new Polynomial(n, a);
            // set x
            double x = double.NaN;
            // set expected
            int expected = 0; // 1 + 2*NaN + 3*NaN^2

            // x = NaN => Cal(x) return 0
            int actual = p.Cal(x);

            // compare expected and actual
            Assert.AreEqual(expected, actual);
        }

        private Radix r;

        [TestMethod]
        public void TestValidConstructorRadix()
        {
            // set number
            int number = 10;

            // set r 
            r = new Radix(number);

            // compare condition to be true
            Assert.AreEqual(number, r.getNumber);
        }

        [TestMethod]
        public void TestInvalidConstructorRadix()
        {
            // set number
            int number = -10;

            // check exception
            Assert.ThrowsException<ArgumentException>(() => new Radix(number));
        }

        [TestMethod]
        public void TestConvertDecimalToAnother()
        {
            // init number, radix and assign values
            int number = 10;
            int radix = 2;

            //init expected 
            string expected = "1,0,1,0";
            r = new Radix(number);

            // cal actual by using ConvertDecimalToAnother(radix)
            string actual = r.ConvertDecimalToAnother(radix);

            // compare actual with expected
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestConvertDecimalToAnotherInvalidRadix()
        {
            // init number, radix then assign values
            int number = 10;
            int radix = 17;

            r = new Radix(number);

            // check exception 
            Assert.ThrowsException<ArgumentException>(() => r.ConvertDecimalToAnother(radix));
        }

        private Rectangle rec;

        [TestMethod]
        public void TestConstructor()
        {
            // init Point topLeft, bottomRight then assign value
            Point topLeft = new Point(0, 10);
            Point bottomRight = new Point(10, 0);

            rec = new Rectangle(topLeft, bottomRight);

            // check true
            Assert.AreEqual(topLeft, rec.getTopLeft());
            Assert.AreEqual(bottomRight, rec.getBottonRight());
        }

        [TestMethod]
        public void TestArea()
        {
            // init Point topLeft, bottomRight then assign value
            Point topLeft = new Point(0, 10);
            Point bottomRight = new Point(10, 0);

            rec = new Rectangle(topLeft, bottomRight);

            // init expected value of area of rectangle
            int expected = 100;

            // cal actual by using method Area()
            int actual = rec.Area();

            // compare expected with actual
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIntersectsWith()
        {
            // init Point topLeft, bottomRight then assign value
            Point topLeft1 = new Point(0, 0);
            Point bottomRight1 = new Point(10, 10);

            rec = new Rectangle(topLeft1, bottomRight1);

            // init Point topLeft2, bottomRight2 for the second rectangle then assign value
            Point topLeft2 = new Point(5, 5);
            Point bottomRight2 = new Point(15, 15);

            Rectangle r2 = new Rectangle(topLeft2, bottomRight2);

            // init result to check Intersect 
            bool result = rec.IntersectsWith(r2);

            // check intersect
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void TestLayDanhSachHocVienDuDieuKienNhanHocBong()
        {
            // Tạo một đối tượng QuanLyHocVien
            QuanLyHocVien qlhv = new QuanLyHocVien("ABC");

            // Tạo một số đối tượng HocVien
            HocVien hv1 = new HocVien()
            {
                MaSo = "HV001",
                HoTen = "Nguyen Van A",
                QueQuan = "Ha Noi",
                DiemToan = 9.0,
                DiemLy = 8.5,
                DiemHoa = 7.0
            };

            HocVien hv2 = new HocVien()
            {
                MaSo = "HV002",
                HoTen = "Tran Thi B",
                QueQuan = "Hai Phong",
                DiemToan = 6.0,
                DiemLy = 5.5,
                DiemHoa = 4.0
            };

            HocVien hv3 = new HocVien()
            {
                MaSo = "HV003",
                HoTen = "Le Van C",
                QueQuan = "Da Nang",
                DiemToan = 8.0,
                DiemLy = 8.0,
                DiemHoa = 8.0
            };

            // Thêm các đối tượng HocVien vào QuanLyHocVien
            qlhv.ThemHocVien(hv1);
            qlhv.ThemHocVien(hv2);
            qlhv.ThemHocVien(hv3);

            // Lấy danh sách học viên có đủ điều kiện nhận học bổng
            List<HocVien> ds = qlhv.LayDanhSachHocVienDuDieuKienNhanHocBong();

            // Kiểm tra xem danh sách có chứa đúng 2 học viên hv1 và hv3 hay không
            Assert.AreEqual(2, ds.Count);
            Assert.IsTrue(ds.Contains(hv1));
            Assert.IsTrue(ds.Contains(hv3));
        }

        // Test method để kiểm tra phương thức HienThiDanhSachHocVienDuDieuKienNhanHocBong
        [TestMethod]
        public void TestHienThiDanhSachHocVienDuDieuKienNhanHocBong()
        {
            // Tạo một đối tượng QuanLyHocVien
            QuanLyHocVien qlhv = new QuanLyHocVien("ABC");

            // Tạo một số đối tượng HocVien
            HocVien hv1 = new HocVien()
            {
                MaSo = "HV001",
                HoTen = "Nguyen Van A",
                QueQuan = "Ha Noi",
                DiemToan = 9.0,
                DiemLy = 8.5,
                DiemHoa = 7.0
            };

            HocVien hv2 = new HocVien()
            {
                MaSo = "HV002",
                HoTen = "Tran Thi B",
                QueQuan = "Hai Phong",
                DiemToan = 6.0,
                DiemLy = 5.5,
                DiemHoa = 4.0
            };

            HocVien hv3 = new HocVien()
            {
                MaSo = "HV003",
                HoTen = "Le Van C",
                QueQuan = "Da Nang",
                DiemToan = 8.0,
                DiemLy = 8.0,
                DiemHoa = 8.0
            };

            // Thêm các đối tượng HocVien vào QuanLyHocVien
            qlhv.ThemHocVien(hv1);
            qlhv.ThemHocVien(hv2);
            qlhv.ThemHocVien(hv3);

            // Tạo một đối tượng StringWriter để chứa kết quả hiển thị
            System.IO.StringWriter sw = new System.IO.StringWriter();

            // Đổi luồng xuất chuẩn sang StringWriter
            System.Console.SetOut(sw);

            // Gọi phương thức HienThiDanhSachHocVienDuDieuKienNhanHocBong
            qlhv.HienThiDanhSachHocVienDuDieuKienNhanHocBong();

            // Lấy kết quả hiển thị từ StringWriter
            string result = sw.ToString();

            // Kiểm tra xem kết quả có chứa đúng thông tin của hv1 và hv3 hay không
            Assert.IsTrue(result.Contains("HV001"));
            Assert.IsTrue(result.Contains("Nguyen Van A"));
            Assert.IsTrue(result.Contains("HV003"));
            Assert.IsTrue(result.Contains("Le Van C"));
        }


        [TestMethod]
            public void TestTinhDiemTrungBinh()
            {
                // Tạo một đối tượng HocVien với các điểm cho trước
                HocVien hv = new HocVien()
                {
                    MaSo = "HV001",
                    HoTen = "Nguyen Van A",
                    QueQuan = "Ha Noi",
                    DiemToan = 9.0,
                    DiemLy = 8.5,
                    DiemHoa = 7.0
                };

                // Tính điểm trung bình của học viên
                double dtb = hv.TinhDiemTrungBinh();

                // Kiểm tra xem điểm trung bình có bằng 8.16667 hay không
                Assert.AreEqual(8.16667, dtb, 0.00001);
            }

            // Test method để kiểm tra phương thức CoDuDieuKienNhanHocBong
            [TestMethod]
            public void TestCoDuDieuKienNhanHocBong()
            {
                // Tạo một đối tượng HocVien có đủ điều kiện nhận học bổng
                HocVien hv1 = new HocVien()
                {
                    MaSo = "HV001",
                    HoTen = "Nguyen Van A",
                    QueQuan = "Ha Noi",
                    DiemToan = 9.0,
                    DiemLy = 8.5,
                    DiemHoa = 7.0
                };

                // Kiểm tra xem học viên có đủ điều kiện nhận học bổng hay không
                Assert.IsTrue(hv1.CoDuDieuKienNhanHocBong());

                // Tạo một đối tượng HocVien không đủ điều kiện nhận học bổng
                HocVien hv2 = new HocVien()
                {
                    MaSo = "HV002",
                    HoTen = "Tran Thi B",
                    QueQuan = "Hai Phong",
                    DiemToan = 6.0,
                    DiemLy = 5.5,
                    DiemHoa = 4.0
                };

                // Kiểm tra xem học viên không đủ điều kiện nhận học bổng hay không
                Assert.IsFalse(hv2.CoDuDieuKienNhanHocBong());
            }
        }
    }

 

