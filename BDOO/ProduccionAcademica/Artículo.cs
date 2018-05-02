using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDA_BDOOp1
{
    public class Articulo : ProduccionAcademica
    {
        public Articulo (string titulo) : base(titulo)
        {

        }
        public MedioDePublicacion publicadoen { get; set;}
            /*
        {
            get => default(MedioDePublicacion); 
            set
            {
            }
        }
        */
        public Autor Autor { get; set; }
        /*{
            get => default(Autor);
            set
            {
            }*/
    //}

        public DateTime FechaAprobacion { get; set; }
        /*{
            get => default(DateTime);
            set
            {
            }*/
        //}

        public short AñoPublicacion { get; set; }
        /*{
            get => default(int);
            set
            {
            }*/
        //}

        public String LugarExposion { get; set; }
        /*{
            get => default(String);
            set
            {
            }*/
        //}

        public DateTime FechaExposicion { get; set; }
        /*{
            get => default(DateTime);
            set
            {
            }*/
        //}

        
    }


}