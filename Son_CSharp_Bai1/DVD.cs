using System;
using System.Collections.Generic;
using System.Text;

namespace Son_CSharp_Bai1
{
    class DVD : Item
    {
        string runTime;
        public string RunTime { get => runTime; set => runTime = value; }

        public DVD()
        {
        }
        public DVD(int itemId, string title, string author, DateTime publicstionDate, string type,string status, string runTime)
            : base(itemId, title, author, publicstionDate, type,status)
        {
            this.RunTime = runTime;
        }

        public override void Nhap(int id,string type)
        {
            Console.WriteLine("Nhập thông tin DVD");
            base.Nhap(id,type);
            Console.WriteLine("Nhập thời gian phát : ");this.RunTime =Console.ReadLine();
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine("Thời gian phát :{0}", this.RunTime);
            Console.WriteLine("-------------------------");
        }
        public override void Sua(string type)
        {
            Console.WriteLine("Cập nhật DVD");
            base.Sua(type);
            Console.WriteLine("Nhập thời gian chạy : "); this.RunTime = Console.ReadLine();
        }
    }
}
