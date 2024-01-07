
namespace GestionEmpleados
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LBDepart = new System.Windows.Forms.ListBox();
            this.LBLocalizacion = new System.Windows.Forms.ListBox();
            this.LblDepartamento = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LBApellidos = new System.Windows.Forms.ListBox();
            this.LBOficio = new System.Windows.Forms.ListBox();
            this.LBSalario = new System.Windows.Forms.ListBox();
            this.LBFechaAlta = new System.Windows.Forms.ListBox();
            this.LBComision = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TBApellidos = new System.Windows.Forms.TextBox();
            this.TBOficio = new System.Windows.Forms.TextBox();
            this.TBSalario = new System.Windows.Forms.TextBox();
            this.TBFechaAlta = new System.Windows.Forms.TextBox();
            this.TBComision = new System.Windows.Forms.TextBox();
            this.LBIDDepart = new System.Windows.Forms.ListBox();
            this.LBIDEmple = new System.Windows.Forms.ListBox();
            this.BtnFlechaArriba = new System.Windows.Forms.Button();
            this.BtnFlechaAbajo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblBorrarInput = new System.Windows.Forms.Label();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.TbBuscarEmple = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CbBuscar = new System.Windows.Forms.ComboBox();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.BtnBorrar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.LblInfo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LBDeptNoEmple = new System.Windows.Forms.ListBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.TTInfo = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBDepart
            // 
            this.LBDepart.FormattingEnabled = true;
            this.LBDepart.ItemHeight = 11;
            this.LBDepart.Location = new System.Drawing.Point(27, 27);
            this.LBDepart.Name = "LBDepart";
            this.LBDepart.Size = new System.Drawing.Size(116, 81);
            this.LBDepart.TabIndex = 0;
            this.LBDepart.Click += new System.EventHandler(this.LBItemClickDepart);
            // 
            // LBLocalizacion
            // 
            this.LBLocalizacion.FormattingEnabled = true;
            this.LBLocalizacion.ItemHeight = 11;
            this.LBLocalizacion.Location = new System.Drawing.Point(152, 27);
            this.LBLocalizacion.Name = "LBLocalizacion";
            this.LBLocalizacion.Size = new System.Drawing.Size(116, 81);
            this.LBLocalizacion.TabIndex = 1;
            this.LBLocalizacion.Click += new System.EventHandler(this.LBItemClickDepart);
            // 
            // LblDepartamento
            // 
            this.LblDepartamento.AutoSize = true;
            this.LblDepartamento.Location = new System.Drawing.Point(27, 11);
            this.LblDepartamento.Name = "LblDepartamento";
            this.LblDepartamento.Size = new System.Drawing.Size(89, 11);
            this.LblDepartamento.TabIndex = 2;
            this.LblDepartamento.Text = "Departamento";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 11);
            this.label2.TabIndex = 3;
            this.label2.Text = "Localización";
            // 
            // LBApellidos
            // 
            this.LBApellidos.FormattingEnabled = true;
            this.LBApellidos.ItemHeight = 11;
            this.LBApellidos.Location = new System.Drawing.Point(30, 58);
            this.LBApellidos.Name = "LBApellidos";
            this.LBApellidos.Size = new System.Drawing.Size(117, 114);
            this.LBApellidos.TabIndex = 4;
            this.LBApellidos.Click += new System.EventHandler(this.LBItemClickEmple);
            // 
            // LBOficio
            // 
            this.LBOficio.FormattingEnabled = true;
            this.LBOficio.ItemHeight = 11;
            this.LBOficio.Location = new System.Drawing.Point(155, 58);
            this.LBOficio.Name = "LBOficio";
            this.LBOficio.Size = new System.Drawing.Size(116, 114);
            this.LBOficio.TabIndex = 5;
            this.LBOficio.Click += new System.EventHandler(this.LBItemClickEmple);
            // 
            // LBSalario
            // 
            this.LBSalario.FormattingEnabled = true;
            this.LBSalario.ItemHeight = 11;
            this.LBSalario.Location = new System.Drawing.Point(278, 58);
            this.LBSalario.Name = "LBSalario";
            this.LBSalario.Size = new System.Drawing.Size(87, 114);
            this.LBSalario.TabIndex = 6;
            this.LBSalario.Click += new System.EventHandler(this.LBItemClickEmple);
            // 
            // LBFechaAlta
            // 
            this.LBFechaAlta.FormattingEnabled = true;
            this.LBFechaAlta.ItemHeight = 11;
            this.LBFechaAlta.Location = new System.Drawing.Point(373, 58);
            this.LBFechaAlta.Name = "LBFechaAlta";
            this.LBFechaAlta.Size = new System.Drawing.Size(87, 114);
            this.LBFechaAlta.TabIndex = 7;
            this.LBFechaAlta.Click += new System.EventHandler(this.LBItemClickEmple);
            // 
            // LBComision
            // 
            this.LBComision.FormattingEnabled = true;
            this.LBComision.ItemHeight = 11;
            this.LBComision.Location = new System.Drawing.Point(467, 58);
            this.LBComision.Name = "LBComision";
            this.LBComision.Size = new System.Drawing.Size(53, 114);
            this.LBComision.TabIndex = 8;
            this.LBComision.Click += new System.EventHandler(this.LBItemClickEmple);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 11);
            this.label1.TabIndex = 9;
            this.label1.Text = "Apellidos";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 11);
            this.label3.TabIndex = 10;
            this.label3.Text = "Oficio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 11);
            this.label4.TabIndex = 11;
            this.label4.Text = "Salario";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(371, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 11);
            this.label5.TabIndex = 12;
            this.label5.Text = "Fecha alta";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(465, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 11);
            this.label6.TabIndex = 13;
            this.label6.Text = "Comisión";
            // 
            // TBApellidos
            // 
            this.TBApellidos.Location = new System.Drawing.Point(29, 174);
            this.TBApellidos.Name = "TBApellidos";
            this.TBApellidos.Size = new System.Drawing.Size(116, 18);
            this.TBApellidos.TabIndex = 14;
            // 
            // TBOficio
            // 
            this.TBOficio.Location = new System.Drawing.Point(155, 174);
            this.TBOficio.Name = "TBOficio";
            this.TBOficio.Size = new System.Drawing.Size(116, 18);
            this.TBOficio.TabIndex = 15;
            // 
            // TBSalario
            // 
            this.TBSalario.Location = new System.Drawing.Point(277, 174);
            this.TBSalario.Name = "TBSalario";
            this.TBSalario.Size = new System.Drawing.Size(87, 18);
            this.TBSalario.TabIndex = 16;
            // 
            // TBFechaAlta
            // 
            this.TBFechaAlta.Location = new System.Drawing.Point(370, 174);
            this.TBFechaAlta.Name = "TBFechaAlta";
            this.TBFechaAlta.Size = new System.Drawing.Size(87, 18);
            this.TBFechaAlta.TabIndex = 17;
            // 
            // TBComision
            // 
            this.TBComision.Location = new System.Drawing.Point(463, 174);
            this.TBComision.Name = "TBComision";
            this.TBComision.Size = new System.Drawing.Size(53, 18);
            this.TBComision.TabIndex = 18;
            // 
            // LBIDDepart
            // 
            this.LBIDDepart.FormattingEnabled = true;
            this.LBIDDepart.ItemHeight = 11;
            this.LBIDDepart.Location = new System.Drawing.Point(14, 27);
            this.LBIDDepart.Name = "LBIDDepart";
            this.LBIDDepart.Size = new System.Drawing.Size(13, 81);
            this.LBIDDepart.TabIndex = 19;
            this.LBIDDepart.Visible = false;
            this.LBIDDepart.Click += new System.EventHandler(this.LBItemClickDepart);
            // 
            // LBIDEmple
            // 
            this.LBIDEmple.FormattingEnabled = true;
            this.LBIDEmple.ItemHeight = 11;
            this.LBIDEmple.Location = new System.Drawing.Point(17, 58);
            this.LBIDEmple.Name = "LBIDEmple";
            this.LBIDEmple.Size = new System.Drawing.Size(13, 114);
            this.LBIDEmple.TabIndex = 20;
            this.LBIDEmple.Visible = false;
            this.LBIDEmple.Click += new System.EventHandler(this.LBItemClickEmple);
            // 
            // BtnFlechaArriba
            // 
            this.BtnFlechaArriba.BackColor = System.Drawing.Color.PapayaWhip;
            this.BtnFlechaArriba.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnFlechaArriba.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFlechaArriba.Image = ((System.Drawing.Image)(resources.GetObject("BtnFlechaArriba.Image")));
            this.BtnFlechaArriba.Location = new System.Drawing.Point(526, 58);
            this.BtnFlechaArriba.Name = "BtnFlechaArriba";
            this.BtnFlechaArriba.Size = new System.Drawing.Size(64, 55);
            this.BtnFlechaArriba.TabIndex = 21;
            this.BtnFlechaArriba.UseVisualStyleBackColor = false;
            // 
            // BtnFlechaAbajo
            // 
            this.BtnFlechaAbajo.BackColor = System.Drawing.Color.PapayaWhip;
            this.BtnFlechaAbajo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnFlechaAbajo.Image = global::GestionEmpleados.Properties.Resources.flecha_circulo_abajo;
            this.BtnFlechaAbajo.Location = new System.Drawing.Point(526, 117);
            this.BtnFlechaAbajo.Name = "BtnFlechaAbajo";
            this.BtnFlechaAbajo.Size = new System.Drawing.Size(64, 55);
            this.BtnFlechaAbajo.TabIndex = 22;
            this.BtnFlechaAbajo.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.BurlyWood;
            this.panel1.Controls.Add(this.LblBorrarInput);
            this.panel1.Controls.Add(this.BtnBuscar);
            this.panel1.Controls.Add(this.TbBuscarEmple);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.CbBuscar);
            this.panel1.Location = new System.Drawing.Point(287, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 108);
            this.panel1.TabIndex = 23;
            // 
            // LblBorrarInput
            // 
            this.LblBorrarInput.AutoSize = true;
            this.LblBorrarInput.BackColor = System.Drawing.Color.White;
            this.LblBorrarInput.Location = new System.Drawing.Point(155, 80);
            this.LblBorrarInput.Name = "LblBorrarInput";
            this.LblBorrarInput.Size = new System.Drawing.Size(12, 11);
            this.LblBorrarInput.TabIndex = 30;
            this.LblBorrarInput.Text = "X";
            this.LblBorrarInput.Click += new System.EventHandler(this.LblBorrarInput_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.BackColor = System.Drawing.Color.White;
            this.BtnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BtnBuscar.Image")));
            this.BtnBuscar.Location = new System.Drawing.Point(182, 38);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(120, 57);
            this.BtnBuscar.TabIndex = 24;
            this.BtnBuscar.UseVisualStyleBackColor = false;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // TbBuscarEmple
            // 
            this.TbBuscarEmple.Location = new System.Drawing.Point(30, 77);
            this.TbBuscarEmple.Name = "TbBuscarEmple";
            this.TbBuscarEmple.Size = new System.Drawing.Size(140, 18);
            this.TbBuscarEmple.TabIndex = 24;
            this.TbBuscarEmple.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbBuscarEmple_KeyPress);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.BurlyWood;
            this.label8.Font = new System.Drawing.Font("Lucida Console", 15F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(0, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(319, 23);
            this.label8.TabIndex = 2;
            this.label8.Text = "Búsqueda de empleado";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 11);
            this.label7.TabIndex = 1;
            this.label7.Text = "Buscar por";
            // 
            // CbBuscar
            // 
            this.CbBuscar.FormattingEnabled = true;
            this.CbBuscar.Location = new System.Drawing.Point(30, 52);
            this.CbBuscar.Name = "CbBuscar";
            this.CbBuscar.Size = new System.Drawing.Size(140, 19);
            this.CbBuscar.Sorted = true;
            this.CbBuscar.TabIndex = 0;
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.BackColor = System.Drawing.Color.BurlyWood;
            this.BtnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnActualizar.Font = new System.Drawing.Font("Lucida Console", 8F);
            this.BtnActualizar.Location = new System.Drawing.Point(503, 131);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(87, 19);
            this.BtnActualizar.TabIndex = 24;
            this.BtnActualizar.Text = "Actualizar";
            this.BtnActualizar.UseVisualStyleBackColor = false;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnBorrar
            // 
            this.BtnBorrar.BackColor = System.Drawing.Color.BurlyWood;
            this.BtnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnBorrar.Location = new System.Drawing.Point(526, 178);
            this.BtnBorrar.Name = "BtnBorrar";
            this.BtnBorrar.Size = new System.Drawing.Size(64, 17);
            this.BtnBorrar.TabIndex = 25;
            this.BtnBorrar.Text = "Borrar";
            this.BtnBorrar.UseVisualStyleBackColor = false;
            this.BtnBorrar.Click += new System.EventHandler(this.BtnBorrar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.BurlyWood;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNuevo.Location = new System.Drawing.Point(526, 154);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(64, 17);
            this.btnNuevo.TabIndex = 26;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Lucida Console", 11F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(27, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(490, 14);
            this.label9.TabIndex = 27;
            this.label9.Text = "Datos para nuevo/actualizar empleado";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblInfo
            // 
            this.LblInfo.AutoSize = true;
            this.LblInfo.Location = new System.Drawing.Point(461, 125);
            this.LblInfo.Name = "LblInfo";
            this.LblInfo.Size = new System.Drawing.Size(12, 11);
            this.LblInfo.TabIndex = 28;
            this.LblInfo.Text = "?";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.BurlyWood;
            this.panel2.Controls.Add(this.LBDeptNoEmple);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.LBFechaAlta);
            this.panel2.Controls.Add(this.LBApellidos);
            this.panel2.Controls.Add(this.LBOficio);
            this.panel2.Controls.Add(this.LBSalario);
            this.panel2.Controls.Add(this.LBComision);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.BtnFlechaAbajo);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.BtnFlechaArriba);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.LBIDEmple);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(-3, 208);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(612, 189);
            this.panel2.TabIndex = 29;
            // 
            // LBDeptNoEmple
            // 
            this.LBDeptNoEmple.FormattingEnabled = true;
            this.LBDeptNoEmple.ItemHeight = 11;
            this.LBDeptNoEmple.Location = new System.Drawing.Point(6, 58);
            this.LBDeptNoEmple.Name = "LBDeptNoEmple";
            this.LBDeptNoEmple.Size = new System.Drawing.Size(13, 114);
            this.LBDeptNoEmple.TabIndex = 31;
            this.LBDeptNoEmple.Visible = false;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Lucida Console", 11F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(3, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(600, 24);
            this.label16.TabIndex = 30;
            this.label16.Text = "Información";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 160);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 11);
            this.label11.TabIndex = 23;
            this.label11.Text = "Apellidos";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(155, 160);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 11);
            this.label12.TabIndex = 24;
            this.label12.Text = "Oficio";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(276, 160);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 11);
            this.label13.TabIndex = 25;
            this.label13.Text = "Salario";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(368, 160);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 11);
            this.label14.TabIndex = 26;
            this.label14.Text = "Fecha alta";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(461, 160);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 11);
            this.label15.TabIndex = 27;
            this.label15.Text = "Comisión";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(606, 395);
            this.Controls.Add(this.BtnActualizar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.LblInfo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.BtnBorrar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LBIDDepart);
            this.Controls.Add(this.TBComision);
            this.Controls.Add(this.TBFechaAlta);
            this.Controls.Add(this.TBSalario);
            this.Controls.Add(this.TBOficio);
            this.Controls.Add(this.TBApellidos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblDepartamento);
            this.Controls.Add(this.LBLocalizacion);
            this.Controls.Add(this.LBDepart);
            this.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de empleados v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LBDepart;
        private System.Windows.Forms.ListBox LBLocalizacion;
        private System.Windows.Forms.Label LblDepartamento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox LBApellidos;
        private System.Windows.Forms.ListBox LBOficio;
        private System.Windows.Forms.ListBox LBSalario;
        private System.Windows.Forms.ListBox LBFechaAlta;
        private System.Windows.Forms.ListBox LBComision;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TBApellidos;
        private System.Windows.Forms.TextBox TBOficio;
        private System.Windows.Forms.TextBox TBSalario;
        private System.Windows.Forms.TextBox TBFechaAlta;
        private System.Windows.Forms.TextBox TBComision;
        private System.Windows.Forms.ListBox LBIDDepart;
        private System.Windows.Forms.ListBox LBIDEmple;
        private System.Windows.Forms.Button BtnFlechaArriba;
        private System.Windows.Forms.Button BtnFlechaAbajo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CbBuscar;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TextBox TbBuscarEmple;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.Button BtnBorrar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label LblInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ToolTip TTInfo;
        private System.Windows.Forms.Label LblBorrarInput;
        private System.Windows.Forms.ListBox LBDeptNoEmple;
    }
}

