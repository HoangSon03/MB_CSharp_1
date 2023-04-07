using System;
using System.Collections.Generic;
using System.Text;

namespace Son_CSharp_Bai1
{
    class Book : Item
    {
        int numOfPage;
        public int NumOfPage { get => numOfPage; set => numOfPage = value; }

        public Book()
        {
        }
        public Book(string itemId, string title, string author, DateTime publicstionDate, string type,string status, int numOfPage)
            : base(itemId, title, author, publicstionDate, type,status)
        {
            this.NumOfPage = numOfPage;
        }

       

        public override void Nhap(string type)
        {
            Console.WriteLine("Nhập thông tin Sách");
            base.Nhap(type);
            while (true)
            {
                try
                {
                    Console.WriteLine("Nhập số trang : "); this.NumOfPage = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Sai định dạng- Mời nhập lại");
                }
            }
        }

        public override void Xuat()
        {
            Console.WriteLine("Thông tin Sách");
            base.Xuat();
            Console.WriteLine("Số trang :{0}",this.NumOfPage);
            Console.WriteLine("-------------------------");
        }
        public override void Sua(string type)
        {
            Console.WriteLine("Cập nhật Sách");
            base.Sua(type);
            while (true)
            {
                try
                {
                    Console.WriteLine("Nhập số trang : "); this.NumOfPage = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Sai định dạng- Mời nhập lại");
                }
            }
        }
    }
}
