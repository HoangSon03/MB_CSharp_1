using System;
using System.Collections.Generic;
using System.Text;

namespace Son_CSharp_Bai1
{
    public class Borrower
    {
        string userId;
        string userName;
        string address;

        public string UserId { get => userId; set => userId = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Address { get => address; set => address = value; }

        public Borrower() { }
        public Borrower(string userId, string userName, string address)
        {
            this.UserId = userId;
            this.UserName = userName;
            this.Address = address;
        }

        public void Nhap()
        {
            Console.WriteLine("Nhập BorrowerId :");this.UserId = Console.ReadLine();
            Console.WriteLine("Nhập BorrowerName :");this.UserName = Console.ReadLine();
            Console.WriteLine("Nhập BorrowerAddress :");this.Address = Console.ReadLine();
        }
        public void Xuat() {
            Console.WriteLine("BorrowerId :{0}", this.UserId);
            Console.WriteLine("BorrowerName :{0}", this.UserName);
            Console.WriteLine("BorrowerAddress :{0}", this.Address);
        }
    }
}
