using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    public class ValueChangedEventArgs : EventArgs
    {
        public int ExistingValue { get; set; }
        public int NewValue { get; set; }
    }
}
