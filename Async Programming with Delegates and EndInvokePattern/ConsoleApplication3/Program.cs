using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication3
{
    class Program
    {
        public delegate string mymethod();
        static mymethod inv;
        static Boolean flag = true;
        static void Main(string[] args)
        {
         
            inv= new mymethod(Print);
            //inv += Print2;
            IAsyncResult tag =inv.BeginInvoke(new AsyncCallback(Callback),null);
            Console.WriteLine("I am Back 1st");
           // Thread.Sleep(5000);
            Console.WriteLine("I am Back 2");
            Console.WriteLine("I am Back 3");

            while (flag)
            {
                Console.WriteLine("I am Back 3");
            }
            Console.Read();
          
           
        }
        public static String Print()
        {
            Console.Write("I am from print1 start \n");
            Thread.Sleep(6000);
            Console.Write("I am from print \n");

            return "Completed";
        }
        public static void Callback(IAsyncResult t)
        {
            string m = inv.EndInvoke(t);
            Console.WriteLine("I am Back After AsyncTask Over");
            flag = false;
            
        }
        
    }
}
