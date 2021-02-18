using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using Ejercicio_06_POO_Server1.addNeg;

namespace Ejercicio_06_POO_Server1.addData
{
    public class UsuarioDAO
    {
        MySqlConnection conex = new MySqlConnection();

       public void conexion()
        {
                //conex.ConnectionString = "server=localhost; database=prograweb2; user=root; pwd=oswaldo4050";
                //conex.Open();   
        }

        public List<addNeg.NegUsuario> ObtenerUsuarios()
        {
            /// CREAR LA CONEXIÓN, CONFIGURAR Y ABRIRLA
            MySqlConnection conex = new MySqlConnection();
            conex.ConnectionString = "server=localhost; database=prograweb2; user=root; pwd=root";
            conex.Open();
           
            //LISTA USUARIOS
            List<addNeg.NegUsuario> usuarios = new List<addNeg.NegUsuario>();

            
            string strSQL = "select * from usuarios;";
            MySqlCommand comando = new MySqlCommand(strSQL, conex);
            MySqlDataReader dr = comando.ExecuteReader();
            while (dr.Read())
            {
                addNeg.NegUsuario x = new addNeg.NegUsuario(dr.GetInt32("idUsuarios"),dr.GetString("Nombre"),dr.GetInt32("Edad"),dr.GetString("NumeroTelefono"),dr.GetString("Email"));
                
                usuarios.Add(x);
            }
            comando.Dispose();

            /// FINALIZAMOS LA CONEXION CERRAMOS TODO
            /// 

            conex.Close();
           
            return usuarios;
        }

        public bool Insertar(NegUsuario objUser) {
            //CREAR LA CONEXIÓN, CONFIGURAR Y ABRIR
            MySqlConnection conex = new MySqlConnection();
            conex.ConnectionString = "server=localhost; database=prograweb2; user=root; pwd=root";
            conex.Open();
            //Agregar el registro a la BD
            string strSQL = "insert into usuarios (Nombre,Edad,NumeroTelefono,Email) values (@Nombre,@Edad,@NumeroTelefono,@Email);";
            MySqlCommand comando = new MySqlCommand(strSQL, conex);
            comando.Parameters.AddWithValue("Nombre",objUser.Nombre);
            comando.Parameters.AddWithValue("Edad", objUser.edad);
            comando.Parameters.AddWithValue("NumeroTelefono", objUser.telefono);
            comando.Parameters.AddWithValue("Email", objUser.correo);
            comando.ExecuteNonQuery();

            //Finalización de la conexión
            comando.Dispose();
            conex.Close();
            conex.Dispose();

            return true;
        }

        public bool Editar(NegUsuario objUser) {
            /// CREAR LA CONEXIÓN, CONFIGURAR Y ABRIRLA
            MySqlConnection cn = new MySqlConnection();
            cn.ConnectionString = cn.ConnectionString = "server=localhost; database=prograweb2; user=root; pwd=root; ";
            cn.Open();

            /// AGREGAR EL REGISTRO A LA BASE DE DATOS
            string strSQL = "update usuarios set Nombre = @Nombre,Edad=@Edad,NumeroTelefono=@NumeroTelefono,Email=@Email " +
                "where idUsuarios=@idUsuarios;";
            MySqlCommand comando = new MySqlCommand(strSQL, cn);
            comando.Parameters.AddWithValue("idUsuarios", objUser.idUsuario);
            comando.Parameters.AddWithValue("Nombre", objUser.Nombre);
            comando.Parameters.AddWithValue("Edad", objUser.edad);
            comando.Parameters.AddWithValue("NumeroTelefono", objUser.telefono);
            comando.Parameters.AddWithValue("Email", objUser.correo);
            comando.ExecuteNonQuery();

            /// FINALIZAMOS LA CONEXION CERRAMOS TODO
            comando.Dispose();
            cn.Close();
            cn.Dispose();

            return true;
        }

        public bool eliminar(int id) {
            /// CREAR LA CONEXIÓN, CONFIGURAR Y ABRIRLA
            MySqlConnection cn = new MySqlConnection();
            MySqlCommand comando = new MySqlCommand();
                cn.ConnectionString = "server=localhost; database=prograweb2; user=root; pwd=root";
                cn.Open();

                /// ELIMINAR EL REGISTRO MEDIANTE UN COMANDO
                string strSQL = "delete from usuarios where idUsuarios = @idUsuarios;";
                comando = new MySqlCommand(strSQL, cn);
                comando.Parameters.AddWithValue("idUsuarios", id);
                comando.ExecuteNonQuery();
         
                /// FINALIZAMOS LA CONEXION CERRAMOS TODO
                comando.Dispose();
                cn.Close();
                cn.Dispose();
            
            return true;

        }

    }
}