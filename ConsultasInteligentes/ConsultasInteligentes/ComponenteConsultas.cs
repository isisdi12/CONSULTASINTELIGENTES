using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
using CapaDiseno;

namespace ConsultasInteligentes
{
    public partial class ComponenteConsultas : UserControl
    {
        logica log = new logica();

        private string QuerySimple,QuerySimpleComplete,QueryComplejoCondicional,QueryComplejoComp,QueryAgrup, QueryComplejoOrden, QueryComplejoTotal;
        int contadorAgregar = 0, ContadorLogico=0, ContadorComparacion=0, ContadorAgrup=0;
        List<int> lista = new List<int>();
        List<string> consultas = new List<string>();
        int idConsulta = 0;

        public ComponenteConsultas()
        {
            InitializeComponent();
            gbLogica.Enabled = false;
            gbComparacion.Enabled = false;
            gbTipoOrdenamiento.Enabled = false;
            gbAgrupar.Enabled = false;
            log.tablas(cboTablasGeneral);
            log.tablas(cboTablaGeneral1);
            log.CargarConsultas(Cbo_ListaTablas, lista, consultas);

            //log.conect();
            // cboTablasGeneral=log.listatablas();
        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCampos.Items.Clear();
            log.campos(cboCampos, cboTablasGeneral.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            QuerySimpleComplete = "SELECT " + QuerySimple + " FROM " + cboTablasGeneral.Text;
            //log.listatablas();

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            QueryComplejoCondicional += cboOpLogico.Text + " " +  cboCampoLogico.Text + " = " + txtValorLogico.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BorrarCampos borrar = new BorrarCampos();
            borrar.BorrarTxt(this);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox7_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnAgregarOrden_Click(object sender, EventArgs e)
        {
            if (cboTipoSeleccion.Text == "Ordenar")
            {
               // gbTipoOrdenamiento.Enabled = true;
                if (rbAscendente.Checked)
                {
                    QueryComplejoOrden = "ORDER BY " + cboCampoOrden.Text + " ASC ";
                }
                else if (rbDescendente.Checked)
                {
                    QueryComplejoOrden = "ORDER BY " + cboCampoOrden.Text + " DESC ";
                }
            }
            else if (cboTipoSeleccion.Text == "Agrupar")
            {
               // gbTipoOrdenamiento.Enabled = false;
                QueryComplejoOrden = "GROUP BY " + cboCampoOrden.Text;
            }



            MessageBox.Show(QueryComplejoOrden);
           
        }

        private void btnCrearConsulta_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                QueryComplejoTotal = QuerySimpleComplete +" "+ QueryComplejoComp + " " + QueryComplejoCondicional + " " + QueryComplejoOrden;
            }
            else
            {
                QueryComplejoTotal = QuerySimpleComplete;

            }
            txtCadena.Text = QueryComplejoTotal;
            log.InsertarCampos(QueryComplejoTotal, txtNombreConsulta.Text, "Admin");
        }

        private void btnCancelarGeneral_Click(object sender, EventArgs e)
        {
            BorrarCampos borrar = new BorrarCampos();
            borrar.BorrarTxt(this);
        }

        private void btnCancelarLogico_Click(object sender, EventArgs e)
        {
            BorrarCampos borrar = new BorrarCampos();
            borrar.BorrarTxt(this);
        }

        private void btnCancelarAgrup_Click(object sender, EventArgs e)
        {
            BorrarCampos borrar = new BorrarCampos();
            borrar.BorrarTxt(this);
        }

        private void btnBorrarProgreso_Click(object sender, EventArgs e)
        {
            BorrarCampos borrar = new BorrarCampos();
            borrar.BorrarTxt(this);
            txtCadena.Text = null;
            QuerySimple = null;
            QueryComplejoTotal = null;
            QuerySimpleComplete = null;
            QueryComplejoComp = null;
            QueryComplejoCondicional = null;
            QueryComplejoOrden = null;
            txtNombreConsulta.Text = null;
            cboCampos.Items.Clear();
            cboCampos.Text = null;
            cboTablasGeneral.Items.Clear();
            cboTablasGeneral.Text = null;
        }

        private void txtNombreRepresentativo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validaciones val = new validaciones();
            //val.SOLOLETRAS(e);
        }

        private void txtValorLogico_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtNombreRepresentativo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            log.txt(TxtNConsulta, TxtEID.Text);
            log.txt1(TxtEditarCadena, TxtEID.Text);
        }

        private void BtnEditarA1_Click(object sender, EventArgs e)
        {
            contadorAgregar++;
            if (contadorAgregar == 1)
            {
                if (checkBox3.Checked)
                {
                    QuerySimple = " * FROM ";
                }
                else
                {
                    if (textBox5.Text != "")
                    {
                        QuerySimple += CboGeneralCampos.Text + " as " + textBox5.Text;
                    }
                    else
                    {
                        QuerySimple += CboGeneralCampos.Text;
                    }

                }
            }
            else if (contadorAgregar >= 1)
            {
                if (textBox5.Text != "")
                {
                    QuerySimple += "," + CboGeneralCampos.Text + " as " + textBox5.Text;
                }
                else
                {
                    QuerySimple += " ," + CboGeneralCampos.Text;
                }
            }
        }

        private void BtnEditarA2_Click(object sender, EventArgs e)
        {
            QuerySimpleComplete = "SELECT " + QuerySimple + " FROM " + cboTablaGeneral1.Text;
            //log.listatablas();
            MessageBox.Show(QuerySimpleComplete, "esta aqui");
        }

        private void BtnEditarC1_Click(object sender, EventArgs e)
        {
            BorrarCampos borrar = new BorrarCampos();
            borrar.BorrarTxt(this);
        }

        private void BtnEditarA3_Click(object sender, EventArgs e)
        {
            QueryComplejoCondicional += cboOLogico.Text + " " + cboCondicionesCampo.Text + " = " + textBox3.Text;
        }

        private void BtnEditarC2_Click(object sender, EventArgs e)
        {
            BorrarCampos borrar = new BorrarCampos();
            borrar.BorrarTxt(this);
        }

        private void BtnEditarA4_Click(object sender, EventArgs e)
        {
            ContadorComparacion++;
            if (ContadorComparacion > 1)
            {
                MessageBox.Show("No puede agregar 2 comparaciones en un mismo query");
            }
            else
            {
                QueryComplejoComp = cboComparacionTipo.Text + cboComparacionCampo.Text + " = " + textBox2.Text;
            }
        }

        private void BtnEditarC3_Click(object sender, EventArgs e)
        {
            BorrarCampos borrar = new BorrarCampos();
            borrar.BorrarTxt(this);
        }

        private void BtnEditarA5_Click(object sender, EventArgs e)
        {
            ContadorAgrup++;
            if (ContadorAgrup == 1)
            {
                gbTipoOrdenamiento.Enabled = false;
                if (cboAgruparCampo.Text == "Ordenar")
                {
                    gbTipoOrdenamiento.Enabled = true;
                    if (radioButton2.Checked)
                    {
                        QueryComplejoOrden = "ORDER BY " + cboOrdenarAgrupar.Text + " ASC ";
                    }
                    else if (radioButton1.Checked)
                    {
                        QueryComplejoOrden = "ORDER BY " + cboOrdenarAgrupar.Text + " DESC ";
                    }
                }
                else if (cboCampoOrden.Text == "Agrupar")
                {
                    QueryComplejoOrden = "GROUP BY " + cboAgruparCampo.Text;
                }
            }
            else
            {
                MessageBox.Show("No puede agregar mas de un ordenamiendo/agrupacion");
            }
        }

        private void BtnEditarC4_Click(object sender, EventArgs e)
        {
            BorrarCampos borrar = new BorrarCampos();
            borrar.BorrarTxt(this);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            BorrarCampos borrar = new BorrarCampos();
            borrar.BorrarTxt(this);
            txtCadena.Text = null;
            QuerySimple = null;
            QueryComplejoTotal = null;
            QuerySimpleComplete = null;
            QueryComplejoComp = null;
            QueryComplejoCondicional = null;
            QueryComplejoOrden = null;
            TxtNConsulta.Text = null;
            cboTablaGeneral1.Items.Clear();
            cboTablaGeneral1.Text = null;
            CboGeneralCampos.Items.Clear();
            CboGeneralCampos.Text = null;
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                QueryComplejoTotal = TxtNConsulta.Text + QueryComplejoComp + QueryComplejoCondicional + QueryComplejoOrden;
            }
            else
            {
                QueryComplejoTotal = QuerySimpleComplete;
            }
            MessageBox.Show(QueryComplejoTotal);
            idConsulta = Convert.ToInt32(TxtEID.Text);

            log.EditarCampos(QueryComplejoTotal, TxtNConsulta.Text, "Admin", idConsulta);
        }

        private void BtnBuscarEditar_Click(object sender, EventArgs e)
        {

            int iIdConsulta = Convert.ToInt32(TxtIdEditar.Text);
            DataTable dtDatosDiseno = log.consultaId(iIdConsulta);
            dvgConsultas.DataSource=dtDatosDiseno;

        }

        private void BtnEditarActualizar_Click(object sender, EventArgs e)
        {

            int iIdConsulta = Convert.ToInt32(TxtIdEditar.Text);
            DataTable dtDatosDiseno = log.consultaId(iIdConsulta);
            dvgConsultas.DataSource = dtDatosDiseno;
        }

        private void BtnEliminarEditar_Click(object sender, EventArgs e)
        {
            if(TxtIdEditar.Text == "")
            {
                MessageBox.Show("Debe ingresar un id");
            }
            else
            {
                idConsulta = Convert.ToInt32(TxtIdEditar.Text);
                log.EliminarCampos(idConsulta);
            }

            /*string eliminar = "delete  where Id = " + TxtIdEditar.Text;

            if (cn.executecommand(eliminar))
            {
                MessageBox.Show("REGISTRO ELIMINADO EXITOSAMENTE");
                dvgConsultas.DataSource = cn.SelectDataTable("select * from datos");
            }

            else
            {
                MessageBox.Show("ERROR AL ELIMINAR");
            }*/
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int iIdConsulta = Convert.ToInt32(TxtIdEditar.Text);
            DataTable dtDatosDiseno = log.consultaId(iIdConsulta);
            dvgConsultas.DataSource = dtDatosDiseno;

        }

        private void cboTablasGeneral_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboCampos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboOpLogico_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboCampoLogico_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboComparador_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

     

        private void TxtNConsulta_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtIdEditar_TextChanged(object sender, EventArgs e)
        {

        }


        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            log.EjecutarConsultas(dgvConsultas, textBox1.Text);
        }

        private void TbConsultas_Click(object sender, EventArgs e)
        {

        }

        private void Cbo_ListaTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbo_ListaTablas.Items.Count > 0)
            {
                int seleccionado = Cbo_ListaTablas.SelectedIndex;
                idConsulta = lista.ElementAt(seleccionado);
                textBox1.Text = consultas.ElementAt(seleccionado);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            Cbo_ListaTablas.Items.Clear();
            lista.Clear();
            consultas.Clear();
            log.CargarConsultas(Cbo_ListaTablas, lista, consultas);
        }

        private void RbtnCampos_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

       

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TxtValorLogico_TextChanged(object sender, EventArgs e)
        {

        }

        private void TbCreacionConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboCampos.Items.Clear();
            //log.campos(CboGeneralCampos, cboTablaGeneral1.Text);
        }

        private void CboGeneralCampos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CheckBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                gbLogica1.Enabled = true;
                gbComparacion1.Enabled = true;
                gbAgrupar1.Enabled = true;
                gbAgrupar.Enabled = true;
                log.campos(cboComparacionCampo, cboTablaGeneral1.Text);
                log.campos(cboAgruparCampo, cboTablaGeneral1.Text);
                log.campos(cboCondicionesCampo, cboTablaGeneral1.Text);

            }
            else
            {
                gbLogica1.Enabled = false;
                gbComparacion1.Enabled = false;
                gbTipoOrdenamiento1.Enabled = false;
                gbAgrupar1.Enabled = false;
            }
        }

        private void CboComparacionTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CboOrdenarAgrupar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CboTablaGeneral1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CboGeneralCampos.Items.Clear();
            log.campos(CboGeneralCampos, cboTablaGeneral1.Text);
        }

        private void CboGeneralCampos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboSeleccionados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComponenteConsultas_Load(object sender, EventArgs e)
        {

        }

        private void cboOLogico_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboCampoComparador_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboTipoSeleccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboCampoOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }



        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoSeleccion.Text == "Ordenar")
            {
                gbTipoOrdenamiento.Enabled = true;

            }
            else if (cboTipoSeleccion.Text == "Agrupar")
            {
                gbTipoOrdenamiento.Enabled = false;

            }
        }

        private void cboTipoSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoSeleccion.Text == "Ordenar")
            {
                gbTipoOrdenamiento.Enabled = true;
               
            }
            else if (cboTipoSeleccion.Text == "Agrupar")
            {
                gbTipoOrdenamiento.Enabled = false;
                
            }



        }


        private void cbCondiciones_Click(object sender, EventArgs e)
        {
            if (cbCondiciones.Checked)
            {
                gbLogica.Enabled = true;
                gbComparacion.Enabled = true;
                gbTipoOrdenamiento.Enabled = true;
                gbAgrupar.Enabled = true;
                log.campos(cboCampoComparador, cboTablasGeneral.Text);
                log.campos(cboCampoOrden, cboTablasGeneral.Text);
                log.campos(cboCampoLogico, cboTablasGeneral.Text);

            }
            else
            {
                gbLogica.Enabled = false;
                gbComparacion.Enabled = false;
                gbTipoOrdenamiento.Enabled = false;
                gbAgrupar.Enabled = false;
            }
            
           
        }

        private void btnAgregarComp_Click(object sender, EventArgs e)
        {
            ContadorComparacion++;
            if (ContadorComparacion > 1)
            {
                MessageBox.Show("No puede agregar 2 comparaciones en un mismo query");
            }
            else
            {
                QueryComplejoComp = cboComparador.Text + cboCampoComparador.Text +" = " + txtValorComp.Text;
            }
        }

        private void btnAgregarCampo_Click(object sender, EventArgs e)
        {
            contadorAgregar++;

            List<string> listacampos = new List<string>();



            if (txtNombreConsulta.Text == " " || cboTablasGeneral.Text == " " || cboCampos.Text == " ")
            {
                MessageBox.Show("No puede dejar campos vacíos");
            }

            else
            {
                if (contadorAgregar == 1)
                {
                    if (checkBox2.Checked)
                    {
                        QuerySimple = " * ";
                    }
                    else
                    {
                        if (txtNombreRepresentativo.Text != " ")
                        {
                            QuerySimple += cboCampos.Text + " as " + txtNombreRepresentativo.Text;
                        }
                        else
                        {
                            QuerySimple += cboCampos.Text;
                        }

                    }
                }
                else if (contadorAgregar >= 1)
                {

                    if (txtNombreRepresentativo.Text != "")
                    {
                        QuerySimple += "," + cboCampos.Text + " as " + txtNombreRepresentativo.Text;
                    }
                    else
                    {
                        QuerySimple += " ," + cboCampos.Text;
                    }

                }
                listacampos.Add(QuerySimple);

                cboSeleccionados.Items.Add(listacampos);
                
            }
        }
    }
}
