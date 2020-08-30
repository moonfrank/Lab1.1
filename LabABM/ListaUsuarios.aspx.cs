using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NegocioWeb;

public partial class ListaUsuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        FillTable();
    }

    private void LoadCalendar()
    {
        if (!Page.IsPostBack)
        {
            for (int i = 0; i < 31; i++)
            {
                int dia = i + 1;
                this.ddlDiaFechaNacimiento.Items.Add(dia.ToString());
            }
        }
    }

    private void SetTitleLabel()
    {
        if (IsEdit()) this.lblAccion.Text = $"Editar Usuario {Request.QueryString["id"]}";
        else lblAccion.Text = "Agregar Nuevo Usuario";
    }

    private bool IsEdit()
    {
        if (Request.QueryString["id"] != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void FillTable()
    {
        SetTitleLabel();
        LoadCalendar();
        if (IsEdit())
        {
            CargarDatosUsuario(int.Parse(Request.QueryString["id"]));
        }
    }

    private void CargarDatosUsuario(int idUsuario)
    {
        // 1 - Obtener los datos del usuario en cuestión
        ManagerUsuarios managerUsuarios = new ManagerUsuarios();
        Usuario usuario = managerUsuarios.GetUsuario(idUsuario);
        // 2 - Cargar en los controles de la tabla los datos del usuario obtenido
        
        txtApellido.Text = usuario.Apellido;
        txtNombre.Text = usuario.Nombre;
        if (usuario.TipoDoc.HasValue) rblTipoDocumento.SelectedValue = usuario.TipoDoc.ToString();        
        if (usuario.NroDoc.HasValue) txtNroDocumento.Text = usuario.NroDoc.ToString();        
        ddlDiaFechaNacimiento.Text = DateTime.Parse(usuario.FechaNac).Day.ToString();
        ddlMesFechaNacimiento.Text = DateTime.Parse(usuario.FechaNac).Month.ToString();
        txtDirección.Text = usuario.Direccion;
        txtTelefono.Text = usuario.Telefono;
        txtEmail.Text = usuario.Email;
        txtCelular.Text = usuario.Celular;
        txtNombreUsuario.Text = usuario.NombreUsuario;
        
        
    }


    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        Usuario usu = new Usuario();
        ManagerUsuarios mng = new ManagerUsuarios();
        if (IsEdit()) mng.ActualizarUsuario(usu);
        else mng.AgregarUsuario(usu);
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListaUsuarios.aspx");
    }
}