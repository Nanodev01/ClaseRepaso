﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejercicioClase8
{
    [Serializable]
    internal class Sistema
    {


        private List<ItemFactura> consumibles = new List<ItemFactura>();
        private List<OrdenDeObra> ordenesGeneradas = new List<OrdenDeObra>();

        public void AgregarConsumibles(string[] campos)
        {
            try
            {
                ItemFactura consumibles;
                if (campos.Length != 5)
                    throw new Exception("El elemento no contiene toda la informacion");

                if (campos[0] == "s" || campos[0] == "S")  
                    consumibles = new Servicio(campos[2]);
                    consumibles.Codigo= Convert.ToInt32(campos[3]);
                    consumibles.Precio = campos[4];

                }
                    


            }
            catch (FormatException fs)
            {
                throw new Exception("ups algo salio mal");
            }
            
        }
        public List<ItemFactura> verFactura()
        { 
            List<Itemfactura>
        }

        //sistema tiene que manejar todo el tema de los archivos, pasar todo desde el formulario a aca 

    }
}
