using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejercicioClase8
{
    [Serializable]
    class Sistema
    {


        public List<ItemFactura> consumibles = new List<ItemFactura>();
        public List<OrdenDeObra> ordenesGeneradas = new List<OrdenDeObra>();

        public void AgregarConsumibles(string[] campos)
        {
            try
            {
                ItemFactura consumibles;
                if (campos.Length != 5)
                    throw new Exception("El elemento no contiene toda la informacion");

                if (campos[0] == "s" || campos[0] == "S")
                {
                    consumibles = new Servicio(campos[2], 0);
                    consumibles.Codigo = Convert.ToInt32(campos[3]);
                    consumibles.Precio = Convert.ToDouble(campos[4]);

                }

            }
            catch (FormatException fs)
            {
                throw new Exception("ups algo salio mal");
            }
            
        }
        public List<ItemFactura> verFactura()
        {

            return null;
        }

        //sistema tiene que manejar todo el tema de los archivos, pasar todo desde el formulario a aca 

    }
}
