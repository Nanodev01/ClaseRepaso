using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioClase8
{
    [Serializable]
    internal class Producto : ItemFactura
    {
        public int Stock
        {
            set; get;
        }
        public Producto(string discripcion) : base(discripcion)
        { }
        public override string ToString()
        {
            return Codigo + " " + Descripcion;
        }
    }
}
