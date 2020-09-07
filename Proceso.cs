using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;


namespace DPRN1_U3_A4_PIVM
{
    class Proceso
    {
        Menu menu = new Menu();

        private List<Articulo> listArticulos;
        private List<Ventas> listVentas;
        private List<ContenidoTransaccion> listContenidoTransaccion;

        private Articulo articulos;
        private Ventas ventas;
        private ContenidoTransaccion contenidoTransaccion;
        private Dato datoArticulos;
        private Dato datoVentas;
        private Dato datoContenidoTransaccion;

        public void SolicitarOpciones()
        {
            listVentas = new List<Ventas>();
            listArticulos = new List<Articulo>();
            listContenidoTransaccion = new List<ContenidoTransaccion>();

            int opcion;

            datoVentas = new Dato("Ventas.bd");
            datoArticulos = new Dato("Articulos.bd");
            datoContenidoTransaccion = new Dato("ContenidoTransaccion.db");

            do
            {
                do
                {
                    if (File.Exists("Ventas.bd") && File.Exists("Ventas.bd") && File.Exists("Ventas.bd"))
                    {
                        listVentas = datoVentas.deserializarVentas();
                        listArticulos = datoArticulos.deserializarArticulos();
                        listContenidoTransaccion = datoContenidoTransaccion.deserializarContenidoTransaccion();
                        Console.WriteLine("Hay Articulo ");
                    }
                    menu.Menu1();
                    Console.WriteLine("Ingresa opcion valida [1 -5]");
                    opcion = int.Parse(Console.ReadLine());
                    Console.Clear();

                    if (opcion < 1 || opcion > 5)
                    {
                        Console.WriteLine("Ingresa opcion valida [1 -5]");

                    }
                } while (opcion < 1 || opcion > 6);
                switch (opcion)
                {
                    case 1:
                        // Registro de Articulos
                        RegistroArticulo();

                        break;
                    case 2:
                        // Mostrar Articulos
                        MostrarArticulos();

                        break;
                    case 3:
                        // Caja
                        break;
                    case 4:
                        // Mostrar Ventas
                        break;
                    case 5:
                        // Salir
                        Console.WriteLine(" Gracias por su Compra");
                        Environment.Exit(0);
                        break;
                }

            } while (opcion != 5);
        }
        public void RegistroArticulo()
        {
            Console.WriteLine("  ████████████████████████████████████████████████████████████████████████████████████████████████████████████████████    ");
            Console.WriteLine("  ███                                                                                                              ███    ");
            Console.WriteLine("  ███                                           Caja de Tienda Deportiva                                           ███    ");
            Console.WriteLine("  ███                                                                                                              ███    ");
            Console.WriteLine("  ████████████████████████████████████████████████████████████████████████████████████████████████████████████████████    ");

            Articulo articulo = new Articulo();
            int id = ContadorArticulos() + 1;
            Console.WriteLine("id: " + id);
            articulo.IdArticulo = id;
            Console.Write("Descripcion: ");
            articulo.Descripcion = Console.ReadLine();
            Console.WriteLine("\nPrecio: ");
            articulo.Costo = int.Parse(Console.ReadLine());

            listArticulos.Add(articulo);
            datoArticulos.serializarArticulos(listArticulos);
            Console.WriteLine("\n Los datos fueron Guardados");
            Console.WriteLine("Presione una tecla");
            Console.ReadKey();
        }
        public void MostrarArticulos()
        {
            menu.Menu1();
            Console.WriteLine("\nListado de Articulos");
            foreach (Articulo b in listArticulos)
            {
                Console.WriteLine("Id: " + b.IdArticulo + " Descripcion: " + b.Descripcion + " Precio $" + b.Costo);
                Console.ReadKey();
            }
        }
        public void MostrarVenta(int Venta)
        {

            foreach (Ventas b in listVentas)
            {
                if (b.IdVenta == Venta)
                {

                }
            }
        }
        public void Caja()
        {
            Ventas venta = new Ventas();
            ContenidoTransaccion contenido = new ContenidoTransaccion();

            int folio = 0;
            int subtotal=0;

            folio = ContadorVenta() + 1;
            Console.WriteLine("Folio: " + folio);

            Console.WriteLine("*** TIENDA EN LINEA DEPORTIVO ***");
            MostrarArticulos();
            Console.WriteLine("Seleccione el Id. de un articulo:");
            int IdArticulo = int.Parse(Console.ReadLine());
            Console.WriteLine("Cantidad");
            int cantidad = int.Parse(Console.ReadLine());
            (string DescripcionArticulo,int costo) =BuscandoArticulo(IdArticulo);
            Console.WriteLine("Id.  Descripcion                     Costo.");
            Console.WriteLine(IdArticulo + " " + DescripcionArticulo + " " + cantidad  + " " +   costo);
            contenido.IdVenta = folio;
            contenido.Idarticulo = IdArticulo;
            contenido.Articulo = DescripcionArticulo;
            contenido.Costo = costo;
            contenido.Cantidad = cantidad;
            Console.WriteLine("Para Agregar al carrito Precione 1 o 2");
            int opcion = int.Parse(Console.ReadLine());

            do
            {
                if (opcion < 1 || opcion > 2)
                {
                    listContenidoTransaccion.Add(contenido);
                    subtotal = subtotal + costo;
                    datoContenidoTransaccion.serializarContenidoTransaccion(listContenidoTransaccion);
                    Console.WriteLine("\n Los datos fueron Guardados");

                }
            } while (opcion != 2);
            Console.WriteLine("Presione una tecla");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Id.  Descripcion                     Costo.");
            (DescripcionArticulo, cantidad, costo, IdArticulo ) = BuscandoContenido(folio);
            
            Console.WriteLine(IdArticulo + " " + DescripcionArticulo + " " + cantidad + " " + costo);
            //Costo
            Calulando(subtotal);
        }
        public void Calulando(int Subtotal)
        {
            int descuento = 0;
            //Compra menor $1000 no aplica descuento 0 %
            if (Subtotal < 1000)
            {
                descuento = 0;
            }
            //Compra mayor o igual que $1000 y menor o igual que $2500 – descuento 10 %
            if(Subtotal >= 1000 && Subtotal <= 2500)
            {
                descuento = 10;
            }
            //Compra mayor que $2500 y menor o igual que $5000 - descuento 15 %
            if (Subtotal >= 2500 && Subtotal <= 5000)
            {
                descuento = 15;
            }
            //Compra mayor que $5000 – descuento 20 %
            if (Subtotal > 5000)
            {
                descuento = 20;
            }
            Console.WriteLine(" Subtotal: "+ Subtotal);
            Console.WriteLine("Descuento: " + descuento);
            int total = Subtotal - (descuento / 100);
            Console.WriteLine("---------------");
            Console.WriteLine("    Total: ");
        }
        public int ContadorArticulos()
        {
            int ContadorArticulos = 0;
            foreach (Articulo b in listArticulos)
            {
                ContadorArticulos++;
               
            }
            return ContadorArticulos;
        }
        public int ContadorVenta() 
        {        
            int ContadorVenta = 0;
            foreach (Ventas b in listVentas)
            {
                ContadorVenta++;
            }
            return ContadorVenta; 
        }
        public int ContadorContenido()
        {
            int ContadorContenido = 0;
            foreach (ContenidoTransaccion b in listContenidoTransaccion)
            {
                ContadorContenido++;
            }
            return ContadorContenido;
        }

        public Tuple<string, int> BuscandoArticulo(int idArticulo)
        {
                
                String Descripcion = "";
                int Costo = 0;

            foreach (Articulo b in listArticulos)
            {

                if (b.IdArticulo == idArticulo)
                {
                    Descripcion =b.Descripcion;
                    Costo = b.Costo;
                }
            }
                return new Tuple<string, int>(Descripcion, Costo);

        }
        public Tuple<string, int, int, int> BuscandoContenido(int idVenta)
        {

            String Descripcion = "";
            int Cantidad = 0;
            int Costo = 0;
            int Idarticulo = 0;

            foreach (ContenidoTransaccion b in listContenidoTransaccion)
            {

                if (b.IdVenta == idVenta)
                {
                    Descripcion = b.Articulo;
                    Cantidad = b.Cantidad;
                    Costo = b.Costo;
                    Idarticulo = b.Idarticulo;
                    
                }
            }
            return new Tuple<string, int, int , int>(Descripcion, Cantidad, Costo, Idarticulo);

        }

    }
}

