using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomCar
{
    public partial class Form1 : Form
    {
        //instanciar atributo de la calse acceso datos
        accesoDatos oDatos = new accesoDatos();
        const int tam = 200;
        productos[] ap = new productos[tam];
        
        
        int c;
        bool nuevo;

        public Form1()
        {
            InitializeComponent();
            c = 0;
            for (int i = 0; i < tam; i++)
            {
                ap[i] = null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            oDatos.pCadenaConexion = @"Provider=SQLNCLI11;Data Source=DESKTOP-68DQ98O;Integrated Security=SSPI;Initial Catalog=AUTOMOTRIZ_CUSTOM_CAR125";
            this.cargarLista("Productos");
            this.cargarCombo(dgProductos, "Productos");
            
        }

        private void cargarLista(string nombreTabla)
        {
            c = 0;
            //dgProductos.DataSource.ToString();
            lstProductos.Items.Clear();
            oDatos.leerTabla(nombreTabla);
            while(oDatos.pLector.Read())//no se puede liberar hasta que no se lean todos los registros
            {
                productos p = new productos();//se mapea desde la base de datos  a la clase  en el objeto????
                p.pId_Producto = oDatos.pLector.GetInt32(0);//lee la primer columna 
                p.pNombre_Producto = oDatos.pLector["nombre_producto"].ToString();
                p.pDescripcion_Producto = oDatos.pLector["descripcion_producto"].ToString();
                p.pId_Tipo_Producto = oDatos.pLector.GetInt32(3);
                p.pId_Marca = oDatos.pLector.GetInt32 (4);
                p.pPrecio_Producto = oDatos.pLector.GetDecimal (5);
                p.pStock_Minimo = oDatos.pLector.GetInt32(6);
                p.pStock_Actual = oDatos.pLector.GetInt32(7);

                ap[c] = p;
                c++;                
            }
            oDatos.pLector.Close();
            oDatos.desconectar();
            for (int i = 0; i < c; i++)
            {
                lstProductos.Items.Add(ap[i].toString());
                //ap[i].pId_Producto.ToString()
            }
            lstProductos.SelectedIndex = 0;
            

        }
        
        private void cargarCombo (DataGridView lista, string nombreTabla)
        {
            DataTable tabla = new DataTable();
            tabla = oDatos.consultarTabla(nombreTabla);
            dgProductos.DataSource = tabla;
            //lista.DataSource = tabla;
            //lista.v = tabla.Columns[0].ColumnName;
            //lista.DisplayMember = tabla.Columns[1].ColumnName;
            ////lista.DisplayMember = tabla.Columns[2].ColumnName;
            ////lista.DisplayMember = tabla.Columns[3].ColumnName;
            ////lista.DisplayMember = tabla.Columns[4].ColumnName;
            ////lista.DisplayMember = tabla.Columns[5].ColumnName;
            ////lista.Items.AddRange= tabla.


            ////lista.  = ComboBoxStyle.DropDownList;
            //lista.SelectedIndex = -1;
        }

        private void dgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
