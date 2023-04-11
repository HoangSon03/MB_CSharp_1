using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Son_CSharp_Bai1
{
    public class DanhSachItem
    {
        public List<Item> danhsach;
        public List<Borrower> danhsachnguoi;
        public List<BorrowingHistory> danhsachmuon;

        public DanhSachItem()
        {
            Danhsach = new List<Item> {
                new Book { ItemId = 1, Title = "DAC NHAN TAM 1", Author = "Kim Dong", PublicstionDate = Convert.ToDateTime("12/12/2012"), Type = "Book", Status = "Còn", NumOfPage = 40 },
                new Book { ItemId = 2, Title = "AN CU LAP NGHIEP", Author = "Kim Dung", PublicstionDate =Convert.ToDateTime("12/12/2012"), Type = "Book", Status = "Còn", NumOfPage = 50 },
                new DVD  { ItemId = 3, Title = "SIEU NHAN GAO", Author = "Sentai", PublicstionDate = Convert.ToDateTime("12/12/2012"), Type = "DVD", Status = "Còn", RunTime = "12:12" },
                new DVD  { ItemId = 4, Title = "SIEU NHAN DEKA", Author = "Mionu", PublicstionDate = Convert.ToDateTime("12/12/2022"), Type = "DVD", Status = "Còn", RunTime = "12:12" },
                new Book { ItemId = 5, Title = "DAC NHAN TAM 2", Author = "Kim Chi", PublicstionDate = Convert.ToDateTime("12/12/2012"), Type = "Book", Status = "Còn", NumOfPage = 80 },
            };
            Danhsachnguoi = new List<Borrower> {
                new Borrower{ UserId = 123,  UserName = "SON",  Address = "Da Nang" },
                new Borrower{ UserId = 124,  UserName = "PHUC",  Address = "Quang Nam" },
                new Borrower{ UserId = 125,  UserName = "HUNG",  Address = "Ha tinh" },
                new Borrower{ UserId = 126,  UserName = "HUNG",  Address = "Ha Noi" },
            };
            Danhsachmuon = new List<BorrowingHistory> {
                new BorrowingHistory{  BorrowNumber = 1,  UserId = 123, UserName = "SON",  ItemId=1,ItemName="DAC NHAN TAM 1",  BorrowDate=Convert.ToDateTime("12/12/2012"),  TinhTrang="Đã Trả" },
                new BorrowingHistory{  BorrowNumber = 2,  UserId = 123, UserName = "SON",  ItemId=4,ItemName="SIEU NHAN DEKA",  BorrowDate=Convert.ToDateTime("12/12/2012"),  TinhTrang="Đã Trả" },
                new BorrowingHistory{  BorrowNumber = 3,  UserId = 125, UserName = "HUNG", ItemId=3,ItemName="SIEU NHAN GAO",  BorrowDate=Convert.ToDateTime("12/12/2012"),  TinhTrang="Đã Trả" },
                new BorrowingHistory{  BorrowNumber = 4,  UserId = 123, UserName = "SON",  ItemId=5,ItemName="DAC NHAN TAM 2",  BorrowDate=Convert.ToDateTime("12/12/2012"),  TinhTrang="Đã Trả" },
                new BorrowingHistory{  BorrowNumber = 5,  UserId = 125, UserName = "HUNG", ItemId=1,ItemName="DAC NHAN TAM 1",  BorrowDate=Convert.ToDateTime("12/12/2012"),  TinhTrang="Đã Trả" },

            };
        }
        internal List<Item> Danhsach { get => danhsach; set => danhsach = value; }
        internal List<Borrower> Danhsachnguoi { get => danhsachnguoi; set => danhsachnguoi = value; }
        internal List<BorrowingHistory> Danhsachmuon { get => danhsachmuon; set => danhsachmuon = value; }

        public void Nhap()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Nhập B để nhập sách- Nhập D để nhập DVD - Nhập 0 để thoát");
                string c = Console.ReadLine();
                if (c == "0") break;
                else if (c.ToUpper() == "B")
                {
                    var _id = (from ds in Danhsach
                               orderby ds.ItemId descending
                               select ds.ItemId).FirstOrDefault() + 1;

                    //var _id = Danhsach.OrderBy(x => x.ItemId).Select(y => y.ItemId).FirstOrDefault() + 1;
                    Item item = new Book();
                    item.Nhap(_id, c);
                    Danhsach.Add(item);
                }
                else if (c.ToUpper() == "D")
                {
                    var _id = (from ds in Danhsach
                               orderby ds.ItemId descending
                               select ds.ItemId).FirstOrDefault() + 1;
                    Item item = new DVD();
                    item.Nhap(_id, c);
                    Danhsach.Add(item);
                }
            }
        }

        public void Xuat()
        {
            Console.Clear();
            Console.WriteLine("---------------------------Xuất Danh Sách Item-------------------------------------");
            foreach (Item item in Danhsach)
            {
                item.Xuat();
            }
        }
       
        public void TimItem()
        {
            Console.Clear();

            Console.WriteLine("---------------------------Tìm--------------------------------------");
            Console.WriteLine("Nhập Tên Item cần tìm :");
            string c = Console.ReadLine().ToUpper();
            var result = from it in Danhsach
                         where it.Title.Contains(c)
                         select it;
            //var result = Danhsach.Where(x => x.Title.Contains(c));
            if (result.Count() > 0)
            {
                foreach (Item item in result)
                {
                    item.Xuat();
                }
            }
            else
            {
                Console.WriteLine("-----> Không tồn tại item này");
            }
        }

        public void Sua()
        {
            Console.Clear();
            Console.WriteLine("---------------------------Cập Nhật Item--------------------------------------");
            Console.WriteLine("Nhập tên Item cần sửa :");
            string c = Console.ReadLine().ToUpper();
            var result = from it in Danhsach
                         where it.Title.Contains(c)
                         select it;
            //var result = Danhsach.Where(x => x.Title.Contains(c));
            if (result.Count() > 0)
            {
                foreach (Item item in result)
                {
                    item.Xuat();
                }
                try
                {
                    Console.WriteLine("Nhập ID Item cần sửa :");
                    int ch = Convert.ToInt32(Console.ReadLine());
                    var item = Danhsach.Find(x => x.ItemId == ch);
                    if (item != null)
                    {
                        item.Sua(item.Type);
                        Console.WriteLine("-----> Cập nhật thành công");
                    }
                    else
                    {
                        Console.WriteLine("-----> Không tồn tại item này");
                    }
                }
                catch
                {
                    Console.WriteLine("-----> Không tồn tại item này");
                }
            }
            else
            {
                Console.WriteLine("-----> Không tồn tại item này");
            }
        }
        public void Xoa()
        {
            Console.Clear();

            Console.WriteLine("---------------------------Xóa Item--------------------------------------");
            Console.WriteLine("Nhập tên Item cần xóa :");
            string c = Console.ReadLine().ToUpper();
            var result = from it in Danhsach
                         where it.Title.Contains(c)
                         select it;
            //var result = Danhsach.Where(x => x.Title.Contains(c));
            if (result.Count() > 0)
            {
                foreach (Item item in result)
                {
                    item.Xuat();
                }
                Console.WriteLine("Nhập ID cần xóa :");
                try
                {
                    int ch = Convert.ToInt32(Console.ReadLine());
                    var item = Danhsach.Find(x => x.ItemId == ch);
                    if (item != null)
                    {
                        Danhsach.Remove(item);
                        Console.WriteLine("-----> Xóa thành công");
                    }
                    else
                    {
                        Console.WriteLine("-----> Không tồn tại item này");
                    }
                }
                catch
                {
                    Console.WriteLine("-----> Không tồn tại item này");
                }
            }
            else
            {
                Console.WriteLine("-----> Không tồn tại item này");
            }
        }

        public void MuonSach()
        {
            Console.Clear();

            Console.WriteLine("-----------------------------Mượn Sách-----------------");
            BorrowingHistory ds = new BorrowingHistory();

            Console.WriteLine("Nhập tên User :"); string UserName = Console.ReadLine().ToUpper();
            var listU = from n in Danhsachnguoi
                        where n.UserName.Contains(UserName)
                        select n;
            if (listU.Count() == 1)
            {
                Console.WriteLine(listU.First().UserId + " - " + listU.First().UserName + " - " + listU.First().Address);
                Console.WriteLine("Nhập tên Item :"); string ItemName = Console.ReadLine().ToUpper();
                var listI = from i in Danhsach
                            where i.Title.Contains(ItemName) && i.Status == "Còn"
                            select i;
                int _id = (from dsm in Danhsachmuon
                           orderby dsm.BorrowNumber descending
                           select dsm.BorrowNumber).FirstOrDefault() + 1;
                int UserID = listU.FirstOrDefault().UserId;

                if (listI.Count() == 1)
                {

                    int ItemID = listI.First().ItemId;
                    Console.WriteLine(ItemID + " - " + listI.First().Title + " - " + listI.First().Type + " - " + listI.First().Author);
                    ds.ChoMuon(_id, UserID, listU.FirstOrDefault().UserName, ItemID, listI.FirstOrDefault().Title);
                    Danhsachmuon.Add(ds);
                    listI.FirstOrDefault().ThayDoiTinhTrang(ItemID, "Hết");
                    Console.WriteLine("---> Mượn thành công");
                }
                else if (listI.Count() > 1)
                {
                    Console.WriteLine("Danh sách Item trong thư viện :");
                    foreach (Item it in listI)
                    {
                        it.Xuat();
                    }
                    try
                    {
                        Console.WriteLine("Nhập  mã Item cần mượn :"); int ItemId = Convert.ToInt32(Console.ReadLine());
                        var ItemSelected = listI.Where(x => x.ItemId == ItemId).FirstOrDefault();
                        ds.ChoMuon(_id, UserID, listU.FirstOrDefault().UserName, ItemSelected.ItemId, ItemSelected.Title);
                        Danhsachmuon.Add(ds);
                        listI.FirstOrDefault().ThayDoiTinhTrang(ItemSelected.ItemId, "Hết");
                        Console.WriteLine("---> Mượn thành công");
                    }
                    catch
                    {
                        Console.WriteLine("Không tồn tại Item này");
                    }
                }
                else
                {
                    Console.WriteLine("Item này không còn trong thư viện");
                }
            }
            else if (listU.Count() > 1)
            {
                Console.WriteLine("Danh sách người dùng :");
                foreach (Borrower br in listU)
                {
                    br.Xuat();
                }
                try
                {
                    Console.WriteLine("Nhập mã người dùng :"); int UserId = Convert.ToInt32(Console.ReadLine());
                    var UserSelected = listU.FirstOrDefault(x => x.UserId == UserId);
                    Console.WriteLine("Nhập tên Item :"); string ItemName = Console.ReadLine().ToUpper();
                    var listI = from i in Danhsach
                                where i.Title.Contains(ItemName) && i.Status == "Còn"
                                select i;
                    int _id = (from dsm in Danhsachmuon
                               orderby dsm.BorrowNumber descending
                               select dsm.BorrowNumber).FirstOrDefault() + 1;
                    int UserID = UserSelected.UserId;

                    if (listI.Count() == 1)
                    {
                        int ItemID = listI.FirstOrDefault().ItemId;
                        Console.WriteLine(ItemID + " - " + listI.First().Title + " - " + listI.First().Type + " - " + listI.First().Author);
                        ds.ChoMuon(_id, UserID, UserSelected.UserName, ItemID, listI.FirstOrDefault().Title);
                        Danhsachmuon.Add(ds);
                        listI.FirstOrDefault().ThayDoiTinhTrang(ItemID, "Hết");
                        Console.WriteLine("---> Mượn thành công");
                    }
                    else if (listI.Count() > 1)
                    {
                        Console.WriteLine("Danh sách Item trong thư viện :");
                        foreach (Item it in listI)
                        {
                            it.Xuat();
                        }
                        try
                        {
                            Console.WriteLine("Nhập  mã Item cần mượn :"); int ItemId = Convert.ToInt32(Console.ReadLine());
                            var ItemSelected = listI.Where(x => x.ItemId == ItemId).FirstOrDefault();
                            ds.ChoMuon(_id, UserID, listU.FirstOrDefault().UserName, ItemSelected.ItemId, ItemSelected.Title);
                            Danhsachmuon.Add(ds);
                            listI.FirstOrDefault().ThayDoiTinhTrang(ItemSelected.ItemId, "Hết");
                            Console.WriteLine("---> Mượn thành công");
                        }
                        catch
                        {
                            Console.WriteLine("Không tồn tại Item này");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Item này không còn trong thư viện");
                    }
                }
                catch
                {
                    Console.WriteLine("Nguời dùng này chưa được đăng ký thành viên");
                }
            }
            else
            {
                Console.WriteLine("Nguời dùng này chưa được đăng ký thành viên");
            }
        }

        public void TraSach()
        {
            Console.Clear();

            Console.WriteLine("-----------------------------Trả Sách-----------------");
            BorrowingHistory ds = new BorrowingHistory();
            var listMuon = from dsm in Danhsachmuon
                           where dsm.TinhTrang=="Đang Mượn"
                           select dsm;
            try
            {
                Console.WriteLine("Nhập số mượn :"); int number = Convert.ToInt32(Console.ReadLine());
                if (listMuon.FirstOrDefault(x => x.BorrowNumber == number) != null)
                {
                    var DanhSachMuon = listMuon.FirstOrDefault(x => x.BorrowNumber == number);
                    DanhSachMuon.TraItem();
                    var item = Danhsach.Find(x => x.ItemId == DanhSachMuon.ItemId);
                    item.ThayDoiTinhTrang(DanhSachMuon.ItemId, "Còn");
                    Console.WriteLine("---> Trả thành công");
                }
                else
                {
                    Console.WriteLine("Nguời dùng chưa mượn sách");
                }
            }
            catch
            {
                Console.WriteLine("Nguời dùng chưa mượn sách");

            }
        }
        public void InDanhSachMuon()
        {
            Console.Clear();

            Console.WriteLine("---------------------------Danh Sách Mượn-------------------------------------");
            foreach (BorrowingHistory br in Danhsachmuon)
            {
                br.InDanhSach();
            }
        }

        public void NhapNguoi()
        {
            Console.Clear();

            Console.WriteLine("-----------------------------Thêm người mượn-----------------");
            Borrower person = new Borrower();
            try
            {
                var _id = (from dsn in Danhsachnguoi
                           orderby dsn.UserId descending
                           select dsn.UserId).FirstOrDefault() + 1;
                person.Nhap(_id);
                Danhsachnguoi.Add(person);
                Console.WriteLine("-----> Thêm người mượn thành công");
            }
            catch
            {
                Console.WriteLine("-----> Trùng mã Item - Mời nhập lại");
            }
        }
        public void XuatNguoi()
        {
            Console.Clear();

            Console.WriteLine("-----------------------------Danh sách người mượn-----------------");
            foreach (Borrower person in Danhsachnguoi)
            {
                person.Xuat();
            }
        }

        public void XuatSach()
        {
            Console.Clear();

            Console.WriteLine("-----------------------------Danh sách Item Sách-----------------");
            var list = from s in Danhsach
                       where s.Type == "Book"
                       orderby s.Title
                       select s;
            foreach (Item item in list)
            {
                item.Xuat();
            }
        }

        public void DemDVD()
        {
            Console.Clear();

            Console.WriteLine("-----------------------------Danh sách DVD xuất bản 2022-----------------");
            int soluong = (from d in Danhsach
                           where d.Type == "DVD" && d.PublicstionDate.Year == 2022
                           select d).Count();
            Console.WriteLine("Có {0} DVD xuất bản năm 2022", soluong);
        }

        public void InDSNguoiMuon()
        {
            Console.Clear();

            Console.WriteLine("-----------------------------Danh sách người mượn sách và DVD-----------------");
             var list1 = from m in Danhsachmuon
                        join i in Danhsach on m.ItemId equals i.ItemId
                        where i.Type == "Book"
                        select m;
            var list2 = from m in Danhsachmuon
                        join i in Danhsach on m.ItemId equals i.ItemId
                        where i.Type == "DVD"
                        select m;
            var list = (from n in danhsachnguoi
                        join l1 in list1 on n.UserId equals l1.UserId
                        join l2 in list2 on l1.UserId equals l2.UserId
                        select n).Distinct();

            foreach (Borrower br in list)
            {
                br.Xuat();
            }
        }
    }
}
