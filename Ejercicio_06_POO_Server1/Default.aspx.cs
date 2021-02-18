using Ejercicio_06_POO_Server1.addData;
using Ejercicio_06_POO_Server1.addNeg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ejercicio_06_POO_Server1.appUsuarios
{
    public partial class formUsuarios : System.Web.UI.Page
    {
        addData.UsuarioDAO objConectar = new addData.UsuarioDAO();
       


        protected void Page_Load(object sender, EventArgs e)
        {
            objConectar.conexion();
            //lblUsuarios.Text = objConectar.ObtenerUsuarios()[2].Nombre;
            GridView1.DataSource = null;
            GridView1.DataSource = objConectar.ObtenerUsuarios();
            GridView1.DataBind();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            NegUsuario objUser = new NegUsuario();
            objUser.Nombre = txtNombre.Text.ToString();
            objUser.edad = int.Parse(txtEdad.Text);
            objUser.telefono = txtTelefono.Text.ToString();
            objUser.correo = txtCorreo.Text.ToString();
             
            objConectar.Insertar(objUser);
            GridView1.DataSource = null;
            GridView1.DataSource = objConectar.ObtenerUsuarios();
            GridView1.DataBind();

            txtNombre.Text = "";
            txtEdad.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
        }

        protected void btneditar_Click(object sender, EventArgs e)
        {
            NegUsuario objUser = new NegUsuario();
            objUser.idUsuario = Int32.Parse(txtid.Text);
            objUser.Nombre = txtNombre.Text;
            objUser.edad = Int32.Parse(txtEdad.Text);
            objUser.telefono = txtTelefono.Text;
            objUser.correo = txtCorreo.Text;

            objConectar.Editar(objUser);

            GridView1.DataSource = null;
            GridView1.DataSource = objConectar.ObtenerUsuarios();
            GridView1.DataBind();

            txtid.Text = "";
            txtCorreo.Text = "";
            txtEdad.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
        }

        protected void btneliminar_Click(object sender, EventArgs e)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.eliminar(Int32.Parse(txtid.Text));

            GridView1.DataSource = null;
            GridView1.DataSource = objConectar.ObtenerUsuarios();
            GridView1.DataBind();
            txtid.Text = "";

        }
    }
}