using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2Practice
{
    class Member
    {
        //Props
        public string Name;
        public int Phone;
        public string Address;
        public MemberType Type;
        public int YearJoined;

        //Ctors
        public Member(string name, int phone, string address, MemberType type, int yearJoined)
        {
            this.Name = name;
            this.Phone = phone;
            this.Address = address;
            this.Type = type;
            this.YearJoined = yearJoined;
        }

        public override string ToString()
        {
            return (this.Name);
        }
    }
}
