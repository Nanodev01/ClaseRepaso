using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicioClase8
{
    [Serializable]
    internal class OrdenDeObra
    {
        private DateTime fecha;
        private string[] items;
        public readonly string RazonSocial;
        public readonly double total; 
        public OrdenDeObra(string razon, string[] items,double total)
        {
            fecha = DateTime.Now;
            this.items = items;
            RazonSocial = razon;
            this.total = total;
        }
    }
}
