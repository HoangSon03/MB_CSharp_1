using System;
using System.Collections.Generic;
using System.Text;

namespace Son_CSharp_Bai1
{
    public class Borrower
    {
        int userId;
        string userName;
        string address;

        public int UserId { get => userId; set => userId = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Address { get => address; set => address = value; }

        public Borrower() { }
        public Borrower(int userId, string userName, string address)
        {
            this.UserId = userId;
            this.UserName = userName;
            this.Address = address;
        }

        public void Nhap(int id )
        {
            this.UserId = id;
            Console.WriteLine("Nhập BorrowerName :");this.UserName = Console.ReadLine().ToUpper();
            Console.WriteLine("Nhập BorrowerAddress :");this.Address = Console.ReadLine();
        }
        public void Xuat() {
            Console.WriteLine("BorrowerId :{0}", this.UserId);
            Console.WriteLine("BorrowerName :{0}", this.UserName);
            Console.WriteLine("BorrowerAddress :{0}", this.Address);
            Console.WriteLine("-----------------------");
        }
    }
}
