using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDOO
{
    public class Docente : Autor
    {
        public String NoEmpleado { set; get; }

        public Docente (String nombre)
            :base ( nombre)
        {
            Nombre = nombre;
        }
    }
}