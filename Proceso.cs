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
                    if (File.Exists("Ventas.bd"))
                    {
                        listVentas = datoVentas.deserializarVentas();
                        Console.WriteLine("Hay AVenta ");
                    }
                    if (File.Exists("Articulos.bd"))
                    {
                        listArticulos = datoArticulos.deserializarArticulos();
                        Console.WriteLine("Hay Articulo ");
                    }
                    if (File.Exists("ContenidoTransaccion.db"))
                    {
                        listContenidoTransaccion = datoContenidoTransaccion.deserializarContenidoTransaccion();
                        Console.WriteLine("Hay Contenido ");
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
                        Console.Clear();
                        Caja();
                        menu.Menu2();
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
            menu.Menu2();
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
            menu.Menu2();
            Console.WriteLine("\nListado de Articulos");
            foreach (Articulo b in listArticulos)
            {
                Console.WriteLine("Id: " + b.IdArticulo + " Descripcion: " + b.Descripcion + " Precio $" + b.Costo);

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
            //Inicio Caja
            Ventas venta = new Ventas();
            ContenidoTransaccion contenido = new ContenidoTransaccion();

            int folio = 0;
            int subtotal=0;
            venta.IdVenta = folio;

            folio = ContadorVenta() + 1;
            Console.WriteLine("Folio: " + folio);

            Console.WriteLine("                               *** TIENDA EN LINEA DEPORTIVO ***");
            // Mostrar Articulos

            MostrarArticulos();

            // Seleccion Articulos
            Console.WriteLine("\nSeleccione el Id. de un articulo:");
            int IdArticulo = int.Parse(Console.ReadLine());

            Console.WriteLine("Cantidad");
            int cantidad = int.Parse(Console.ReadLine());

            (string DescripcionArticulo,int costo) = BuscandoArticulo(IdArticulo);

            int costoSuma = costo * cantidad;

            Console.WriteLine("Id.  Descripcion                   Cantidad       Costo.");
            Console.WriteLine(IdArticulo + " " + DescripcionArticulo + "                        " + cantidad  + "         " + costoSuma);

            contenido.IdVenta = folio;
            contenido.Idarticulo = IdArticulo;
            contenido.Articulo = DescripcionArticulo;
            contenido.Costo = costoSuma;
            contenido.Cantidad = cantidad;
            
            Console.WriteLine("\nPara Agregar al carrito Precione 1 o 2");
            int opcion = int.Parse(Console.ReadLine());

            do
            {
                if (opcion == 1 )
                {
                    listContenidoTransaccion.Add(contenido);
                    subtotal = subtotal + costo;
                    datoContenidoTransaccion.serializarContenidoTransaccion(listContenidoTransaccion);
                    Console.WriteLine("\n Los datos fueron Guardados");

                }
            } while (opcion < 1 || opcion > 2);

            Console.WriteLine("Presione una tecla");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Id.   Descripcion                       Cantidad         Costo.");
            int contador=0;
            
            (DescripcionArticulo, cantidad, costo, IdArticulo , subtotal, contador) = BuscandoContenido(folio);
                         
          //Costo
            Console.WriteLine("\nPara cobrar Selecciona  1 o 2");
            opcion = int.Parse(Console.ReadLine());

            do
            {
                if (opcion == 1)
                {
                Calulando(subtotal);
                    venta.NumArticulos = contador;
                    listVentas.Add(ventas);
                    subtotal = subtotal + costo;
                    datoVentas.serializarVentas(listVentas);
                    Console.WriteLine("\n Los datos fueron Guardados");
                }
                else
                {
                    Console.Clear();
                Caja();
                }
            } while (opcion < 1 || opcion > 2);

        



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
            Console.WriteLine("    Total: " + total);

            Console.WriteLine("Gracias por su compra");
            Console.ReadKey();
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
        public Tuple<string, int, int, int, int,int> BuscandoContenido(int idVenta)
        {

            String Descripcion = "";
            int Cantidad = 0;
            int Costo = 0;
            int Idarticulo = 0;
            int SubTotal = 0;
            int Contador = 0;

            foreach (ContenidoTransaccion b in listContenidoTransaccion)
            {

                if (b.IdVenta == idVenta)
                {
                    Descripcion = b.Articulo;
                    Cantidad = b.Cantidad;
                    Costo = b.Costo;
                    Idarticulo = b.Idarticulo;
                    Console.WriteLine(idVenta + "  " + Descripcion + "                    " + Cantidad + "      " + Costo);
                    SubTotal = SubTotal + Costo;
                    Contador = Contador + 1;
                }
            }
            return new Tuple<string, int, int , int, int,int>(Descripcion, Cantidad, Costo, Idarticulo, SubTotal,Contador);

        }

    }
}

