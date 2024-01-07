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

        // Después de actualizar o agregar un nuevo registro, se actualizan los datos que se están mostrando al usuario. Pero
        // me di cuenta que durante una búsqueda, el usuario podría esperar que los datos mostrados sean los de su búsqueda. Con
        // este bool conotrolo si estamos en una búsqueda o no para determinar los datos que se tienen que mostrar al user.
        private bool isSearch = false;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Durante el load del formulario se establece la conexión y se recupera de la bd la información necesaria para
        /// cargar los departametos y el nombre de los campos que serán admitidos en las operaciones de búsqueda. 
        /// Además se establece el controlador de los botones "flecha" y se configura el ToolTip que usa la aplicación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            EstablecerConexion();
            CargarDepartyLoc();
            BuscarYMostrarNombresColumnas();            
            ConfigTT();
        }

        /// <summary>
        /// Este método establece la conexión con la base de datos.
        /// </summary>
        private void EstablecerConexion()
        {            
            conexion = new OleDbConnection();
            conexion.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\\temp\\Emple.mdb";
            conexion.Open();
            //MessageBox.Show(conexion.State.ToString());
        }

        /// <summary>
        /// Este método consulta los departamentos y sus categorias y los añade a la ListBox correspondiente.
        /// </summary>
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
                        
            BuscarYMostrarEmpleadosPorDepart();

        }

        /// <summary>
        /// Este método busca los empleados de el departamento seleccionado y los muestra en la ListBox correspondiente.
        /// </summary>
        private void BuscarYMostrarEmpleadosPorDepart()
        {
            isSearch = false;

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

        /// <summary>
        /// Cree este método para obtener el nombre de todos los campos de la tabla. Estos se usan en el desplegable del área
        /// de búsqueda.
        /// </summary>
        private void BuscarYMostrarNombresColumnas()
        {
            DataTable schema = conexion.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, "EMPLE", null });

            foreach (DataRow row in schema.Rows)
            {
                string columnName = row["COLUMN_NAME"].ToString();
                CbBuscar.Items.Add(columnName);
            }

            CbBuscar.SelectedIndex = 0;
        }

        /// <summary>
        /// Controlador del evento click sobre los items de las LBDepart y LBLocalizacion..
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <see cref="BuscarYMostrarEmpleadosPorDepart()"/>
        private void LBItemClickDepart(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;
            if (lb.SelectedItem == null) return;

            LBDepart.SelectedIndex = lb.SelectedIndex;
            LBLocalizacion.SelectedIndex = lb.SelectedIndex;
            LBIDDepart.SelectedIndex = lb.SelectedIndex;
            
            BuscarYMostrarEmpleadosPorDepart();     
        }

        /// <summary>
        /// Controlador del eventos click sobre los item de las LB de los datos del registro. Al seleccionar un item,
        /// cambia automaticamente la selección del resto de LB y se vuelcan los datos a los TextBox para la actualización /
        /// creación de un registro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            if (LBIDEmple.SelectedItem == null) return;
            InsertarDatosEmpleado();       
        }

        /// <summary>
        /// Este método inserta los datos de las ListBox en los TextBox correspondiente.
        /// </summary>
        private void InsertarDatosEmpleado()
        {
            TBApellidos.Text = LBApellidos.SelectedItem.ToString();
            TBOficio.Text = LBOficio.SelectedItem.ToString();
            TBSalario.Text = LBSalario.SelectedItem.ToString();
            TBFechaAlta.Text = LBFechaAlta.SelectedItem.ToString();
            TBComision.Text = LBComision.SelectedItem.ToString();

        }

        /// <summary>
        /// Controlador del evento click sobre las flechas. Según el botón fuente, sube o baja la selección sobre las ListBox
        /// con los datos de los empleados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks> Es cíclico, desde el último item si seguimos "bajando" pasamos al primero y viceversa </remarks>
        private void BtnFlechasClick(object sender, EventArgs e)
        {
            // Establezco el nuevo índice para los items
            int newIndex = 0;
            if ((Button)sender == BtnFlechaArriba)
            {
                newIndex = LBApellidos.SelectedIndex >= 1 ? LBIDEmple.SelectedIndex - 1 : LBIDEmple.Items.Count - 1;
            }
            else
            {
                newIndex = LBApellidos.SelectedIndex < LBApellidos.Items.Count - 1 ? LBIDEmple.SelectedIndex + 1 : 0;
            }

            // Setteo el nuevo indice a todas las LB
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

            // El item seleccionado vuelca los datos en los TB para la actualización / creación de un registro.
            InsertarDatosEmpleado();
        }

        /// <summary>
        /// Método que limpia los datos de las ListBox
        /// </summary>
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

        /// <summary>
        /// Controlador del evento click sobre el botón buscar. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks> Antes de lanzar la búsqueda, se verifica que los datos de los TB sean válidos para la búsqueda.</remarks>
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            String columna = TbBuscarEmple.Text;
            if (!VerificarInputBuscar()) return; // si los datos no son válidos se retorna

            
            BuscarYMostrarEmpleadosBusqueda(TbBuscarEmple.Text, CbBuscar.SelectedItem.ToString());
            if(LBIDEmple.Items.Count > 0) // Si hay datos válidos, se pasa el foco al listado de resultados.
            {
                LBApellidos.Focus();
                BtnFlechasClick(BtnFlechaAbajo, null);                
            }
            
        }

        /// <summary>
        /// Este método busca y muestra los registros encontrados durante lá búsqueda.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="column"></param>
        private void BuscarYMostrarEmpleadosBusqueda(String input, String column)
        {
            isSearch = true; // Guardo que estamos en una búsqueda

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

        /// <summary>
        /// Este método verifica la valided de los inputs de los TB antes de realizar una búsqueda.
        /// </summary>
        /// <returns>true si los inputs son correctos, false si no lo son.</returns>
        /// <remarks> Lanza un mensaje al usuario si hay algún error.</remarks>
        /// <see cref="Regex.IsMatch(string, string)"/>
        /// <see cref="LanzarError(string, string)"/>
        private bool VerificarInputBuscar()
        {
            if (CbBuscar.SelectedItem == null)
            {
                LanzarError("de la categoría seleccionada", "buscar");
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

        /// <summary>
        /// Método para establecer la configuración del ToolTip
        /// </summary>
        private void ConfigTT()
        {
            string info = "Al crear un nuevo registro, se añadirá al departamento que esté seleccionado";
            TTInfo.SetToolTip(LblInfo, info);
        }

        /// <summary>
        /// Este método lanza un nuevo aviso de error. Recibe por argumento el campo donde está el error y la acción que se estaba
        /// llevando a cabo.
        /// </summary>
        /// <param name="textBox"></param>
        /// <param name="accion"></param>
        private void LanzarError(string textBox, string accion)
        {
            MessageBox.Show("Hay un error en el campo " + textBox + ". Ha sido imposible " + accion + " los datos del usuario.");           
        }

        /// <summary>
        /// Controlador del evento click de los borones "Nuevo", "Actualizar" y "Borrar". 
        /// </summary>
        /// <param name="sender">Buttont fuente</param>
        /// <param name="e"></param>
        private void BtnDatosEmple_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (!VerificarInputEmpleado(btn)) return;
            if (btn == BtnNuevo)
            {
                GuardarEmpleNuevo();
            } 
            else if (btn == BtnActualizar)
            {
                ActualizarEmple();
            } 
            else if (btn == BtnBorrar)
            {
                BorrarEmple();
            }
        }

        /// <summary>
        /// Métodoo para guardar un nuevo registro en la base de datos. No he podido usar el método anterior para 
        /// comprobar la valided de los inputs, ya que necesitaba comprobar requisitos diferentes.
        /// </summary>
        private void GuardarEmpleNuevo()
        {
            if (!VerificarInputEmpleado(BtnNuevo)) return;
            OleDbParameter[] parametros = GetParametersEmple(BtnNuevo);

            command = conexion.CreateCommand();
            command.CommandText = "INSERT INTO emple(" +
                                        "emp_no," +
                                        " apellido," +
                                        " oficio," +
                                        " salario," +
                                        " fecha_alt," +
                                        " comision," +
                                        " dept_no) " +
                                  "VALUES(@empNo, @apellido, @oficio, @salario, @fechaAlta, @comision, @deptNo)";


            foreach (OleDbParameter param in parametros)
            {
                command.Parameters.Add(param);
            }

            command.ExecuteNonQuery();
            MessageBox.Show("Se ha insertado correctamente el registro.");

            // Según estemos o no en una búsqueda, tras crear el registro se mostrarán los datos de la búsqueda o del 
            // departamento seleccionado.
            if (!isSearch)
            {
                BuscarYMostrarEmpleadosPorDepart();
            }
            else
            {
                BtnBuscar_Click(BtnBuscar, null);
            }
        }

        /// <summary>
        /// Método que actualiza el empleado seleccionado.
        /// </summary>
        private void ActualizarEmple()
        {
            OleDbParameter[] parametros = GetParametersEmple(BtnActualizar);

            command = conexion.CreateCommand();
            command.CommandText = "UPDATE emple SET" +
                                        " apellido = @apellido," +
                                        " oficio = @oficio," +
                                        " salario = @salario," +
                                        " fecha_alt = @fechaAlta," +
                                        " comision = @comision," +
                                        " dept_no = @deptNo" +
                                  " WHERE EMP_NO = @emp_no";

            foreach (OleDbParameter param in parametros)
            {
                command.Parameters.Add(param);
            }
            
            command.ExecuteNonQuery();
            MessageBox.Show("Se ha modificado el registro.");

            if (!isSearch)
            {
                BuscarYMostrarEmpleadosPorDepart();
            }
            else
            {
                BtnBuscar_Click(BtnBuscar, null);
            }
        }
        
        /// <summary>
        /// Método para borrar el empleado seleccionado de la base de datos
        /// </summary>
        private void BorrarEmple()
        {
            int numberEmple = Convert.ToInt32(LBIDEmple.SelectedItem.ToString());
            command = conexion.CreateCommand();
            command.CommandText = "DELETE FROM emple WHERE EMP_NO = " + numberEmple;
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

        /// <summary>
        /// Método para generar un nuevo ID para un empleado nuevo.
        /// </summary>
        /// <returns>
        /// Número ID nuevo generado si todo el proceso a sido correcto o 0 si hay algún error.
        /// </returns>
        /// <remarks> Consulta sobre la base de datos el ID más alto, le suma uno y lo devuleve</remarks>
        private int GenerarNumEmple()
        {
            command.CommandText = "SELECT MAX(emp_no) AS idMax FROM emple";
            IDataReader dataReader = command.ExecuteReader();
            int idMax = 0;
            while (dataReader.Read())
            {
                idMax = Convert.ToInt32(dataReader["idMax"]);
            }
            dataReader.Close();
            return idMax + 1;
        }

        /// <summary>
        /// Método que devuelve un array de los parámetros necesarios para crear o actualizar un registro.
        /// </summary>
        /// <param name="btn"></param>
        /// <returns>array de OleDBParameter con los parametros requeridos</returns>
        /// <remarks>Según el botón se devulve el array en un orden u otro</remarks>
        private OleDbParameter[] GetParametersEmple(Button btn)
        {
            string apellidos = TBApellidos.Text;
            string oficio = TBOficio.Text;
            int salario = Convert.ToInt32(TBSalario.Text);
            string fechaAlta = TBFechaAlta.Text;
            int comision = Convert.ToInt32(TBComision.Text);
            int numberEmple = btn == BtnActualizar ? Convert.ToInt32(LBIDEmple.SelectedItem.ToString()) : GenerarNumEmple();

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
            OleDbParameter paramDeptNo = new OleDbParameter("@deptNo", LBIDDepart.SelectedItem.ToString());
            paramDeptNo.Direction = ParameterDirection.Input;
            OleDbParameter paramEmpNo = new OleDbParameter("@empNo", numberEmple);
            paramEmpNo.Direction = ParameterDirection.Input;

            if (btn == BtnActualizar)
            {
                return new OleDbParameter[] { paramApellido, paramOficio, paramSalario, paramFechaAlta, paramComision, paramDeptNo, paramEmpNo };
            }
            else
            {
                return new OleDbParameter[] { paramEmpNo, paramApellido, paramOficio, paramSalario, paramFechaAlta, paramComision, paramDeptNo };
            }
        }

        /// <summary>
        /// Método que comprueba la validez de los datos de un empleado para guardarlo, actualizarlo o borrarlo
        /// de la base de datos. Hace uso de patrone regex en algunos casos
        /// </summary>
        /// <param name="actionButton">Botoón fuente del evento. Según la acción se comprobarán los inputs.</param>
        /// <returns>true si los inputs son correctos, false si no lo son</returns>
        /// <remarks>El método lanza un mensanje al usuario indicandole la causa del error si lo hubiera</remarks>
        /// <see cref="Regex.IsMatch(string, string)"/>
        /// <see cref="LanzarError(string, string)"/>       
        private bool VerificarInputEmpleado(Button actionButton)
        {
            if (actionButton == BtnActualizar || actionButton == BtnBorrar)
            {
                if (LBIDEmple.SelectedItem == null)
                {
                    MessageBox.Show("Tiene que seleccionar al empleado que quiere " + actionButton.Tag + ".");
                    return false;
                }
            }
            else
            {
                if (LBIDDepart.SelectedItem == null)
                {
                    MessageBox.Show("Tiene que seleccionar el departamento para " + actionButton.Tag + " al empleado.");
                    return false;
                }
            }

            if (TBApellidos.Text.Length == 0)
            {
                LanzarError(LblApellidos.Text, (string)actionButton.Tag);
                return false;
            }

            if (TBOficio.Text.Length == 0)
            {
                LanzarError(LblOficio.Text, (string)actionButton.Tag);
                return false;
            }

            if (TBSalario.Text.Length == 0 || !Regex.IsMatch(TBSalario.Text, @"^\d+$"))
            {
                LanzarError(LblSalario.Text, (string)actionButton.Tag);
                return false;
            }

            if (TBFechaAlta.Text.Length == 0 || !Regex.IsMatch(TBFechaAlta.Text, @"^\d{2}/\d{2}/\d{4}$"))
            {
                LanzarError(LblFechaAlta.Text, (string)actionButton.Tag);
                return false;
            }

            if (TBComision.Text.Length == 0 || !Regex.IsMatch(TBComision.Text, @"^\d+$"))
            {
                LanzarError(LblComision.Text, (string)actionButton.Tag);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Controlador del eventro Press del TextBox del área de búsqueda. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks> Si al terminar de escribir se presiona ENTER, se llama al controlador del evento click del
        /// botón buscar. </remarks>
        private void TbBuscarEmple_KeyPress(object sender, KeyPressEventArgs e)
        {            
            Keys press = (Keys)e.KeyChar;
            
            if (press == Keys.Enter)
            {
                e.Handled = true; // Por defecto la tecla ENTER hace un sonido bastante molesto. Esto indica que el evento esta controlado
                                  // y deja de emitir el sonido.  
                BtnBuscar_Click(sender, null);
            } 
        }

        /// <summary>
        /// Controlador del evento click del Label que hay sobre el TextBox de área de búsqueda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LblBorrarInput_Click(object sender, EventArgs e)
        {
            TbBuscarEmple.Text = "";
        }
    }
}
