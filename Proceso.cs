using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;


namespace DPRN1_U3_A4_PIVM
{
 class Proceso
    {
        Menu menu = new Menu();

        private List<Articulos> listArticulos;
        private List<Ventas> listVentas;
        private List<ContenidoTransaccion> listContenidoTransaccion;

        private Articulos articulos;
        private Ventas ventas;
        private ContenidoTransaccion contenidoTransaccion;
        private Dato dato;

        public void SolicitarOpciones()
        {
            int opcion;
            datoVenta = new Dato("Ventas.bd");
            datoArticulo = new Dato("Articulos.bd");
            datoContenidoTransaccion = new Dato("ContenidoTransaccion.db");
            
            do
            {
                do
                {
                    if (File.Exists("Ventas.bd"))
                    {
                        listVentas = datoVenta.deserializarVentas();
                        listArticulos = datoArticulo.deserializarArticulos();
                        listContenidoTransaccion = datoContenidoTransaccion.deserializarContenidoTransaccion();
                        Console.WriteLine("Hay Articulos ");
                    }
                    Console.WriteLine("
1. Registro de Articulos");
                    Console.WriteLine("2. Mostrar Articulos");
                    Console.WriteLine("3. Caja");
                    Console.WriteLine("4. Mostrar Ventas");
                    Console.WriteLine("5. Salir");
                    Console.WriteLine("Favor de seleccionar una opcion del 1 - 5");
                    opcion = int.Parse(Console.ReadLine());
                    Console.Clear;
                    
                    if(opcion < 1 || opcion >5)
                    {
                    	Console.WriteLine("Ingresa opcion valida [1 -5]");
                    	
                    }
                }while(opcion <1 || opcion > 6);
                switch (opcion)
                {
                	case 1:
                	// Registro de Articulos
                	break;
                	case 2:
                	// Mostrar Articulos
                	break;
                	case 3:
                	// Caja
                	break;
                	case 4:
                	// Mostrar Ventas
                	break;
                	case 5:
                	// Salir
                	Console.WriteLine("
 Gracias por su Compra");
                	Environment.Exir(0);
                	break;
                }
               
           }while (opcion != 5);
        }
        public void RegistroArticulo()
        {
        	menu.menu();
        	Articulo articulo = new Articulo();
        	
        	Console.WriteLine("id");
        	
        	
        }
    }
}

