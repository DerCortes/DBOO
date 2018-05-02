using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDA_BDOOp1
{
    
    public class Estudiante : Autor
    {
        public String NoControl { get; set; }
        public Estudiante (string nombre): base(nombre) { }
    }
}