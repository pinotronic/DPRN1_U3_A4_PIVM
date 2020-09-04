using System;
using System.Collections.Generic;
using System.Text;

namespace DPRN1_U3_A4_PIVM
{
    [Serializable()]
    public class ContenidoTransaccion
    {
        private int _idVenta;
        private int _articulo;
        private int _costo;

        public int idVenta { get => _idVenta; set => _idVenta = value; }
        public int articulo { get => _articulo; set => _articulo = value; }
        public int costo { get => _costo; set => _costo; }
    }

}
