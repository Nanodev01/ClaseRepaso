//
//
//  Generated by StarUML(tm) C# Add-In
//
//  @ Project : Untitled
//  @ File Name : ItemFactura.cs
//  @ Date : 10/10/2024
//  @ Author : 
//
//

using System;

namespace ejercicioClase8
{
    [Serializable]
    public abstract class ItemFactura
    {

        public int Codigo
        { set; get; }
        public double Precio
        {
            set; get;
        }
        public string Descripcion
        {set;get;}
        public ItemFactura(string descripcion)
        {
            Descripcion = descripcion;
            Codigo = 1;
            Precio = 20;
        }
    }

}
