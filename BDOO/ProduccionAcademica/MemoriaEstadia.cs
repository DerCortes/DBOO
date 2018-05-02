using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDA_BDOOp1
{
    public class MemoriaEstadia : ProduccionAcademica
    {
        public MemoriaEstadia(string titulo) : base(titulo)
        {

        }
        private const String Nivel = "TSU";

        public Estudiante Estudiante { get; set; }
       /* {
           // get => default(Estudiante);
           // set
            {
            }
        }*/
    }
}