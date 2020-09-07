using System;
using System.Collections.Generic;
using System.Text;

namespace DPRN1_U3_A4_PIVM
{
    [Serializable()]
    public class ContenidoTransaccion
    {
        private int _idVenta;
        private int _cantidad;
        private int _idarticulo;
        private string _articulo;
        private int _costo;

        public int IdVenta { get => _idVenta; set => _idVenta = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public int Idarticulo { get => _idarticulo; set => _idarticulo = value; }
        public string Articulo { get => _articulo; set => _articulo = value; }
        public int Costo { get => _costo; set => _costo = value; }
    }

}
