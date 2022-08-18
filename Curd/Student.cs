using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Curd
{
    public class Student
    {
        public String Name { set; get; }
        public String Email { set; get; }
        public String RegNo { set; get; }
        public String Address { set; get; }
        public  int Id { set; get; }


        public Student(string name, string email,string regNo, string address)
        {
            this.Name = name;
            this.Email = email;
            this.Address = address;
            this.RegNo = regNo;
        }

        public Student(int id, string name, string email, string regNo, string address):this(name, email, regNo, address)
        {
            this.Id = id;
        }

    }
}