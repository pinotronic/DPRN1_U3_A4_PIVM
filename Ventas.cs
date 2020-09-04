using System;
using System.Collections.Generic;
using System.Text;

namespace DPRN1_U3_A4_PIVM
{
    [Serializable()]
    public class Ventas
    {
        private int _idVenta;
        private int _numArticulos;
        private DateTime _fecha;
        private int _montoFactura;

        public int idVenta { get => _idVenta; set => _idVenta = value; }
        public int numArticulos { get => _numArticulos; set => _numArticulos = value; }
        public DateTime fecha { get => _fecha; set => _fecha = value; }
        private int montoFactura { get => _montoFactura; set => _montoFactura = value; }

    }

}
