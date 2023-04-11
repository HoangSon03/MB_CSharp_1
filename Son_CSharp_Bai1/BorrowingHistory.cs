using System;
using System.Collections.Generic;
using System.Text;

namespace Son_CSharp_Bai1
{
    public class BorrowingHistory
    {
        int borrowNumber;
        int userId;
        string userName;
        int itemId;
        string itemName;
        DateTime borrowDate;
        string tinhTrang;

        public BorrowingHistory() { }
        public BorrowingHistory(int borrowNumber, int userId, string userName, int itemId, string itemName, DateTime borrowDate, string tinhTrang)
        {
            this.BorrowNumber = borrowNumber;
            this.UserId = userId;
            this.UserName = userName;
            this.ItemId = itemId;
            this.ItemName = itemName;
            this.BorrowDate = borrowDate;
            this.TinhTrang = tinhTrang;
        }

        public int BorrowNumber { get => borrowNumber; set => borrowNumber = value; }
        public int UserId { get => userId; set => userId = value; }
        public string UserName { get => userName; set => userName = value; }
        public int ItemId { get => itemId; set => itemId = value; }
        public string ItemName { get => itemName; set => itemName = value; }
        public DateTime BorrowDate { get => borrowDate; set => borrowDate = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }

        public void ChoMuon(int _id, int UserID, string UserName, int ItemID, string ItemName)
        {
            this.borrowNumber = _id;
            this.UserId = UserID;
            this.UserName = UserName;
            this.ItemId = ItemID;
            this.ItemName = ItemName;
            this.BorrowDate = DateTime.Now;
            this.TinhTrang = "Đang Mượn";
        }
        public void InDanhSach()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Số mượn :{0}", this.BorrowNumber);
            //Console.WriteLine("Mã User :{0}", this.UserId);
            Console.WriteLine("Tên User :{0}", this.UserName);
            //Console.WriteLine("Mã Item :{0}", this.ItemId);
            Console.WriteLine("Tên Item :{0}", this.ItemName);
            Console.WriteLine("Tình trạng :{0}", this.TinhTrang);
        }
        public void TraItem()
        {
            this.TinhTrang = "Đã Trả";
        }
    }
}
