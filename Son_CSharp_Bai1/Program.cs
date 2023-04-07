using System;
using System.Text;


namespace Son_CSharp_Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            DanhSachItem QLTV = new DanhSachItem();
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            while (true)
            {
                Console.WriteLine("-----------------Chọn tác vụ------------------");
                Console.WriteLine("1 : Thêm Item");
                Console.WriteLine("2 : Xuất danh sách Item");
                Console.WriteLine("3 : Sửa Item");
                Console.WriteLine("4 : Xóa Item");
                Console.WriteLine("5 : Tìm Item ");
                Console.WriteLine("6 : Thêm Borrower ");
                Console.WriteLine("7 : Xuất danh sách Borrower ");
                Console.WriteLine("8 : Mượn Item");
                Console.WriteLine("9 : Trả Item");
                Console.WriteLine("10 : Xuất danh sach mượn trả");
                Console.WriteLine("0 : Thoát");
                string luachon = Console.ReadLine();
                if (luachon == "1") QLTV.Nhap();
                else if (luachon == "2") QLTV.Xuat();
                else if (luachon == "3") QLTV.Sua();
                else if (luachon == "4") QLTV.Xoa();
                else if (luachon == "5") QLTV.Tim();
                else if (luachon == "6") QLTV.NhapNguoi();
                else if (luachon == "7") QLTV.XuatNguoi();
                else if (luachon == "8") QLTV.MuonSach();
                else if (luachon == "9") QLTV.TraSach();
                else if (luachon == "10") QLTV.InDanhSachMuon();
                else if (luachon == "0") break;
            }
        }
    }
}
