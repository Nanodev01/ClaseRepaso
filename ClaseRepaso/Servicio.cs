using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioClase8
{
    [Serializable]
    internal class Servicio: ItemFactura
    {
        private int tiempo;
        public Servicio (string descrip, int tiempo):base(descrip)
        {
            this.tiempo = tiempo;
        }
        public override string ToString()
        {
            return Codigo + " " + Descripcion;
        }
            

    }
}
