namespace AutoClicker
{
    partial class AutoClicker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTickInterval = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ClickList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.txtClickChangeName = new System.Windows.Forms.ToolStripTextBox();
            this.btnBorrarClick = new System.Windows.Forms.ToolStripMenuItem();
            this.StartKeyButton = new System.Windows.Forms.Button();
            this.StopKeyButton = new System.Windows.Forms.Button();
            this.CapKeyButton = new System.Windows.Forms.Button();
            this.cbxMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.helpTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.chkAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.listMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Retraso entre clics";
            // 
            // txtTickInterval
            // 
            this.txtTickInterval.Location = new System.Drawing.Point(112, 60);
            this.txtTickInterval.Name = "txtTickInterval";
            this.txtTickInterval.Size = new System.Drawing.Size(66, 20);
            this.txtTickInterval.TabIndex = 15;
            this.txtTickInterval.Text = "30";
            this.txtTickInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTickInterval.TextChanged += new System.EventHandler(this.TxtTickIntervalChange);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(184, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "ms";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Iniciar con";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(107, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Detener al pulsar";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Obtener coordenadas usando";
            // 
            // ClickList
            // 
            this.ClickList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClickList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.ClickList.ContextMenuStrip = this.listMenu;
            this.ClickList.FullRowSelect = true;
            this.ClickList.GridLines = true;
            this.ClickList.HideSelection = false;
            this.ClickList.LabelEdit = true;
            this.ClickList.Location = new System.Drawing.Point(217, 12);
            this.ClickList.Name = "ClickList";
            this.ClickList.Size = new System.Drawing.Size(407, 225);
            this.ClickList.TabIndex = 16;
            this.ClickList.UseCompatibleStateImageBehavior = false;
            this.ClickList.View = System.Windows.Forms.View.Details;
            this.ClickList.DoubleClick += new System.EventHandler(this.ClickList_DoubleClick);
            this.ClickList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.onClicksKeyUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Orden";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Coordenadas";
            this.columnHeader2.Width = 98;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nombre";
            this.columnHeader3.Width = 204;
            // 
            // listMenu
            // 
            this.listMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.ctxSeparator1,
            this.txtClickChangeName,
            this.btnBorrarClick});
            this.listMenu.Name = "listMenu";
            this.listMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.listMenu.Size = new System.Drawing.Size(195, 101);
            this.listMenu.Opening += new System.ComponentModel.CancelEventHandler(this.OpeningMenu);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem1.Text = "Guardar lista de clicks";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.SaveListToFile);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(194, 22);
            this.toolStripMenuItem2.Text = "Cargar desde archivo...";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.LoadClicksFromFile);
            // 
            // ctxSeparator1
            // 
            this.ctxSeparator1.Name = "ctxSeparator1";
            this.ctxSeparator1.Size = new System.Drawing.Size(191, 6);
            // 
            // txtClickChangeName
            // 
            this.txtClickChangeName.BackColor = System.Drawing.SystemColors.Info;
            this.txtClickChangeName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtClickChangeName.Name = "txtClickChangeName";
            this.txtClickChangeName.Size = new System.Drawing.Size(100, 23);
            this.txtClickChangeName.TextChanged += new System.EventHandler(this.ChangingClickName);
            // 
            // btnBorrarClick
            // 
            this.btnBorrarClick.Name = "btnBorrarClick";
            this.btnBorrarClick.Size = new System.Drawing.Size(194, 22);
            this.btnBorrarClick.Text = "Eliminar click";
            this.btnBorrarClick.Click += new System.EventHandler(this.btnBorrarClick_Click);
            // 
            // StartKeyButton
            // 
            this.StartKeyButton.Location = new System.Drawing.Point(12, 179);
            this.StartKeyButton.Name = "StartKeyButton";
            this.StartKeyButton.Size = new System.Drawing.Size(91, 23);
            this.StartKeyButton.TabIndex = 17;
            this.StartKeyButton.Text = "[F7]";
            this.helpTooltip.SetToolTip(this.StartKeyButton, "Click para configurar tecla de inicio");
            this.StartKeyButton.UseVisualStyleBackColor = true;
            this.StartKeyButton.Click += new System.EventHandler(this.setKey_clic);
            // 
            // StopKeyButton
            // 
            this.StopKeyButton.Location = new System.Drawing.Point(110, 179);
            this.StopKeyButton.Name = "StopKeyButton";
            this.StopKeyButton.Size = new System.Drawing.Size(91, 23);
            this.StopKeyButton.TabIndex = 17;
            this.StopKeyButton.Text = "[F8]";
            this.helpTooltip.SetToolTip(this.StopKeyButton, "Click para configurar tecla de detencion");
            this.StopKeyButton.UseVisualStyleBackColor = true;
            this.StopKeyButton.Click += new System.EventHandler(this.setKey_clic);
            // 
            // CapKeyButton
            // 
            this.CapKeyButton.Location = new System.Drawing.Point(12, 118);
            this.CapKeyButton.Name = "CapKeyButton";
            this.CapKeyButton.Size = new System.Drawing.Size(91, 23);
            this.CapKeyButton.TabIndex = 17;
            this.CapKeyButton.Text = "[F9]";
            this.helpTooltip.SetToolTip(this.CapKeyButton, "Click para configurar tecla de captura");
            this.CapKeyButton.UseVisualStyleBackColor = true;
            this.CapKeyButton.Click += new System.EventHandler(this.setKey_clic);
            // 
            // cbxMode
            // 
            this.cbxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxMode.FormattingEnabled = true;
            this.cbxMode.Items.AddRange(new object[] {
            "Bucle en orden",
            "Bucle ida y vuelta",
            "Una vez en orden",
            "Una vez ida y vuelta"});
            this.cbxMode.Location = new System.Drawing.Point(14, 28);
            this.cbxMode.Name = "cbxMode";
            this.cbxMode.Size = new System.Drawing.Size(187, 21);
            this.cbxMode.TabIndex = 18;
            this.helpTooltip.SetToolTip(this.cbxMode, "Modo de ejecución:\r\nIndica el orden de ejecución de los clicks y si se hara en bu" +
        "cle o solo una vez");
            this.cbxMode.SelectedIndexChanged += new System.EventHandler(this.cbxMode_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Modo de ejecución";
            // 
            // chkAlwaysOnTop
            // 
            this.chkAlwaysOnTop.AutoSize = true;
            this.chkAlwaysOnTop.Location = new System.Drawing.Point(105, 218);
            this.chkAlwaysOnTop.Name = "chkAlwaysOnTop";
            this.chkAlwaysOnTop.Size = new System.Drawing.Size(96, 17);
            this.chkAlwaysOnTop.TabIndex = 20;
            this.chkAlwaysOnTop.Text = "Siempre visible";
            this.chkAlwaysOnTop.UseVisualStyleBackColor = true;
            this.chkAlwaysOnTop.CheckedChanged += new System.EventHandler(this.chkAlwaysOnTop_CheckedChanged);
            // 
            // AutoClicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 249);
            this.Controls.Add(this.chkAlwaysOnTop);
            this.Controls.Add(this.cbxMode);
            this.Controls.Add(this.CapKeyButton);
            this.Controls.Add(this.StopKeyButton);
            this.Controls.Add(this.StartKeyButton);
            this.Controls.Add(this.ClickList);
            this.Controls.Add(this.txtTickInterval);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.Name = "AutoClicker";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autorim";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoClicker_FormClosing);
            this.LocationChanged += new System.EventHandler(this.AutoClicker_LocationChanged);
            this.listMenu.ResumeLayout(false);
            this.listMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTickInterval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView ClickList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ContextMenuStrip listMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Button StartKeyButton;
        private System.Windows.Forms.Button StopKeyButton;
        private System.Windows.Forms.Button CapKeyButton;
        private System.Windows.Forms.ToolStripTextBox txtClickChangeName;
        private System.Windows.Forms.ToolStripSeparator ctxSeparator1;
        private System.Windows.Forms.ToolStripMenuItem btnBorrarClick;
        private System.Windows.Forms.ToolTip helpTooltip;
        private System.Windows.Forms.ComboBox cbxMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAlwaysOnTop;
    }
}

