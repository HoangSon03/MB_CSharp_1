using System;
using System.Collections.Generic;
using System.Text;

namespace Son_CSharp_Bai1
{
    public class DanhSachItem
    {
        public Dictionary<string, Item> danhsach;
        public Dictionary<string, BorrowingHistory> danhsachmuon;
        public Dictionary<string, Borrower> danhsachnguoi;

        public DanhSachItem()
        {
            Danhsach = new Dictionary<string, Item>();
            Danhsachmuon = new Dictionary<string, BorrowingHistory>();
            Danhsachnguoi = new Dictionary<string, Borrower>();
        }
        internal Dictionary<string, Item> Danhsach { get => danhsach; set => danhsach = value; }
        internal Dictionary<string, BorrowingHistory> Danhsachmuon { get => danhsachmuon; set => danhsachmuon = value; }
        internal Dictionary<string, Borrower> Danhsachnguoi { get => danhsachnguoi; set => danhsachnguoi = value; }

        public void Nhap()
        {
            while (true)
            {
                Console.WriteLine("Nhập B để nhập sách- Nhập D để nhập DVD - Nhập 0 để thoát");
                string c = Console.ReadLine();
                if (c == "0") break;
                else if (c.ToUpper() == "B")
                {
                    Item item = new Book();
                    try
                    {
                        item.Nhap(c);
                        Danhsach.Add(item.ItemId, item);
                    }
                    catch
                    {
                        Console.WriteLine("-----> Trùng mã Item - Mời nhập lại");
                    }
                }
                else if (c.ToUpper() == "D")
                {
                    Item item = new DVD();
                    try
                    {
                        item.Nhap(c);
                        Danhsach.Add(item.ItemId, item);
                    }
                    catch
                    {
                        Console.WriteLine("-----> Trùng mã Item - Mời nhập lại");
                    }
                }
            }
        }

        public void Xuat()
        {
            Console.WriteLine("---------------------------Xuất Danh Sách Item-------------------------------------");
            foreach (Item item in Danhsach.Values)
            {
                if (item.Status == "Con")
                {
                    item.Xuat();
                }
            }
        }
        public void Tim()
        {
            Console.WriteLine("---------------------------Tìm--------------------------------------");
            Console.WriteLine("Nhập ID cần tìm :");
            string c = Console.ReadLine();
            int tim = 0;
            foreach (Item it in Danhsach.Values)
            {
                if (it.ItemId == c)
                {
                    tim = 1;
                    it.Xuat();
                    break;
                }
                else
                {
                    tim = 0;
                }
            }
            if (tim == 0)
                Console.WriteLine("-----> Không tồn tại item này");
        }
        public void Sua()
        {
            Console.WriteLine("---------------------------Cập Nhật Item--------------------------------------");
            Console.WriteLine("Nhập ID cần sửa :");
            string c = Console.ReadLine();
            int tim = 0;
            foreach (Item it in Danhsach.Values)
            {
                if (it.ItemId == c)
                {
                    it.Xuat();
                    tim = 1;
                    it.Sua(it.Type);
                    Danhsach[c] = it;
                    Console.WriteLine("-----> Sửa thành công");
                    break;
                }
                else
                {
                    tim = 0;
                }
            }
            if (tim == 0)
                Console.WriteLine("-----> Không tồn tại item này");
        }
        public void Xoa()
        {
            Console.WriteLine("---------------------------Xóa Item--------------------------------------");
            Console.WriteLine("Nhập ID cần xóa :");
            string c = Console.ReadLine();
            if (Danhsach.ContainsKey(c))
            {
                Danhsach.Remove(c);
                Console.WriteLine("-----> Xóa thành công");

            }
            else
            {
                Console.WriteLine("-----> Không tồn tại item này");
            }
        }

        public void ThayDoiTinhTrang(string Id, string tinhtrang)
        {
            int tim = 0;
            foreach (Item item in Danhsach.Values)
            {
                if (item.ItemId == Id)
                {
                    tim = 1;
                    item.ThayDoiTinhTrang(Id, tinhtrang);
                    Danhsach[Id] = item;
                    break;
                }
                else
                {
                    tim = 0;
                }
            }
            if (tim == 0)
            {
                Console.WriteLine("-----> Không tìm thấy item này trong kho");
            }
        }

        public void MuonSach()
        {
            Console.WriteLine("-----------------------------Mượn Sách-----------------");
            BorrowingHistory ds = new BorrowingHistory();
            try
            {
                ds.ChoMuon();
                int tim = 0;
                int timnguoi = 0;
                foreach (Borrower person in danhsachnguoi.Values)
                {
                    if (person.UserId == ds.UserId)
                    {
                        timnguoi = 1;
                        foreach (Item item in Danhsach.Values)
                        {
                            if (item.ItemId == ds.ItemId && item.Status == "Con")
                            {
                                tim = 1;
                                item.ThayDoiTinhTrang(ds.ItemId, "Het");
                                Danhsach[ds.ItemId] = item;
                                Danhsachmuon.Add(ds.BorrowNumber, ds);
                                Console.WriteLine("-----> Mượn thành công");
                                break;
                            }
                            else
                            {
                                tim = 0;
                            }
                        }
                        if (tim == 0)
                        {
                            Console.WriteLine("-----> Không tìm thấy item này trong kho");
                        }
                    }
                    else { timnguoi = 0; }
                }
                if (timnguoi == 0)
                {
                    Console.WriteLine("-----> User này chưa được đăng ký");
                }

            }
            catch
            {
                Console.WriteLine("-----> Trùng số mượn - Mời nhập lại");
            }
        }

        public void TraSach()
        {
            Console.WriteLine("-----------------------------Trả Sách-----------------");
            Console.WriteLine("Nhập số mượn :");
            string c = Console.ReadLine();
            int tim = 0;
            foreach (BorrowingHistory br in Danhsachmuon.Values)
            {
                if (br.BorrowNumber == c)
                {
                    tim = 1;
                    br.TraItem();
                    Danhsachmuon[c] = br;
                    foreach (Item it in Danhsach.Values)
                    {
                        if (it.ItemId == br.ItemId)
                        {
                            it.ThayDoiTinhTrang(br.ItemId, "Con");
                            Danhsach[br.ItemId] = it;
                            break;
                        }
                    }
                    Console.WriteLine("-----> Trả thành công");
                    break;
                }
                else
                {
                    tim = 0;
                }
            }
            if (tim == 0)
                Console.WriteLine("-----> Không tồn tại trong danh sách mượn");
        }
        public void InDanhSachMuon()
        {
            Console.WriteLine("---------------------------Danh Sách Mượn-------------------------------------");
            foreach (BorrowingHistory br in Danhsachmuon.Values)
            {
                br.InDanhSach();
            }
        }

        public void NhapNguoi()
        {
            Console.WriteLine("-----------------------------Thêm người mượn-----------------");
            Borrower person = new Borrower();
            try
            {
                person.Nhap();
                Danhsachnguoi.Add(person.UserId, person);
                Console.WriteLine("-----> Thêm người mượn thành công");
            }
            catch
            {
                Console.WriteLine("-----> Trùng mã Item - Mời nhập lại");
            }
        }
        public void XuatNguoi()
        {
            Console.WriteLine("-----------------------------Danh sách người mượn-----------------");
            foreach (Borrower person in Danhsachnguoi.Values)
            {
                person.Xuat();
            }
        }
    }
}
