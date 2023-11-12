using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class TrungTamGiaSu
    {
        public class HocVien
        {
            public string MaSo { get; set; }
            public string HoTen { get; set; }
            public string QueQuan { get; set; }
            public double DiemToan { get; set; }
            public double DiemLy { get; set; }
            public double DiemHoa { get; set; }

            public double TinhDiemTrungBinh()
            {
                return (DiemToan + DiemLy + DiemHoa) / 3;
            }

            public bool CoDuDieuKienNhanHocBong()
            {
                return TinhDiemTrungBinh() >= 8.0 && DiemToan >= 5.0 && DiemLy >= 5.0 && DiemHoa >= 5.0;
            }

            public void HienThiThongTin()
            {
                Console.WriteLine("Mã số: {0}", MaSo);
                Console.WriteLine("Họ tên: {0}", HoTen);
                Console.WriteLine("Quê quán: {0}", QueQuan);
                Console.WriteLine("Điểm Toán: {0}", DiemToan);
                Console.WriteLine("Điểm Lý: {0}", DiemLy);
                Console.WriteLine("Điểm Hóa: {0}", DiemHoa);
                Console.WriteLine("Điểm trung bình: {0}", TinhDiemTrungBinh());
                Console.WriteLine("Có đủ điều kiện nhận học bổng: {0}", CoDuDieuKienNhanHocBong());
            }
        }

        public class QuanLyHocVien
        {
            public string TenTrungTam { get; set; }
            public List<HocVien> DanhSachHocVien { get; set; }

            public QuanLyHocVien(string tenTrungTam)
            {
                TenTrungTam = tenTrungTam;
                DanhSachHocVien = new List<HocVien>();
            }

            public void ThemHocVien(HocVien hocVien)
            {
                DanhSachHocVien.Add(hocVien);
            }

            public List<HocVien> LayDanhSachHocVienDuDieuKienNhanHocBong()
            {
                List<HocVien> ketQua = new List<HocVien>();
                foreach (HocVien hocVien in DanhSachHocVien)
                {
                    if (hocVien.CoDuDieuKienNhanHocBong())
                    {
                        ketQua.Add(hocVien);
                    }
                }
                return ketQua;
            }

            public void HienThiDanhSachHocVienDuDieuKienNhanHocBong()
            {
                Console.WriteLine("Danh sách học viên có đủ điều kiện nhận học bổng của trung tâm {0}:", TenTrungTam);
                foreach (HocVien hocVien in LayDanhSachHocVienDuDieuKienNhanHocBong())
                {
                    hocVien.HienThiThongTin();
                    Console.WriteLine();
                }
            }
        }
    }
}
