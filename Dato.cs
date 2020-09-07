using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DPRN1_U3_A4_PIVM
{
     class Dato
    {
        private String ruta;
        public Dato(String ruta)
        {
            this.ruta = ruta;
        }
        public void serializarArticulos(List<Articulo> lista)
        {
            Stream flujo = File.Open(ruta, FileMode.Create);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(flujo, lista);
            flujo.Close();
        }
        public void serializarVentas(List<Ventas> lista)
        {
            Stream flujo = File.Open(ruta, FileMode.Create);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(flujo, lista);
            flujo.Close();
        }
        public void serializarContenidoTransaccion(List<ContenidoTransaccion> lista)
        {
            Stream flujo = File.Open(ruta, FileMode.Create);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(flujo, lista);
            flujo.Close();
        }
        public List<Articulo> deserializarArticulos()
        {
            Stream flujo = File.Open(ruta, FileMode.Open);
            BinaryFormatter bin = new BinaryFormatter();
            List<Articulo> lista = (List<Articulo>)bin.Deserialize(flujo);
            flujo.Close();
            return lista;
        }
        public List<Ventas> deserializarVentas()
        {
            Stream flujo = File.Open(ruta, FileMode.Open);
            BinaryFormatter bin = new BinaryFormatter();
            List<Ventas> lista = (List<Ventas>)bin.Deserialize(flujo);
            flujo.Close();
            return lista;
        }
        public List<ContenidoTransaccion> deserializarContenidoTransaccion()
        {
            Stream flujo = File.Open(ruta, FileMode.Open);
            BinaryFormatter bin = new BinaryFormatter();
            List<ContenidoTransaccion> lista = (List<ContenidoTransaccion>)bin.Deserialize(flujo);
            flujo.Close();
            return lista;
        }
    }
}

