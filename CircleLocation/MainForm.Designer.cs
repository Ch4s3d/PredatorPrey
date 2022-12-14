namespace VertexLocation
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureShowing = new System.Windows.Forms.PictureBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.richResumen = new System.Windows.Forms.RichTextBox();
            this.treeGrafo = new System.Windows.Forms.TreeView();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnManualSort = new System.Windows.Forms.Button();
            this.btnAutoSort = new System.Windows.Forms.Button();
            this.btnID = new System.Windows.Forms.Button();
            this.btnPresas = new System.Windows.Forms.Button();
            this.btnDepredadores = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.numericVision = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureShowing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericVision)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1770, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem});
            this.archivoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(216, 34);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // pictureShowing
            // 
            this.pictureShowing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(235)))), ((int)(((byte)(219)))));
            this.pictureShowing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureShowing.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureShowing.Location = new System.Drawing.Point(93, 89);
            this.pictureShowing.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureShowing.Name = "pictureShowing";
            this.pictureShowing.Size = new System.Drawing.Size(1000, 1300);
            this.pictureShowing.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureShowing.TabIndex = 4;
            this.pictureShowing.TabStop = false;
            this.pictureShowing.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureShowing_MouseClick);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(34)))));
            this.buttonClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.buttonClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(0)))), ((int)(((byte)(9)))));
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(0)))), ((int)(((byte)(20)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Arial Narrow", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonClose.Location = new System.Drawing.Point(1730, 3);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(38, 31);
            this.buttonClose.TabIndex = 5;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // richResumen
            // 
            this.richResumen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.richResumen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(155)))), ((int)(((byte)(151)))));
            this.richResumen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richResumen.Location = new System.Drawing.Point(1101, 89);
            this.richResumen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richResumen.Name = "richResumen";
            this.richResumen.Size = new System.Drawing.Size(576, 520);
            this.richResumen.TabIndex = 7;
            this.richResumen.Text = "";
            // 
            // treeGrafo
            // 
            this.treeGrafo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(155)))), ((int)(((byte)(151)))));
            this.treeGrafo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeGrafo.Location = new System.Drawing.Point(1101, 619);
            this.treeGrafo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.treeGrafo.Name = "treeGrafo";
            this.treeGrafo.Size = new System.Drawing.Size(576, 402);
            this.treeGrafo.TabIndex = 8;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.btnStart.Enabled = false;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStart.Location = new System.Drawing.Point(1545, 1222);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(132, 167);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnManualSort
            // 
            this.btnManualSort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.btnManualSort.Enabled = false;
            this.btnManualSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManualSort.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManualSort.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnManualSort.Location = new System.Drawing.Point(1183, 1029);
            this.btnManualSort.Name = "btnManualSort";
            this.btnManualSort.Size = new System.Drawing.Size(241, 74);
            this.btnManualSort.TabIndex = 12;
            this.btnManualSort.Text = "Manual Sort";
            this.btnManualSort.UseVisualStyleBackColor = false;
            this.btnManualSort.Click += new System.EventHandler(this.btnManualSort_Click);
            // 
            // btnAutoSort
            // 
            this.btnAutoSort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.btnAutoSort.Enabled = false;
            this.btnAutoSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoSort.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoSort.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAutoSort.Location = new System.Drawing.Point(1594, 1029);
            this.btnAutoSort.Name = "btnAutoSort";
            this.btnAutoSort.Size = new System.Drawing.Size(83, 74);
            this.btnAutoSort.TabIndex = 13;
            this.btnAutoSort.Text = "?";
            this.btnAutoSort.UseVisualStyleBackColor = false;
            this.btnAutoSort.Click += new System.EventHandler(this.btnAutoSort_Click);
            // 
            // btnID
            // 
            this.btnID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.btnID.Enabled = false;
            this.btnID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnID.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnID.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnID.Location = new System.Drawing.Point(1101, 1029);
            this.btnID.Name = "btnID";
            this.btnID.Size = new System.Drawing.Size(76, 74);
            this.btnID.TabIndex = 14;
            this.btnID.Text = "ID";
            this.btnID.UseVisualStyleBackColor = false;
            this.btnID.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnID_MouseDown_1);
            this.btnID.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnID_MouseUp_1);
            // 
            // btnPresas
            // 
            this.btnPresas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.btnPresas.Enabled = false;
            this.btnPresas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPresas.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPresas.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPresas.Location = new System.Drawing.Point(1403, 1127);
            this.btnPresas.Name = "btnPresas";
            this.btnPresas.Size = new System.Drawing.Size(274, 74);
            this.btnPresas.TabIndex = 15;
            this.btnPresas.Text = "Presas";
            this.btnPresas.UseVisualStyleBackColor = false;
            this.btnPresas.Click += new System.EventHandler(this.btnPresas_Click);
            // 
            // btnDepredadores
            // 
            this.btnDepredadores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.btnDepredadores.Enabled = false;
            this.btnDepredadores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepredadores.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDepredadores.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDepredadores.Location = new System.Drawing.Point(1100, 1127);
            this.btnDepredadores.Name = "btnDepredadores";
            this.btnDepredadores.Size = new System.Drawing.Size(297, 74);
            this.btnDepredadores.TabIndex = 16;
            this.btnDepredadores.Text = "Depredadores";
            this.btnDepredadores.UseVisualStyleBackColor = false;
            this.btnDepredadores.Click += new System.EventHandler(this.btnDepredadores_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(74)))), ((int)(((byte)(82)))));
            this.btnClear.Enabled = false;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Century Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClear.Location = new System.Drawing.Point(1430, 1029);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(158, 74);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // numericVision
            // 
            this.numericVision.Enabled = false;
            this.numericVision.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericVision.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericVision.Location = new System.Drawing.Point(1199, 1300);
            this.numericVision.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericVision.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericVision.Name = "numericVision";
            this.numericVision.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericVision.Size = new System.Drawing.Size(276, 35);
            this.numericVision.TabIndex = 18;
            this.numericVision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericVision.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericVision.ValueChanged += new System.EventHandler(this.numericVision_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(1230, 1268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 29);
            this.label1.TabIndex = 19;
            this.label1.Text = "Campo de vision ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(112)))), ((int)(((byte)(114)))));
            this.ClientSize = new System.Drawing.Size(1770, 1465);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericVision);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDepredadores);
            this.Controls.Add(this.btnPresas);
            this.Controls.Add(this.btnID);
            this.Controls.Add(this.btnAutoSort);
            this.Controls.Add(this.btnManualSort);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.treeGrafo);
            this.Controls.Add(this.richResumen);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.pictureShowing);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Circles";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureShowing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericVision)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureShowing;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.RichTextBox richResumen;
        private System.Windows.Forms.TreeView treeGrafo;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnManualSort;
        private System.Windows.Forms.Button btnAutoSort;
        private System.Windows.Forms.Button btnID;
        private System.Windows.Forms.Button btnPresas;
        private System.Windows.Forms.Button btnDepredadores;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.NumericUpDown numericVision;
        private System.Windows.Forms.Label label1;
    }
}

