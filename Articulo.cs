using System;
using System.Collections.Generic;
using System.Text;

namespace DPRN1_U3_A4_PIVM
{
    [Serializable()]
    public class Articulo
    {
        private int _idArticulo;
        private string _articulo;
        private int _costo;

        public int idArticulo { get => _idArticulo; set => _idArticulo = value; }
        public string articulo { get => _articulo; set => _articulo = value; }
        public int costo { get => _costo; set => costo = value; }
    }

}
