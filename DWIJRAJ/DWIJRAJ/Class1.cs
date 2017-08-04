using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MySpace
{

    class Class1
    {
        public int a;
        public int b;
        public Class1()
        {
            this.a = 10;
            this.b = 11;
        }
        public string Show()
        {
            return this.a + "" + this.b;
        }
    }
    class Class2 : Class1
    {
        public int a;
        public int b;

        public Class2(int a,int b)
        {
            
            this.a = a;
            this.b = 23;
        }
    }   
}
