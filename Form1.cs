using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GestionEmpleados
{
    public partial class Form1 : Form
    {
        private OleDbConnection conexion;
        private IDbCommand command;
        private bool isSearch = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            EstablecerConexion();
            CargarDepartyLoc();
            BuscarYMostrarNombresColumnas();
            BtnFlechaArriba.Click += new EventHandler(BtnFlechasClick);
            BtnFlechaAbajo.Click += new EventHandler(BtnFlechasClick);
            ConfigTT();
        }

        private void EstablecerConexion()
        {
            conexion = new OleDbConnection();
            conexion.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\temp\\Emple.mdb";
            conexion.Open();
            //MessageBox.Show(conexion.State.ToString());
        }

        private void CargarDepartyLoc()
        {
            command = conexion.CreateCommand();
            command.CommandText = "select * from depart";
            IDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                LBIDDepart.Items.Add(dataReader.GetValue(0).ToString());
                LBDepart.Items.Add(dataReader.GetString(1));
                LBLocalizacion.Items.Add(dataReader.GetString(2));
            }
            dataReader.Close();

            LBIDDepart.SelectedIndex = 0;
            LBDepart.SelectedIndex = 0;
            LBLocalizacion.SelectedIndex = 0;
            isSearch = false;
            BuscarYMostrarEmpleadosPorDepart();

        }

        private void LBItemClickDepart(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;
            if (lb.SelectedItem == null) return;

            LBDepart.SelectedIndex = lb.SelectedIndex;
            LBLocalizacion.SelectedIndex = lb.SelectedIndex;
            LBIDDepart.SelectedIndex = lb.SelectedIndex;

            isSearch = false;
            BuscarYMostrarEmpleadosPorDepart();       

        }
        private void LBSelectedChange(object sender, EventArgs e)
        {

            ListBox lb = (ListBox)sender;
            if (lb == LBIDEmple)
            {
                int newIndex = 0;
                if (LBIDEmple.SelectedIndex >= 1)
                {
                    newIndex = LBIDEmple.SelectedIndex;
                } else
                {
                    newIndex = LBIDEmple.Items.Count - 1;
                }
            }
        }

        private void BtnFlechasClick(object sender, EventArgs e)
        {
            int newIndex = 0;
            if ((Button)sender == BtnFlechaArriba)
            {
               
                if (LBApellidos.SelectedIndex >= 1)
                {
                    newIndex = LBIDEmple.SelectedIndex - 1;
                } else
                {
                    newIndex = LBIDEmple.Items.Count - 1;
                }
            } else
            {
                if (LBApellidos.SelectedIndex < LBApellidos.Items.Count - 1)
                {
                    newIndex = LBIDEmple.SelectedIndex + 1;
                } else
                {
                    newIndex = 0;
                }
            }

            LBDeptNoEmple.SelectedIndex = newIndex;
            LBIDEmple.SelectedIndex = newIndex;
            LBApellidos.SelectedIndex = newIndex;
            LBOficio.SelectedIndex = newIndex;
            LBSalario.SelectedIndex = newIndex;
            LBFechaAlta.SelectedIndex = newIndex;
            LBComision.SelectedIndex = newIndex;

            LBIDDepart.SelectedItem = LBDeptNoEmple.SelectedItem;
            LBDepart.SelectedIndex = LBIDDepart.SelectedIndex;
            LBLocalizacion.SelectedIndex = LBIDDepart.SelectedIndex;

            InsertarDatosEmpleado();
        }

        private void LBItemClickEmple(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;
            LBDeptNoEmple.SelectedIndex = lb.SelectedIndex;
            LBIDEmple.SelectedIndex = lb.SelectedIndex;
            LBApellidos.SelectedIndex = lb.SelectedIndex;
            LBOficio.SelectedIndex = lb.SelectedIndex;
            LBSalario.SelectedIndex = lb.SelectedIndex;
            LBFechaAlta.SelectedIndex = lb.SelectedIndex;
            LBComision.SelectedIndex = lb.SelectedIndex;

            LBIDDepart.SelectedItem = LBDeptNoEmple.SelectedItem;
            LBDepart.SelectedIndex = LBIDDepart.SelectedIndex;
            LBLocalizacion.SelectedIndex = LBIDDepart.SelectedIndex;

            InsertarDatosEmpleado();       
        }

        private void InsertarDatosEmpleado()
        {
            TBApellidos.Text = LBApellidos.SelectedItem.ToString();
            TBOficio.Text = LBOficio.SelectedItem.ToString();
            TBSalario.Text = LBSalario.SelectedItem.ToString();
            TBFechaAlta.Text = LBFechaAlta.SelectedItem.ToString();
            TBComision.Text = LBComision.SelectedItem.ToString();

        }

        private void BuscarYMostrarEmpleadosPorDepart()
        {
            LimpiarDatosLB();
            // Consulta
           
            command = conexion.CreateCommand();
            command.CommandText = "select * from emple where dept_no = " + LBIDDepart.SelectedItem.ToString();

            IDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                LBIDEmple.Items.Add(dataReader.GetValue(0).ToString());
                LBApellidos.Items.Add(dataReader.GetString(1));
                LBOficio.Items.Add(dataReader.GetString(2));
                LBFechaAlta.Items.Add(dataReader.GetDateTime(4).ToString("dd/MM/yyyy"));
                LBSalario.Items.Add(dataReader.GetValue(5).ToString());
                LBComision.Items.Add(dataReader.GetValue(6).ToString());
                LBDeptNoEmple.Items.Add(dataReader.GetValue(7).ToString());
            }

            dataReader.Close();
        }

        private void BuscarYMostrarNombresColumnas()
        {
            DataTable schema = conexion.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, "EMPLE", null });

            foreach (DataRow row in schema.Rows)
            {
                string columnName = row["COLUMN_NAME"].ToString();
                CbBuscar.Items.Add(columnName);
            }

            
        }

        private void LimpiarDatosLB()
        {
            LBIDEmple.Items.Clear();
            LBDeptNoEmple.Items.Clear();
            LBIDEmple.Items.Clear();
            LBApellidos.Items.Clear();
            LBOficio.Items.Clear();
            LBSalario.Items.Clear();
            LBFechaAlta.Items.Clear();
            LBComision.Items.Clear();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            String columna = TbBuscarEmple.Text;
            if (!VerificarInput()) return;
            isSearch = true;
            BuscarYMostrarEmpleadosBusqueda(TbBuscarEmple.Text, CbBuscar.SelectedItem.ToString());
            if(LBIDEmple.Items.Count > 0)
            {
                LBApellidos.Focus();
                BtnFlechasClick(BtnFlechaAbajo, null);
                
            }
            
        }

        private void BuscarYMostrarEmpleadosBusqueda(String input, String column)
        {
            // Consulta
            command = conexion.CreateCommand();

            command.CommandText = "select * from emple where " + column + " = @param";

            OleDbParameter paramCustomInput = new OleDbParameter("@param", input);
            paramCustomInput.Direction = ParameterDirection.Input;
            command.Parameters.Add(paramCustomInput);

            IDataReader dataReader = command.ExecuteReader();
            LimpiarDatosLB();

            while (dataReader.Read())
            {
                
                LBIDEmple.Items.Add(dataReader.GetValue(0).ToString());
                LBApellidos.Items.Add(dataReader.GetString(1));
                LBOficio.Items.Add(dataReader.GetString(2));
                LBFechaAlta.Items.Add(dataReader.GetDateTime(4).ToString("dd/MM/yyyy"));
                LBSalario.Items.Add(dataReader.GetValue(5).ToString());
                LBComision.Items.Add(dataReader.GetValue(6).ToString());
                LBDeptNoEmple.Items.Add(dataReader.GetValue(7).ToString());
                
            }

            dataReader.Close();
        }

        private bool VerificarInput()
        {
            if (CbBuscar.SelectedItem == null)
            {
                LanzarError("de  la categoría seleccionada", "buscar");
                return false;
            }

            switch (CbBuscar.SelectedItem.ToString())
            {
                case "COMISION":
                case "DEPT_NO":
                case "DIR":
                case "EMP_NO":
                case "SALARIO":
                    try
                    {
                        int comision = Convert.ToInt32(TbBuscarEmple.Text);
                        break;
                    } catch (FormatException e)
                    {
                        LanzarError(" de búsqueda", "buscar");
                        return false;
                    }
                case "FECHA_ALT":
                    if (!Regex.IsMatch(TbBuscarEmple.Text, @"^\d{2}/\d{2}/\d{4}$"))
                    {
                        LanzarError(" de búsqueda", "buscar");
                        return false;
                    }
                    else break;
            }

          

            return true;
        }

        private void ConfigTT()
        {
            string info = "Al crear un nuevo registro, se añadirá al departamento que esté seleccionado";
            TTInfo.SetToolTip(LblInfo, info);
        }

        private void GuardarEmpleNuevo()
        {
            string apellidos;
            string oficio;
            string salario;
            string fechaAlta;
            string comision;

            if (TBApellidos.Text.Length != 0)
            {
                apellidos = TBApellidos.Text;
            }
            else
            {
                LanzarError(LBApellidos.Text, BtnActualizar.Text);
                return;
            }

            if (TBOficio.Text.Length != 0)
            {
                oficio = TBOficio.Text;
            }
            else
            {
                LanzarError(LBOficio.Text, BtnActualizar.Text);
                return;
            }

            if (TBSalario.Text.Length != 0)
            {
                salario = TBSalario.Text;
            }
            else
            {
                LanzarError(TBSalario.Text, BtnActualizar.Text);
                return;
            }

            if (TBFechaAlta.Text.Length != 0)
            {
                fechaAlta = TBFechaAlta.Text;
            }
            else
            {
                LanzarError(TBFechaAlta.Text, BtnActualizar.Text);
                return;
            }

            if (TBComision.Text.Length != 0)
            {
                comision = TBComision.Text;
            }
            else
            {
                LanzarError(TBComision.Text, BtnActualizar.Text);
                return;
            }

           
            int numberEmple = GenerarNumEmple();
            if (numberEmple == 0)
            {
                MessageBox.Show("Ha ocurrido un error en la generación del número de empleado. Intentelo de nuevo.");
            }
            OleDbParameter paramEmpNo = new OleDbParameter("@empNo", numberEmple);
            paramEmpNo.Direction = ParameterDirection.Input;
            OleDbParameter paramApellido = new OleDbParameter("@apellido", apellidos);
            paramApellido.Direction = ParameterDirection.Input;
            OleDbParameter paramOficio = new OleDbParameter("@oficio", oficio);
            paramOficio.Direction = ParameterDirection.Input;            
            OleDbParameter paramFechaAlta = new OleDbParameter("@fechaAlta", Convert.ToDateTime(fechaAlta));
            paramFechaAlta.Direction = ParameterDirection.Input;
            OleDbParameter paramSalario = new OleDbParameter("@salario", salario);
            paramSalario.Direction = ParameterDirection.Input;
            OleDbParameter paramComision = new OleDbParameter("@comision", comision);
            paramComision.Direction = ParameterDirection.Input;
            OleDbParameter paramDeptNo = new OleDbParameter("@deptNo", LBIDDepart.SelectedItem.ToString());
            paramDeptNo.Direction = ParameterDirection.Input;

            command = conexion.CreateCommand();
            command.CommandText = "INSERT INTO emple(emp_no, apellido, oficio, fecha_alt, salario, comision, dept_no) VALUES(@empNo, @apellido, @oficio, @fechaAlta, @salario, @comision, @deptNo)";


            command.Parameters.Add(paramEmpNo);
            command.Parameters.Add(paramApellido);
            command.Parameters.Add(paramOficio);            
            command.Parameters.Add(paramFechaAlta);
            command.Parameters.Add(paramSalario);
            command.Parameters.Add(paramComision);
            command.Parameters.Add(paramDeptNo);

           
           
           command.ExecuteNonQuery();
           MessageBox.Show("Se ha insertado correctamente el registro.");
            if (!isSearch)
            {
                BuscarYMostrarEmpleadosPorDepart();

            } else
            {
                BtnBuscar_Click(BtnBuscar, null);
            }





        }

        private int GenerarNumEmple()
        {
            string sql = "SELECT MAX(emp_no) AS idMax FROM emple";
            command.CommandText = sql;
            IDataReader dataReader = command.ExecuteReader();
            int idMax = 0;
            while (dataReader.Read()) {
                idMax = Convert.ToInt32(dataReader["idMax"]);                
            }
            dataReader.Close();
            return idMax + 1;
        }



        private void LanzarError(string textBox, string accion)
        {
            MessageBox.Show("Hay un error en el campo " + textBox + ". Ha sido imposible " + accion + " los datos del usuario.");           
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {            
            ActualizarEmple();
        }

        private void ActualizarEmple()
        {
            string apellidos;
            string oficio;
            string salario;
            string fechaAlta;
            string comision;

            if (TBApellidos.Text.Length != 0)
            {
                apellidos = TBApellidos.Text;
            }
            else
            {
                LanzarError(LBApellidos.Text, BtnActualizar.Text);
                return;
            }

            if (TBOficio.Text.Length != 0)
            {
                oficio = TBOficio.Text;
            }
            else
            {
                LanzarError(LBOficio.Text, BtnActualizar.Text);
                return;
            }

            if (TBSalario.Text.Length != 0)
            {
                salario = TBSalario.Text;
            }
            else
            {
                LanzarError(TBSalario.Text, BtnActualizar.Text);
                return;
            }

            if (TBFechaAlta.Text.Length != 0)
            {
                fechaAlta = TBFechaAlta.Text;
            }
            else
            {
                LanzarError(TBFechaAlta.Text, BtnActualizar.Text);
                return;
            }

            if (TBComision.Text.Length != 0)
            {
                comision = TBComision.Text;
            }
            else
            {
                LanzarError(TBComision.Text, BtnActualizar.Text);
                return;
            }

            

            
            
            OleDbParameter paramApellido = new OleDbParameter("@apellido", apellidos);
            paramApellido.Direction = ParameterDirection.Input;
            OleDbParameter paramOficio = new OleDbParameter("@oficio", oficio);
            paramOficio.Direction = ParameterDirection.Input;
            OleDbParameter paramSalario = new OleDbParameter("@salario", salario);
            paramSalario.Direction = ParameterDirection.Input;
            OleDbParameter paramFechaAlta = new OleDbParameter("@fechaAlta", Convert.ToDateTime(fechaAlta));
            paramFechaAlta.Direction = ParameterDirection.Input;
            OleDbParameter paramComision = new OleDbParameter("@comision", comision);
            paramComision.Direction = ParameterDirection.Input;
            OleDbParameter paramDeptNo = new OleDbParameter("@deptNo", LBDeptNoEmple.SelectedItem.ToString());
            paramDeptNo.Direction = ParameterDirection.Input;

            int numberEmple = 0;
            if (LBIDEmple.SelectedItem != null)
            {
                numberEmple = Convert.ToInt32(LBIDEmple.SelectedItem.ToString());
            } else
            {
                MessageBox.Show("Tiene que seleccionar al empleado que quiere actualizar.");
                return;
            }
           
            OleDbParameter paramEmpNo = new OleDbParameter("@empNo", numberEmple);
            paramEmpNo.Direction = ParameterDirection.Input;

            command = conexion.CreateCommand();
            command.CommandText = "UPDATE emple SET" +
                                        " apellido = @apellido," +
                                        " oficio = @oficio," +
                                        " salario = @salario," +
                                        " fecha_alt = @fechaAlta," +
                                        " comision = @comision," +
                                        " dept_no = @deptNo" +
                                  " WHERE EMP_NO = @emp_no";

            command.Parameters.Add(paramApellido);
            command.Parameters.Add(paramOficio);
            command.Parameters.Add(paramSalario);
            command.Parameters.Add(paramFechaAlta);
            command.Parameters.Add(paramComision);
            command.Parameters.Add(paramDeptNo);
            command.Parameters.Add(paramEmpNo);


            try {
                command.ExecuteNonQuery();
                MessageBox.Show("Se ha modificado el registro.");

                if (!isSearch)
                {
                    BuscarYMostrarEmpleadosPorDepart();

                } else
                {
                    BtnBuscar_Click(BtnBuscar, null);
                }
            } catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error en la actualización de datos.");
            }


        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            GuardarEmpleNuevo();
        }

        private void LblBorrarInput_Click(object sender, EventArgs e)
        {
            TbBuscarEmple.Text = "";
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            int numberEmple = 0;
            if (LBIDEmple.SelectedItem != null)
            {
                numberEmple = Convert.ToInt32(LBIDEmple.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Tiene que seleccionar al empleado que quiere borrar.");
                return;
            }

            command = conexion.CreateCommand();
            command.CommandText = "DELETE FROM emple WHERE EMP_NO = " + numberEmple;

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Se ha borrado correctamente el registro.");
                if (!isSearch)
                {
                    BuscarYMostrarEmpleadosPorDepart();
                }
                else
                {
                    BtnBuscar_Click(BtnBuscar, null);
                }
            }
            catch (InvalidOperationException ioe)
            {
                MessageBox.Show("Se ha producido un error.");
            }

        }

        private void TbBuscarEmple_KeyPress(object sender, KeyPressEventArgs e)
        {            
            Keys press = (Keys)e.KeyChar;
            
            if (press == Keys.Enter)
            {
                e.Handled = true;
                BtnBuscar_Click(sender, null);
            } 
        }
    }
}
