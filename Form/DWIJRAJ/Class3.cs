using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DWIJRAJ.Event
{
    
    class Class3
    {

        public event EventHandler OnPropertyChange;
        public string name 
        {
            get
            {
                return name;
            }
            set
            {
                name=value;
                OnPropertyChange(this,new EventArgs());
            }
        }

    }
}
