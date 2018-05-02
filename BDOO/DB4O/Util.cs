
using System;
using System.IO;
using Db4objects.Db4o;
using Db4objects.Db4o.Ext;

namespace BDA_BDOOp1
{
    public class Util
    {
        /* public readonly static string YapFileName = Path.Combine(  
                               Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),   
                               "formula1.yap");  
        */
        
        private static IObjectContainer db;

        public readonly static string NombreArchivo = "D:\\Documentos\\Pre_dir\\UTIM\\8° Cuatrimestre\\2° Parcial\\bd\\Base de datos OO\\UTIM_PAcademica.dboo";
        public readonly static int ServerPort = 0xdb40;		
		public readonly static string ServerUser = "user";		
		public readonly static string ServerPassword = "password";

		public static void ListResult(IObjectSet result)
		{
			foreach (object item in result)
			{
                if (item.GetType() == typeof(Tesis))
                {
                    Tesis tesisFound = (Tesis)item;
                    Console.WriteLine("TESIS - "+tesisFound.Titulo);
                    Console.WriteLine("Asesor: "+tesisFound.Asesor.Nombre);
                    Console.WriteLine("Estudiante: " + tesisFound.Estudiante.Nombre);
                    Console.WriteLine("-------------");
                }             
			}
		}

		public static void ListRefreshedResult(IObjectContainer container, IObjectSet items, int depth)
		{
			Console.WriteLine(items.Count);
			foreach (object item in items)
			{	
				container.Ext().Refresh(item, depth);
				Console.WriteLine(item);
			}
		}
		
		
        public static void RetrieveAll(IObjectContainer db) 
		{
			IObjectSet result = db.QueryByExample(typeof(Object));
			ListResult(result);
		}
		
		public static void DeleteAll(IObjectContainer db) 
		{
			IObjectSet result = db.QueryByExample(typeof(Object));
			foreach (object item in result)
			{
				db.Delete(item);
			}
		}

        public static Tesis findByName(String nombreTesis)
        {
            db = Db4oFactory.OpenFile(NombreArchivo);
            Tesis find = new Tesis(nombreTesis, null, null);
            IObjectSet result = db.QueryByExample(find);
            if (result.Count != 0)
            {
                Tesis found = (Tesis)result.Next();
                db.Close();
                return found;
            }
            db.Close();
            return null;

        }
        
        public static void DeleteByObject(String nombreTesis)
        {
            try
            {
                db = Db4oFactory.OpenFile(NombreArchivo);
                Tesis oDelete = new Tesis(nombreTesis, null, null);
                IObjectSet result = db.QueryByExample(oDelete);
                if (result.Count!=0)
                {
                    Tesis found = (Tesis)result.Next();
                    db.Delete(found);
                    Console.WriteLine("Eliminación éxitosa");
                    RetrieveAll(db);
                }
                else
                {
                    Console.WriteLine("No se encontro la tesis");
                }
                db.Close();
            }
            catch (Db4oException e)
            {
                Console.WriteLine("Se produjo el siguiente error" + e.Message);
            }
            
        }

        public static void Actualizar(Tesis oUpdate)
        {
            try
            {
                db = Db4oFactory.OpenFile(NombreArchivo);
                db.Store(oUpdate);
                Console.WriteLine("Actualización exitosa");
                RetrieveAll(db);
                db.Close();
            }
            catch (Db4oException e)
            {
                Console.WriteLine("Se produjo el siguiente error" + e.Message);
            }
        }
        
        public static Boolean Guardar(Object oNuevo)
        {            
            try
            {
                db = Db4oFactory.OpenFile(NombreArchivo);
                db.Store(oNuevo);
                RetrieveAll(db);
                db.Close();                
            }
            catch (Db4oException e)
            {
                Console.WriteLine("Se produjo el siguiente error" + e.Message);
                return false;
            }           

            return true;
        }

        public static Boolean BDDisponible()
        {
            try
            {
                db = Db4oFactory.OpenFile(NombreArchivo);
                db.Close();
            }
            catch (Db4oException e)
            {
                Console.WriteLine("Se produjo el siguiente error" + e.Message);
               return false;
            }
            return true;
        }

        public static void MostrarTodosObjetos()
        {

            try
            {
                db = Db4oFactory.OpenFile(NombreArchivo);
                RetrieveAll(db);
                db.Close();
            }
            catch (Db4oException e)
            {
                Console.WriteLine("Se produjo el siguiente error" + e.Message);               
            }        
            
        }

    }
}
