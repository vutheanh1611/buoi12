using System;
using System.Collections.Generic;

namespace BaiTapQLSV
{
    class QuanLySinhVien
    {
        private List<SinhVien> ListSinhVien = null;

        public QuanLySinhVien()
        {
            ListSinhVien = new List<SinhVien>();
        }

        /**
         * Hàm tạo ID tăng dần cho nhân viên
         */
        private int GenerateID()
        {
            int max = 1;
            if (ListSinhVien != null && ListSinhVien.Count > 0)
            {
                max = ListSinhVien[0].ID;
                foreach (SinhVien sv in ListSinhVien)
                {
                    if (max < sv.ID)
                    {
                        max = sv.ID;
                    }
                }
                max++;
            }
            return max;
        }

        public int SoLuongSinhVien()
        {
            int Count = 0;
            if (ListSinhVien != null)
            {
                Count = ListSinhVien.Count;
            }
            return Count;
        }

        public void NhapSinhVien()
        {
            // Khởi tạo một sinh viên mới
            SinhVien sv = new SinhVien();
            sv.ID = GenerateID();
            Console.Write("Nhap ten sinh vien: ");
            sv.Name = Convert.ToString(Console.ReadLine());

            Console.Write("Nhap gioi tinh sinh vien: ");
            sv.Sex = Convert.ToString(Console.ReadLine());

            Console.Write("Nhap tuoi sinh vien: ");
            sv.Age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Nhap diem toan: ");
            sv.DiemToan = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhap diem ly: ");
            sv.DiemLy = Convert.ToDouble(Console.ReadLine());

            Console.Write("Nhap diem hoa: ");
            sv.DiemHoa = Convert.ToDouble(Console.ReadLine());

            TinhDTB(sv);
            XepLoaiHocLuc(sv);

            ListSinhVien.Add(sv);
        }

        public void UpdateSinhVien(int ID)
        {
            // Tìm kiếm sinh viên trong danh sách ListSinhVien
            SinhVien sv = FindByID(ID);
            // Nếu sinh viên tồn tại thì cập nhập thông tin sinh viên
            if (sv != null)
            {
                Console.Write("Nhap ten sinh vien: ");
                string name = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật tên
                if (name != null && name.Length > 0)
                {
                    sv.Name = name;
                }

                Console.Write("Nhap gioi tinh sinh vien: ");
                // Nếu không nhập gì thì không cập nhật giới tính
                string sex = Convert.ToString(Console.ReadLine());
                if (sex != null && sex.Length > 0)
                {
                    sv.Sex = sex;
                }

                Console.Write("Nhap tuoi sinh vien: ");
                string ageStr = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật tuổi
                if (ageStr != null && ageStr.Length > 0)
                {
                    sv.Age = Convert.ToInt32(ageStr);
                }

                Console.Write("Nhap diem toan: ");
                string diemToanStr = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật điểm toán
                if (diemToanStr != null && diemToanStr.Length > 0)
                {
                    sv.DiemToan = Convert.ToDouble(diemToanStr);
                }

                Console.Write("Nhap diem ly: ");
                string diemLyStr = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật điểm lý
                if (diemLyStr != null && diemLyStr.Length > 0)
                {
                    sv.DiemLy = Convert.ToDouble(diemLyStr);
                }

                Console.Write("Nhap diem hoa: ");
                string diemHoaStr = Convert.ToString(Console.ReadLine());
                // Nếu không nhập gì thì không cập nhật điểm hóa
                if (diemHoaStr != null && diemHoaStr.Length > 0)
                {
                    sv.DiemHoa = Convert.ToDouble(diemHoaStr);
                }

                TinhDTB(sv);
                XepLoaiHocLuc(sv);
            }
            else
            {
                Console.WriteLine("Sinh vien co ID = {0} khong ton tai.", ID);
            }
        }

        /**
         * Hàm sắp xếp danh sach sinh vien theo ID tăng dần
         */
        public void SortByID()
        {
            ListSinhVien.Sort(delegate (SinhVien sv1, SinhVien sv2) {
                return sv1.ID.CompareTo(sv2.ID);
            });
        }

        /**
         * Hàm sắp xếp danh sach sinh vien theo tên tăng dần
         */
        public void SortByName()
        {
            ListSinhVien.Sort(delegate (SinhVien sv1, SinhVien sv2) {
                return sv1.Name.CompareTo(sv2.Name);
            });
        }

        /**
         * Hàm sắp xếp danh sach sinh vien theo điểm TB tăng dần
         */
        public void SortByDiemTB()
        {
            ListSinhVien.Sort(delegate (SinhVien sv1, SinhVien sv2) {
                return sv1.DiemTB.CompareTo(sv2.DiemTB);
            });
        }

        /**
         * Hàm tìm kiếm sinh viên theo ID
         * Trả về một sinh viên
         */
        public SinhVien FindByID(int ID)
        {
            SinhVien searchResult = null;
            if (ListSinhVien != null && ListSinhVien.Count > 0)
            {
                foreach (SinhVien sv in ListSinhVien)
                {
                    if (sv.ID == ID)
                    {
                        searchResult = sv;
                    }
                }
            }
            return searchResult;
        }

        /**
         * Hàm tìm kiếm sinh viên theo tên
         * Trả về một danh sách sinh viên
         */
        public List<SinhVien> FindByName(String keyword)
        {
            List<SinhVien> searchResult = new List<SinhVien>();
            if (ListSinhVien != null && ListSinhVien.Count > 0)
            {
                foreach (SinhVien sv in ListSinhVien)
                {
                    if (sv.Name.ToUpper().Contains(keyword.ToUpper()))
                    {
                        searchResult.Add(sv);
                    }
                }
            }
            return searchResult;
        }

        /**
         * Hàm xóa sinh viên theo ID
         */
        public bool DeleteById(int ID)
        {
            bool IsDeleted = false;
            // tìm kiếm sinh viên theo ID
            SinhVien sv = FindByID(ID);
            if (sv != null)
            {
                IsDeleted = ListSinhVien.Remove(sv);
            }
            return IsDeleted;
        }

        /**
         * Hàm tính điểm TB cho sinh viên
         */
        private void TinhDTB(SinhVien sv)
        {
            double DiemTB = (sv.DiemToan + sv.DiemLy + sv.DiemHoa) / 3;
            sv.DiemTB = Math.Round(DiemTB, 2, MidpointRounding.AwayFromZero);
        }

        /**
         * Hàm xếp loại học lực cho nhân viên
         */
        private void XepLoaiHocLuc(SinhVien sv)
        {
            if (sv.DiemTB >= 8)
            {
                sv.HocLuc = "Gioi";
            }
            else if (sv.DiemTB >= 6.5)
            {
                sv.HocLuc = "Kha";
            }
            else if (sv.DiemTB >= 5)
            {
                sv.HocLuc = "Trung Binh";
            }
            else
            {
                sv.HocLuc = "Yeu";
            }
        }

        /**
         * Hàm hiển thị danh sách sinh viên ra màn hình console
         */
        public void ShowSinhVien(List<SinhVien> listSV)
        {
            // hien thi tieu de cot
            Console.WriteLine("{0, -5} {1, -20} {2, -5} {3, 5} {4, 5} {5, 5} {6, 5} {7, 10} {8, 10}",
                  "ID", "Name", "Sex", "Age", "Toan", "Ly", "Hoa", "Diem TB", "Hoc Luc");
            // hien thi danh sach sinh vien
            if (listSV != null && listSV.Count > 0)
            {
                foreach (SinhVien sv in listSV)
                {
                    Console.WriteLine("{0, -5} {1, -20} {2, -5} {3, 5} {4, 5} {5, 5} {6, 5} {7, 10} {8, 10}",
                                      sv.ID, sv.Name, sv.Sex, sv.Age, sv.DiemToan, sv.DiemLy, sv.DiemHoa,
                                      sv.DiemTB, sv.HocLuc);
                }
            }
            Console.WriteLine();
        }

        /*
         * Hàm trả về danh sách sinh viên hiện tại
         */
        public List<SinhVien> getListSinhVien()
        {
            return ListSinhVien;
        }
    }
}