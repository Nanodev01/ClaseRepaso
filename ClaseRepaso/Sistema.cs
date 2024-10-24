using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioClase8
{
    [Serializable]
    internal class Sistema
    {
        public List<ItemFactura> consumibles = new List<ItemFactura>();
        public List<OrdenDeObra> ordenesGeneradas = new List<OrdenDeObra>();
    }
}
