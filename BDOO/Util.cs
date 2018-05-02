
using System;
using System.IO;
using Db4objects.Db4o;
using Db4objects.Db4o.Ext;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BDOO
{
    public class Util
    {
        /* public readonly static string YapFileName = Path.Combine(  
                               Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),   
                               "formula1.yap");  
        */
        
        private static IObjectContainer db;

        public readonly static string NombreArchivo = "C:\\Users\\Derom\\Downloads\\BDOO\\UTIM_PAcademica.dboo";
        public readonly static int ServerPort = 0xdb40;		
		public readonly static string ServerUser = "user";		
		public readonly static string ServerPassword = "password";

		public static List<Tesis> ListResult(IObjectSet result)
		{
            List<Tesis> lstTesis = new List<Tesis>();
			foreach (object item in result)
			{
                if (item.GetType() == typeof(Tesis))
                {
                    Tesis tesisFound = (Tesis)item;
                    lstTesis.Add(tesisFound);
                }             
			}
            return lstTesis;
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
		
		
        public static List<Tesis> RetrieveAll(IObjectContainer db) 
		{
			IObjectSet result = db.QueryByExample(typeof(Object));
			List<Tesis> lstTesis = ListResult(result);
            return lstTesis;
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
                    MessageBox.Show("Eliminación éxitosa");
                }
                else
                {
                    Console.WriteLine("No se encontro la tesis");
                    MessageBox.Show("No se encontro la tesis");
                }
                db.Close();
            }
            catch (Db4oException e)
            {
                Console.WriteLine("Se produjo el siguiente error" + e.Message);
                MessageBox.Show("Se produjo el siguiente error" + e.Message);
            }
            
        }

        public static void Actualizar(Tesis oUpdate)
        {
            try
            {
                db = Db4oFactory.OpenFile(NombreArchivo);
                db.Store(oUpdate);
                Console.WriteLine("Actualización exitosa");
                MessageBox.Show("Actualización exitosa");
                RetrieveAll(db);
                db.Close();
            }
            catch (Db4oException e)
            {
                MessageBox.Show("Se produjo el siguiente error" + e.Message);
                Console.WriteLine("Se produjo el siguiente error" + e.Message);
            }
        }
        
        public static Boolean Guardar(Object oNuevo)
        {            
            try
            {
                db = Db4oFactory.OpenFile(NombreArchivo);
                db.Store(oNuevo);
                db.Close();
                MessageBox.Show(" El registro fue guardado con exito");            
            }
            catch (Db4oException e)
            {
                MessageBox.Show("Se produjo el siguiente error" + e.Message);
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

        public static List<Tesis> MostrarTodosObjetos()
        {

            try
            {
                db = Db4oFactory.OpenFile(NombreArchivo);
                List<Tesis> lstTesis = RetrieveAll(db);
                db.Close();
                return lstTesis;
            }
            catch (Db4oException e)
            {
                Console.WriteLine("Se produjo el siguiente error" + e.Message);
                return null;
            }        
            
        }

    }
}
