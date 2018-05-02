using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDOO
{
    public class Patente : ProduccionAcademica
    {
        public Patente(string titulo) : base(titulo)
        {

        }
        public String NoRegistro { get; set; }
    }
}