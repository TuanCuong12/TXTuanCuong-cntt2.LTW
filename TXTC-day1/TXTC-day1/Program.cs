namespace TXTC_day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string choise;
            List<Student> students = new List<Student>()
            {
                new Student{masv="SV001",hoTen="Chung Trinh",email="chungtrinhj@gmail.com", sdt="0978611889"},
                new Student{masv="SV002",hoTen="Chach Van Doanh",email="doanh@gmail.com",sdt="0978611889"},
            };
            do
            {
                menu();
                Console.Write("Ban chon chuc nang:");
                choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        // Them sinnh vien
                        ThemMoiSinhVien(students);
                        break;
                    case "2":
                        // Hien thi
                        HienThiThongTin(students);
                        break;

                    case "14":
                        Console.WriteLine("Ban da ket thuc chuc nang");
                        break;
                    default:
                        Console.WriteLine("Ban chon sai chuc nang");
                        break;
                }

            } while (choise != "14");

        }
        


        

        static void menu()
        {
            Console.WriteLine("===========Chuc nang===========");
            Console.WriteLine("1.\tThêm sinh viên.\r" +
                "\n2.\tHiển thị danh sách.\r" +
                "\n3.\tTìm sinh viên theo mã.\r" +
                "\n4.\tTìm gần đúng theo họ tên.\r" +
                "\n5.\tCập nhật sinh viên.\r" +
                "\n6.\tXóa sinh viên.\r" +
                "\n7.\tSắp xếp theo họ tên.\r" +
                "\n8.\tSắp xếp theo điểm trung bình.\r" +
                "\n9.\tHiển thị sinh viên có điểm từ 8 trở lên.\r" +
                "\n10.\tHiển thị sinh viên có điểm cao nhất.\r" +
                "\n11.\tTính điểm trung bình toàn bộ sinh viên.\r" +
                "\n12.\tThống kê sinh viên theo ngành.\r" +
                "\n13.\tThống kê sinh viên theo trạng thái.\r");
        }
        static void HienThiThongTin(List<Student> students)
        {
            Console.WriteLine("Danh sach sinh vien");
            foreach (var item in students)
            {
                Console.WriteLine("Mã sinh viên:" + item.masv);
                Console.WriteLine("Họ và tên:" + item.hoTen);
                Console.WriteLine("--------------------------");
            }
        }
        static void ThemMoiSinhVien(List<Student> students)
        {
            Console.WriteLine("--- NHAP THONG TIN SINH VIEN ---");
            Student student = new Student();

            // 1. Quy tắc: Mã sinh viên không được rỗng & không được trùng
            while (true)
            {
                Console.Write("Nhập mã SV: ");
                student.masv = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(student.masv))
                {
                    Console.WriteLine("Lỗi: Mã SV không được để trống!");
                }
                else if (students.Any(s => s.masv == student.masv)) // Kiểm tra trùng mã
                {
                    Console.WriteLine("Lỗi: Mã SV đã tồn tại. Vui lòng nhập mã khác!");
                }
                else
                {
                    break; // Hợp lệ -> Thoát vòng lặp, đi tới bước tiếp theo
                }
            }

            // 2. Quy tắc: Họ tên không được rỗng
            while (true)
            {
                Console.Write("Nhập họ tên SV: ");
                student.hoTen = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(student.hoTen))
                {
                    Console.WriteLine("Lỗi: Họ tên không được để trống!");
                }
                else
                {
                    break;
                }
            }

            // 3. Quy tắc: Email phải đúng định dạng
            while (true)
            {
                Console.Write("Nhập Email: ");
                student.email = Console.ReadLine();

                // Regex đơn giản để check @ và dấu chấm
                if (string.IsNullOrWhiteSpace(student.email) || !System.Text.RegularExpressions.Regex.IsMatch(student.email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                    Console.WriteLine("Lỗi: Email không hợp lệ (Ví dụ đúng: abc@gmail.com)!");
                }
                else
                {
                    break;
                }
            }

            // 4. Quy tắc: Điểm trung bình từ 0 đến 10
            while (true)
            {
                Console.Write("Nhập điểm trung bình (0-10): ");
                string inputDtb = Console.ReadLine();

                // Kiểm tra xem người dùng có nhập đúng số không, và số đó có từ 0-10 không
                if (float.TryParse(inputDtb, out float diem) && diem >= 0 && diem <= 10)
                {
                    student.dtb = diem;
                    break;
                }
                else
                {
                    Console.WriteLine("Lỗi: Điểm trung bình phải là số và nằm trong khoảng 0 đến 10!");
                }
            }

            // Tạm thời cho nhập thêm sdt để đầy đủ dữ liệu test
            Console.Write("Nhập số điện thoại: ");
            student.sdt = Console.ReadLine();

            // Thêm vào danh sách
            students.Add(student);
            Console.WriteLine("=> Thêm sinh viên thành công!");
        }
    }
}
