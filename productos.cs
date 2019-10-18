using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCar
{
    class productos
    {
        private int id_producto;
        private string nombre_producto;
        private string descripcion_producto;
        private int id_tipo_producto;
        private int id_marca;
        private decimal precio_producto;
        private int stock_minimo;
        private int stock_actual;

        public int pId_Producto
        {
            set { id_producto = value;}
            get { return id_producto; }
        }
        public string pNombre_Producto
        {
            set { nombre_producto = value; }
            get { return nombre_producto;}
        }
        public string pDescripcion_Producto
        {
            set { descripcion_producto = value;}
            get { return descripcion_producto;}
        }

        public int pId_Tipo_Producto
        {
            set { id_tipo_producto = value;}
            get { return id_tipo_producto;}
        }
        public int pId_Marca
        {
            set { id_marca = value;}
            get { return id_marca; }            
        }        

        public decimal pPrecio_Producto
        {
            set { precio_producto = value;}
            get { return precio_producto;}
        }

        public int pStock_Actual
        {
            set { stock_actual = value;}
            get { return stock_actual;}
        }

        public int pStock_Minimo
        {
            set { stock_minimo = value;}
            get { return stock_minimo;}
        }

        public productos ()
        {
            id_producto = 0;
            nombre_producto = string.Empty;
            descripcion_producto = string.Empty; 
            id_tipo_producto = 0;
            id_marca = 0;
            precio_producto = 0;
            stock_minimo = 0;
            stock_actual = 0;

        }
        public productos(int id_producto, string nombre_producto, string descripcion_producto, int id_tipo_producto, int id_marca, decimal precio_producto, int stock_actual, int stock_minimo )
        {
            this.id_producto = id_producto;
            this.nombre_producto = nombre_producto;
            this.descripcion_producto = descripcion_producto;
            this.id_tipo_producto = id_tipo_producto;
            this.id_marca = id_marca;
            this.precio_producto = precio_producto;
            this.stock_actual = stock_actual;
            this.stock_minimo = stock_minimo;
        }

        public string toString()
        {
            return "cod " + id_producto + " - " + nombre_producto + " - " + "$ " + precio_producto; 
            //     //return "Codigo Producto: " + id_producto + "\n" +
            //     //"Nombre Producto" + nombre_producto + "\n" +
            //     //"Descripcion del Producto" + descripcion_producto + "\n" +
            //     //"Codigo tipo Producto" + id_tipo_producto + "\n" +
            //     //"Codigo Marca" + id_marca + "\n" +
            //     //"Precio $" + precio_producto + "\n" +
            //     //"Stock Minimo" + stock_minimo + "\n" +
            //     //"Stock Actual" + stock_actual;

       //     return "Codigo Producto: " + id_producto + "Nombre Producto" + nombre_producto + "Descripcion del Producto" + descripcion_producto +  "Codigo tipo Producto" + id_tipo_producto +
       //"Codigo Marca" + id_marca +
       //"Precio $" + precio_producto +
       //"Stock Minimo" + stock_minimo +
       //"Stock Actual" + stock_actual;
        }

}
}
