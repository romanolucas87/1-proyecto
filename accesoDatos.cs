using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//agregar
using System.Data.OleDb;// agregar -- sirve para access y para SQL


namespace CustomCar
{
    class accesoDatos
    {
        OleDbConnection conexion;//lo usa para conectarse a la base de datos
        OleDbCommand comando;// query
        OleDbDataReader lector; //para hacer Get y Set
        DataTable tabla; //para leer la Tabla
        string cadenaConexion; //para setear la cadena de conexion el @.......

        public string pCadenaConexion
        {
            set { cadenaConexion = value; }
            get { return cadenaConexion; }
        }

        public OleDbDataReader pLector 
        {
            set { lector = value; }
            get { return lector; }

        }
        public DataTable pTabla
        {
            set { tabla = value; }
            get { return tabla; }
        }

        public accesoDatos()//METODO CONSTRUCTOR
        {
            conexion = new OleDbConnection();
            comando = new OleDbCommand();
            lector = null;
            tabla = new DataTable();
            cadenaConexion = "";
        }

        public accesoDatos(string cadenaConexion)
        {
            this.conexion = new OleDbConnection();
            this.comando = new OleDbCommand();
            this.tabla = new DataTable();
            this.lector = null;
            this.cadenaConexion = cadenaConexion;

        }
        private void conectar()//metodo privado para conectar la base de datos
        {
            conexion.ConnectionString = cadenaConexion; //la cadena de conexion que seteamos
            conexion.Open();//
            comando.Connection = conexion;//
            comando.CommandType = CommandType.Text;
        }

        public void desconectar()// metodo privado para desconectar la base de datos
        {
            conexion.Close();
            conexion.Dispose();//libera los recursos de la memoria en desuso

        }

        public DataTable  consultarTabla(string nombreTabla) //va a devolver un data table de la tabla que nombremos
        {
            this.conectar(); //llamamos a CONECTAR
            this.comando.CommandText = "Select * From " + nombreTabla;
            this.tabla.Load(comando.ExecuteReader());//ejecuta y carga tabla
            this.desconectar();//desconecta
          
            return this.tabla;//devuelve la tabla

        }

        public void leerTabla(string nombreTabla)
        {
            this.conectar();
            this.comando.CommandText = "Select * From " + nombreTabla;
            this.lector = comando.ExecuteReader();//ejecuta el select y lo guarda en el lector
            //this.desconectar();

        }

        public void actualizarBD(string consultaSQL)// el parametro va a ser la consulta que hagamos
        {
            this.conectar();
            this.comando.CommandText = consultaSQL;
            this.comando.ExecuteNonQuery();//ejecuta la consulta y devuelve el numero de filas
            this.desconectar();//desconecta

        }
    }
}
