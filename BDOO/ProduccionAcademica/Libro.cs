using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDA_BDOOp1
{
    public class Libro : ProduccionAcademica
    {
        public Libro(string titulo) : base(titulo)
        {

        }
        public Autor Autor { get; set; }
        //{
        //    get => default(Autor);
        //    set
        //    {
        //    }
        //}

        public int ISBN { get; set; }
        //{
        //    get => default(int);
        //    set
        //    {
        //    }
        //}
    }
}