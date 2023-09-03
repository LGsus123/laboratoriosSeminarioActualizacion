using System;
using Prj_AMTH_DemoEFDBToCode.Model;
using System.Linq;

namespace Prj_AMTH_DemoEFDBToCode
{
    class Program
    {
        public static DbDemoSesion03ParteBContext context = new DbDemoSesion03ParteBContext();
        static void Main(string[] args)
        {
            MostrarModeloPorPantalla();
        }
        private static void MostrarModeloPorPantalla()
        {
            var query = from s in context.Stocks
                        join p in context.Products on s.Product equals p
                        join b in context.Brands on p.Brand equals b
                        join c in context.Categories on p.Category equals c
                        select new { Store = s.StoreCode, Producto = p.ProductName, Marca = b.BrandName, Categoria = c.CategoryName };
            var report = query.ToList();
            foreach ( var record in report ) {
                Console.WriteLine( "Store: " + record.Store + " Producto: " + record.Producto + " Marca: " + record.Marca + " Categoria: " + record.Categoria );
            }
        }
    }
}