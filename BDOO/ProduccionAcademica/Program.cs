using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDA_BDOOp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductoTesis.Asesor.set(new Docente("Carmen Salinas"));

            //Tesis ProductoTesis = new Tesis("Diputados pluriniminales", new Estudiante("Miguel Mancera"), new Docente ("Carmen Salinas"));
            /*Tesis ProductoTesis = new Tesis("Programa de Prueba", new Estudiante("Jose Eduardo"), new Docente("Jonathan Cisneros"));
            Console.WriteLine("Titulo Tesis:" + ProductoTesis.Titulo);
            Console.WriteLine("Asesor Tesis:" + ProductoTesis.Asesor.Nombre);
            Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));

            if (Util.Guardar(ProductoTesis)) Console.WriteLine("Registro guardado");*/

            int consola = 0;
            do
            {
                Console.WriteLine("--Menú--");
                Console.WriteLine("1-.Alta");
                Console.WriteLine("2.-Actualización");
                Console.WriteLine("3.-Eliminación");
                Console.WriteLine("4.-Mostrar todo");
                Console.WriteLine("5.-Salir");
                String data = Console.ReadLine();
                consola = int.Parse(data);
                switch (consola)
                {
                    case 1:
                        Console.WriteLine("----Registro de tesis----");
                        Console.WriteLine("Escribe el nombre del estudiante");
                        String nombreEstudiante = Console.ReadLine();
                        Console.WriteLine("Escribe el nombre del asesor");
                        String nombreAsesor = Console.ReadLine();
                        Console.WriteLine("Escribe el nombre de la tesis");
                        String nombreTesisR = Console.ReadLine();
                        Util.Guardar(new Tesis(nombreTesisR, new Estudiante(nombreEstudiante), new Docente(nombreAsesor)));

                        break;
                    case 2:
                        Console.WriteLine("Escribe el nombre de la tesis");
                        String nombreTesisU = Console.ReadLine();
                        Tesis findTesis = Util.findByName(nombreTesisU);
                        if (findTesis != null)
                        {
                            Console.WriteLine("Actualización de la tesis " + findTesis.Titulo);
                            Console.WriteLine("Nombre de estudiante actual " + findTesis.Estudiante.Nombre);
                            Console.WriteLine("Escribe el nuevo nombre del estudiante");
                            findTesis.Estudiante.Nombre = Console.ReadLine();
                            Console.WriteLine("Nombre del asesor actual " + findTesis.Asesor.Nombre);
                            Console.WriteLine("Escribe el nuevo nombre del asesor");
                            findTesis.Asesor.Nombre = Console.ReadLine();
                            Util.Actualizar(findTesis);
                        }
                        else
                        {
                            Console.WriteLine("No se encontro la tesis");
                        }
                       
                        break;
                    case 3:
                        Console.WriteLine("Escribe el nombre de la Tesis");
                        String nombreTesis = Console.ReadLine();
                        if (Util.BDDisponible()) Util.DeleteByObject(nombreTesis);
                        break;
                    case 4:
                        Console.WriteLine("Listado de Tesis");
                        if (Util.BDDisponible()) Util.MostrarTodosObjetos();
                        break;
                    default:
                        break;
                }
            }
            while (consola != 5);
            Console.ReadLine();

            
            

        }
    }
}
