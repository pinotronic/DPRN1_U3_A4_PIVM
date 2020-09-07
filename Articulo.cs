using System;
using System.Collections.Generic;
using System.Text;

namespace DPRN1_U3_A4_PIVM
{
    [Serializable()]
    public class Articulo
    {
        private int _idArticulo;
        private string _descripcion;
        private int _costo;

        public int IdArticulo { get => _idArticulo; set => _idArticulo = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public int Costo { get => _costo; set => _costo = value; }
    }

}
