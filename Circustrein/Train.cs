using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circustrein
{
    internal class Train
    {
        public Train(List<Wagon> wagonList)
        {
            this.WagonList = wagonList;
        }

        public List<Wagon> WagonList { get; set; }
    }
}
