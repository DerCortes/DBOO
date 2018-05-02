using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDA_BDOOp1
{
    public class Tesis : ProduccionAcademica
    {
        private const string Nivel = "ING";

        public Tesis (string titulo, Estudiante estudiante, Docente asesor):base(titulo)
        {
            Estudiante = estudiante;
            Asesor = asesor;
        }

        public Estudiante Estudiante { get; set; }
        //{
        //    get => default(Estudiante);
        //    set
        //    {
        //    }
        //}

        public Docente Asesor { get; set; }
        //{
        //    get => default(Docente);
        //    set
        //    {
        //    }
        //}
    }


}