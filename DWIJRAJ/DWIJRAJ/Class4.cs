using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace DWIJRAJ.CustomDelegateEvent
{
        class Class4
        {
            public event MyDelegate OnPropertyChanged;

            public string Propert
            {
                get { return Propert; }
                set 
                { 
                  //  Propert = value;
                    OnPropertyChanged("Dwijraj's Delegate");
                }
            }

            public delegate void MyDelegate(string message);

           /* public void StartDelegate()
            {
                //delegate is a list of functions that run simultaneously 
                MyDelegate m = new MyDelegate(Method1);
                m += Method2;//Adding another method to delgate
                m += Method3;//Adding methods to delegate
                m("Hello"); //Calling Delegate
            } */
            void Method1(string a)
            {
                MessageBox.Show(a);
            }
            void Method2(string b)
            {
                MessageBox.Show(b);
            }

            void Method3(string b)
            {
                MessageBox.Show(b);
            } 
           
        }
}
