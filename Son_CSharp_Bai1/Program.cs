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
                Console.WriteLine("11 : Xuất danh sách Item Sách");
                Console.WriteLine("12 : Xuất danh sách DVD xuất bản 2022");
                Console.WriteLine("13 : Xuất danh Người mượn Sách và Item");
                //Console.WriteLine("0 : Thoát");
                string luachon = Console.ReadLine();
                switch (luachon)
                {
                    case "1": 
                        QLTV.Nhap(); break;
                    case "2": 
                        QLTV.Xuat(); break;
                    case "3": 
                        QLTV.Sua(); break;
                    case "4":
                        QLTV.Xoa(); break;
                    case "5": 
                        QLTV.TimItem(); break;
                    case "6": 
                        QLTV.NhapNguoi(); break;
                    case "7": 
                        QLTV.XuatNguoi(); break;
                    case "8":
                        QLTV.MuonSach(); break;
                    case "9": 
                        QLTV.TraSach(); break;
                    case "10": 
                        QLTV.InDanhSachMuon(); break;
                    case "11": 
                        QLTV.XuatSach(); break;
                    case "12":
                        QLTV.DemDVD(); break;
                    case "13":
                        QLTV.InDSNguoiMuon(); break;
                }
            }
        }
    }
}
