using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDOO
{
    
    public class Estudiante : Autor
    {
        public String NoControl { get; set; }
        public Estudiante (string nombre): base(nombre) { }
    }
}