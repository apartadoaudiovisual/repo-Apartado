using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;


public partial class AreasDeServicio : System.Web.UI.Page
{
    List<string> listaSession;

    List<string> listaASSel=new List<string>();
    BDAreasDeServicios bdAreasServicio = new BDAreasDeServicios();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack){

            ListarAreasServicio();
            mViewAreasDeServicio.SetActiveView(vAreasDeServicio);
            Session["listaASSel"] = null;

        }

         listaSession = (List<string>)Session["listaSession"];
         
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        //aqui se guardara la nueva area agregada

        ddlCampus.Items.Clear();
        ddlDepartamento.Items.Clear();
        ddlTipoArea.Items.Clear();
        txtDescripcion.Text = "";

        


        mViewAreasDeServicio.SetActiveView(vAgregarAreaDeServicio);

        List<ClsCampus> campus=bdAreasServicio.ListaCampus();
        List<ClsDepartamento> depto = bdAreasServicio.ListaDeptos();
        List<ClsTiposAS> tipos = bdAreasServicio.ListaTiposAS();

        ListItem t = new ListItem("TODOS", "0", true);
        ddlDepartamento.Items.Add(t);

        foreach(ClsCampus ca in campus){

            ListItem l = new ListItem(ca.descripcion, ca.ID, true); 
            
            ddlCampus.Items.Add(l);
        
        }

        foreach (ClsDepartamento de in depto)
        {

            ListItem l = new ListItem(de.Descripcion, de.ID, true);

            ddlDepartamento.Items.Add(l);

        }

        foreach (ClsTiposAS ti in tipos)
        {

            ListItem l = new ListItem(ti.Descripcion, ti.ID, true);

            ddlTipoArea.Items.Add(l);

        }


    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        mViewAreasDeServicio.SetActiveView(vAreasDeServicio);
    }

    protected void ListarAreasServicio() {

        
        DataTable tabla = bdAreasServicio.ListaAreasServicios();
        

        gridAreasServicio.DataSource = tabla;
        gridAreasServicio.DataBind();
    
    }

    protected void GuardarAS(object sender, EventArgs e)
    {
        if (bdAreasServicio.AgregarAreaDeServicio(listaSession[0].ToString(), txtDescripcion.Text, ddlDepartamento.Text, ddlCampus.Text, ddlTipoArea.Text) == 1)
        {

           
            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('El Area de Servicio se ha registrado correctamente.', 'Areas de Servicio');", true);
            ListarAreasServicio();
            mViewAreasDeServicio.SetActiveView(vAreasDeServicio);
        }
        else
        {

            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Error al insertar el Area de Servicio.', 'Areas de Servicio');", true);

        }
    }
    /// <summary>
    /// hola jp
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ConfigurarAS(object sender, EventArgs e) {

        listaASSel = (List<string>)Session["listaASSel"];

        if (gridAreasServicio.Rows.Count > 0)
        {
            if (listaASSel != null)
            {

                mViewAreasDeServicio.SetActiveView(vActualizarAreaDeServicio);

                ddlDeptoAct.Items.Clear();
                ddlCampusAct.Items.Clear();
                ddlTipoAct.Items.Clear();
                txtDescrAct.Text = "";

                List<ClsCampus> campus = bdAreasServicio.ListaCampus();
                List<ClsDepartamento> depto = bdAreasServicio.ListaDeptos();
                List<ClsTiposAS> tipos = bdAreasServicio.ListaTiposAS();

                ListItem t = new ListItem("TODOS", "0", true);
                ddlDepartamento.Items.Add(t);

                foreach (ClsCampus ca in campus)
                {

                    ListItem l = new ListItem(ca.descripcion, ca.ID, true);

                    ddlCampusAct.Items.Add(l);


                }

                foreach (ClsDepartamento de in depto)
                {

                    ListItem l = new ListItem(de.Descripcion, de.ID, true);

                    ddlDeptoAct.Items.Add(l);

                }

                foreach (ClsTiposAS ti in tipos)
                {

                    ListItem l = new ListItem(ti.Descripcion, ti.ID, true);

                    ddlTipoAct.Items.Add(l);

                }

                DataTable registro = bdAreasServicio.DatosDelAreaServicio(Int32.Parse(listaASSel[0]));

                foreach (DataRow dr in registro.Rows)
                {


                    txtDescrAct.Text = dr["descripcionAS"].ToString();

                    foreach (ListItem item in ddlCampusAct.Items)
                    {

                        if (Int32.Parse(item.Value) == Int32.Parse(dr["idCampus"].ToString()))
                        {

                            item.Selected = true;
                        }

                    }
                    foreach (ListItem item in ddlTipoAct.Items)
                    {

                        if (Int32.Parse(item.Value) == Int32.Parse(dr["idTipoArea"].ToString()))
                        {

                            item.Selected = true;
                        }

                    }
                    foreach (ListItem item in ddlDeptoAct.Items)
                    {

                        if (Int32.Parse(item.Value) == Int32.Parse(dr["depto"].ToString()))
                        {

                            item.Selected = true;
                        }

                    }

                }



                //listaASSel = null;
                //Session["listaASSel"] = null;

            }
            else
            {

                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Selecciona un Area de Servicio.', 'Configuracion de Areas de Servicio');", true);

            }
        }
        else {

            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('No existe ningun Area de Servicio.', 'Configuracion de Areas de Servicio');", true);
        
        }
    
    }

    protected void EliminarAS(object sender, EventArgs e)
    {
        listaASSel = (List<string>)Session["listaASSel"];

        if (gridAreasServicio.Rows.Count > 0)
        {
            if (listaASSel != null)
            {

                if (bdAreasServicio.EliminarAS(Int32.Parse(listaASSel[0])) == 1)
                {
                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Se ha Eliminado el Area de Servicio.', 'Configuracion de Areas de Servicio');", true);
                }
                else
                {

                    ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('No se ha Podido Eliminar el Area de Servicio.', 'Configuracion de Areas de Servicio');", true);

                }



            }
            else
            {

                ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Selecciona un Area de Servicio.', 'Configuracion de Areas de Servicio');", true);

            }

            listaASSel = null;
            Session["listaASSel"] = null;
            ListarAreasServicio();
            mViewAreasDeServicio.SetActiveView(vAreasDeServicio);
        }
        else {

            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('No existe ningun Area de Servicio.', 'Configuracion de Areas de Servicio');", true);
        
        }
        
    }

    protected void gridAreasServicio_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridAreasServicio.SelectedRow.ForeColor = Color.FromName("#d95959");

        listaASSel.Add(gridAreasServicio.SelectedRow.Cells[1].Text);

        Session["listaASSel"] = listaASSel;


    }

    protected void gridAreasServicio_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

    }

    protected void gridAreasServicio_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    
    protected void btnCanvelarActualizacion(object sender, EventArgs e)
    {
        listaASSel = null;
        Session["listaASSel"] = null;

        mViewAreasDeServicio.SetActiveView(vAreasDeServicio);

    }

    protected void GuardarActualizacion(object sender, EventArgs e)
    {
        listaASSel = (List<string>)Session["listaASSel"];

        int res = bdAreasServicio.ActualizaAS(Int32.Parse(listaASSel[0]), txtDescrAct.Text, ddlDeptoAct.SelectedValue.ToString(), ddlTipoAct.SelectedValue.ToString(), ddlCampusAct.SelectedValue.ToString());

        if (res == 1)
        {

            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('El Area de Servicio se ha Actualizado.', 'Areas de Servicio');", true);
            
        }
        else {

            ClientScript.RegisterStartupScript(GetType(), "Javascript", "javascript:message_error('Error no se ha Podido Actualizar el Area de Servicio.', 'Areas de Servicio');", true);
        
        }

        listaASSel = null;
        Session["listaASSel"] = null;
        ListarAreasServicio();
        mViewAreasDeServicio.SetActiveView(vAreasDeServicio);
    }
}