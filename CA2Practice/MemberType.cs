using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2Practice
{
    class MemberType
    {
        //props
        string MemType;

        //ctors
        public MemberType(string memType)
        {
            this.MemType = memType;
        }

        //Methods
        public override string ToString()
        {
            return (MemType);
        }
    }
}
