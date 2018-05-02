using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDOO
{
    public class RevistaElectronica : Revista
    {
        public int URL { get; set; }
        /*{
            get => default(int);
            set
            {
            }
    }*/
    }

    public class RevistaImpresa : Revista
    {
    }
}