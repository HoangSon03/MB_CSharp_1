using System;
using System.Collections.Generic;
using System.Text;

namespace Son_CSharp_Bai1
{
    public abstract class Item
    {
        private string itemId;
        private string title;
        private string author;
        private DateTime publicstionDate;
        private string type;
        private string status;

        public string ItemId { get => itemId; set => itemId = value; }
        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public DateTime PublicstionDate { get => publicstionDate; set => publicstionDate = value; }
        public string Type { get => type; set => type = value; }
        public string Status { get => status; set => status = value; }

        public Item() { }

        protected Item(string itemId, string title, string author, DateTime publicstionDate, string type, string status)
        {
            this.itemId = itemId;
            this.title = title;
            this.author = author;
            this.publicstionDate = publicstionDate;
            this.type = type;
            this.status = status;
        }

        public virtual void Nhap(string type)
        {
            Console.WriteLine("Nhập Mã Item :"); this.ItemId = Console.ReadLine();
            Console.WriteLine("Nhập Tên Item :"); this.Title = Console.ReadLine();
            Console.WriteLine("Nhập Tác giả :"); this.Author = Console.ReadLine();
            while (true)
            {
                try
                {
                    Console.WriteLine("Nhập ngày xuất bản :"); this.PublicstionDate = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Sai định dạng MM-dd-yyyy. Mời nhập lại");
                }
            }
            this.Type = type.ToUpper();
            if (type.ToUpper() == "B")
            {
                this.type = "Book";
            }else
            {
                this.type = "DVD";
            }
            this.Status = "Con";
        }
        public virtual void Xuat()
        {
            Console.WriteLine("Mã Item :{0}", this.ItemId);
            Console.WriteLine("Tên Item :{0}", this.Title);
            Console.WriteLine("Tác giả :{0}", this.Author);
            Console.WriteLine("Ngày xuất bản :{0}", this.PublicstionDate);
            Console.WriteLine("Loại Item :{0}", this.Type);
            Console.WriteLine("Tình trạng :{0}", this.Status);
        }
        public virtual void Sua(string type)
        {
            Console.WriteLine("Nhập Tên Item :"); this.Title = Console.ReadLine();
            Console.WriteLine("Nhập Tác giả :"); this.Author = Console.ReadLine();
            while (true)
            {
                try
                {
                    Console.WriteLine("Nhập ngày xuất bản :"); this.PublicstionDate = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Sai định dạng MM-dd-yyyy. Mời nhập lại");
                }
            }
            if (type.ToUpper() == "B")
            {
                this.Type = "Book";
            }
            else if (type.ToUpper() == "D")
            {
                this.Type = "DVD";
            }
            this.Status = "Con";
        }
        public virtual void ThayDoiTinhTrang(string Id, string tinhtrang)
        {
            this.ItemId = Id;
            this.Status = tinhtrang;
        }
    }
}
