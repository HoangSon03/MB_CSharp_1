using System;
using System.Collections.Generic;
using System.Text;

namespace Son_CSharp_Bai1
{
   public class BorrowingHistory
    {
        string borrowNumber;
        string userId;
        string itemId;
        DateTime borrowDate;
        string tinhTrang;

        public BorrowingHistory() { }
        public BorrowingHistory(string borrowNumber, string userId, string itemId, DateTime borrowDate, string tinhTrang)
        {
            this.BorrowNumber = borrowNumber;
            this.UserId = userId;
            this.ItemId = itemId;
            this.BorrowDate = borrowDate;
            this.TinhTrang = tinhTrang;
        }

        public string BorrowNumber { get => borrowNumber; set => borrowNumber = value; }
        public string UserId { get => userId; set => userId = value; }
        public string ItemId { get => itemId; set => itemId = value; }
        public DateTime BorrowDate { get => borrowDate; set => borrowDate = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }

        public void ChoMuon()
        {
            Console.WriteLine("Nhập số mượn :"); this.borrowNumber = Console.ReadLine();
            Console.WriteLine("Nhập mã User :"); this.UserId = Console.ReadLine();
            Console.WriteLine("Nhập mã Item :"); this.ItemId = Console.ReadLine();
            this.BorrowDate = DateTime.Now;
            this.TinhTrang = "Đang Mượn";
        }
        public void InDanhSach()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Số mượn :{0}", this.BorrowNumber);
            Console.WriteLine("Mã User :{0}", this.UserId);
            Console.WriteLine("Mã Item :{0}", this.ItemId);
            Console.WriteLine("Tình trạng :{0}", this.TinhTrang);
        }
        public void TraItem()
        {
            this.TinhTrang = "Đã Trả";
        }
    }
}
