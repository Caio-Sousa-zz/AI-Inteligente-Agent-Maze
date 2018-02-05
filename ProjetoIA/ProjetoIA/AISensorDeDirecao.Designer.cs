namespace ProjetoIA
{
    partial class AISensorDeDirecao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AISensorDeDirecao));
            this.DtgMapa = new System.Windows.Forms.DataGridView();
            this.btnProximoPasso = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnNorth = new System.Windows.Forms.Button();
            this.btnSouth = new System.Windows.Forms.Button();
            this.btnWest = new System.Windows.Forms.Button();
            this.btnEast = new System.Windows.Forms.Button();
            this.lblVidas = new System.Windows.Forms.Label();
            this.lblQtdVidas = new System.Windows.Forms.Label();
            this.btnM1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnM3 = new System.Windows.Forms.Button();
            this.btnM4 = new System.Windows.Forms.Button();
            this.btnM2 = new System.Windows.Forms.Button();
            this.btnRandomMap = new System.Windows.Forms.Button();
            this.btnConhecimento = new System.Windows.Forms.Button();
            this.dtgSolucao = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DtgMapa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolucao)).BeginInit();
            this.SuspendLayout();
            // 
            // DtgMapa
            // 
            this.DtgMapa.AllowUserToAddRows = false;
            this.DtgMapa.AllowUserToDeleteRows = false;
            this.DtgMapa.AllowUserToResizeColumns = false;
            this.DtgMapa.AllowUserToResizeRows = false;
            this.DtgMapa.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DtgMapa.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DtgMapa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DtgMapa.DefaultCellStyle = dataGridViewCellStyle1;
            this.DtgMapa.Location = new System.Drawing.Point(12, 12);
            this.DtgMapa.Name = "DtgMapa";
            this.DtgMapa.ReadOnly = true;
            this.DtgMapa.RowHeadersVisible = false;
            this.DtgMapa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DtgMapa.ShowEditingIcon = false;
            this.DtgMapa.Size = new System.Drawing.Size(254, 195);
            this.DtgMapa.TabIndex = 0;
            // 
            // btnProximoPasso
            // 
            this.btnProximoPasso.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnProximoPasso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProximoPasso.Location = new System.Drawing.Point(169, 213);
            this.btnProximoPasso.Name = "btnProximoPasso";
            this.btnProximoPasso.Size = new System.Drawing.Size(109, 23);
            this.btnProximoPasso.TabIndex = 1;
            this.btnProximoPasso.Text = "Next Step";
            this.btnProximoPasso.UseVisualStyleBackColor = true;
            this.btnProximoPasso.Click += new System.EventHandler(this.btnProximoPasso_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(364, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btnNorth
            // 
            this.btnNorth.ForeColor = System.Drawing.SystemColors.Window;
            this.btnNorth.Location = new System.Drawing.Point(373, 43);
            this.btnNorth.Name = "btnNorth";
            this.btnNorth.Size = new System.Drawing.Size(32, 32);
            this.btnNorth.TabIndex = 4;
            this.btnNorth.Text = "N";
            this.btnNorth.UseVisualStyleBackColor = true;
            // 
            // btnSouth
            // 
            this.btnSouth.Location = new System.Drawing.Point(373, 137);
            this.btnSouth.Name = "btnSouth";
            this.btnSouth.Size = new System.Drawing.Size(32, 32);
            this.btnSouth.TabIndex = 5;
            this.btnSouth.Text = "S";
            this.btnSouth.UseVisualStyleBackColor = true;
            // 
            // btnWest
            // 
            this.btnWest.Location = new System.Drawing.Point(326, 90);
            this.btnWest.Name = "btnWest";
            this.btnWest.Size = new System.Drawing.Size(32, 32);
            this.btnWest.TabIndex = 6;
            this.btnWest.Text = "W";
            this.btnWest.UseVisualStyleBackColor = true;
            // 
            // btnEast
            // 
            this.btnEast.Location = new System.Drawing.Point(420, 90);
            this.btnEast.Name = "btnEast";
            this.btnEast.Size = new System.Drawing.Size(32, 32);
            this.btnEast.TabIndex = 7;
            this.btnEast.Text = "E";
            this.btnEast.UseVisualStyleBackColor = true;
            // 
            // lblVidas
            // 
            this.lblVidas.AutoSize = true;
            this.lblVidas.BackColor = System.Drawing.SystemColors.Window;
            this.lblVidas.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblVidas.Location = new System.Drawing.Point(13, 223);
            this.lblVidas.Name = "lblVidas";
            this.lblVidas.Size = new System.Drawing.Size(35, 13);
            this.lblVidas.TabIndex = 8;
            this.lblVidas.Text = "Lives:";
            // 
            // lblQtdVidas
            // 
            this.lblQtdVidas.AutoSize = true;
            this.lblQtdVidas.BackColor = System.Drawing.SystemColors.Window;
            this.lblQtdVidas.ForeColor = System.Drawing.SystemColors.MenuText;
            this.lblQtdVidas.Location = new System.Drawing.Point(55, 223);
            this.lblQtdVidas.Name = "lblQtdVidas";
            this.lblQtdVidas.Size = new System.Drawing.Size(13, 13);
            this.lblQtdVidas.TabIndex = 9;
            this.lblQtdVidas.Text = "2";
            // 
            // btnM1
            // 
            this.btnM1.BackColor = System.Drawing.Color.Transparent;
            this.btnM1.ForeColor = System.Drawing.SystemColors.Window;
            this.btnM1.Location = new System.Drawing.Point(6, 19);
            this.btnM1.Name = "btnM1";
            this.btnM1.Size = new System.Drawing.Size(20, 20);
            this.btnM1.TabIndex = 11;
            this.btnM1.Text = "1";
            this.btnM1.UseVisualStyleBackColor = false;
            this.btnM1.Click += new System.EventHandler(this.btnM1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnM3);
            this.groupBox1.Controls.Add(this.btnM4);
            this.groupBox1.Controls.Add(this.btnM2);
            this.groupBox1.Controls.Add(this.btnM1);
            this.groupBox1.Location = new System.Drawing.Point(12, 294);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(116, 44);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Maps";
            // 
            // btnM3
            // 
            this.btnM3.BackColor = System.Drawing.Color.Transparent;
            this.btnM3.ForeColor = System.Drawing.SystemColors.Window;
            this.btnM3.Location = new System.Drawing.Point(58, 19);
            this.btnM3.Name = "btnM3";
            this.btnM3.Size = new System.Drawing.Size(20, 20);
            this.btnM3.TabIndex = 14;
            this.btnM3.Text = "3";
            this.btnM3.UseVisualStyleBackColor = false;
            this.btnM3.Click += new System.EventHandler(this.btnM3_Click);
            // 
            // btnM4
            // 
            this.btnM4.BackColor = System.Drawing.Color.Transparent;
            this.btnM4.ForeColor = System.Drawing.SystemColors.Window;
            this.btnM4.Location = new System.Drawing.Point(84, 19);
            this.btnM4.Name = "btnM4";
            this.btnM4.Size = new System.Drawing.Size(20, 20);
            this.btnM4.TabIndex = 13;
            this.btnM4.Text = "4";
            this.btnM4.UseVisualStyleBackColor = false;
            this.btnM4.Click += new System.EventHandler(this.btnM4_Click);
            // 
            // btnM2
            // 
            this.btnM2.BackColor = System.Drawing.Color.Transparent;
            this.btnM2.ForeColor = System.Drawing.SystemColors.Window;
            this.btnM2.Location = new System.Drawing.Point(32, 19);
            this.btnM2.Name = "btnM2";
            this.btnM2.Size = new System.Drawing.Size(20, 20);
            this.btnM2.TabIndex = 12;
            this.btnM2.Text = "2";
            this.btnM2.UseVisualStyleBackColor = false;
            this.btnM2.Click += new System.EventHandler(this.btnM2_Click);
            // 
            // btnRandomMap
            // 
            this.btnRandomMap.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnRandomMap.Location = new System.Drawing.Point(134, 310);
            this.btnRandomMap.Name = "btnRandomMap";
            this.btnRandomMap.Size = new System.Drawing.Size(56, 23);
            this.btnRandomMap.TabIndex = 13;
            this.btnRandomMap.Text = "Random";
            this.btnRandomMap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRandomMap.UseVisualStyleBackColor = true;
            this.btnRandomMap.Click += new System.EventHandler(this.btnRandomMap_Click);
            // 
            // btnConhecimento
            // 
            this.btnConhecimento.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btnConhecimento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConhecimento.Location = new System.Drawing.Point(134, 242);
            this.btnConhecimento.Name = "btnConhecimento";
            this.btnConhecimento.Size = new System.Drawing.Size(144, 23);
            this.btnConhecimento.TabIndex = 14;
            this.btnConhecimento.Text = "Use Knowledge";
            this.btnConhecimento.UseVisualStyleBackColor = true;
            this.btnConhecimento.Click += new System.EventHandler(this.btnConhecimento_Click);
            // 
            // dtgSolucao
            // 
            this.dtgSolucao.AllowUserToAddRows = false;
            this.dtgSolucao.AllowUserToDeleteRows = false;
            this.dtgSolucao.AllowUserToResizeColumns = false;
            this.dtgSolucao.AllowUserToResizeRows = false;
            this.dtgSolucao.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dtgSolucao.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dtgSolucao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgSolucao.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dtgSolucao.Location = new System.Drawing.Point(284, 213);
            this.dtgSolucao.MultiSelect = false;
            this.dtgSolucao.Name = "dtgSolucao";
            this.dtgSolucao.RowHeadersVisible = false;
            this.dtgSolucao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgSolucao.Size = new System.Drawing.Size(207, 123);
            this.dtgSolucao.TabIndex = 15;
            // 
            // AISensorDeDirecao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(504, 346);
            this.ControlBox = false;
            this.Controls.Add(this.dtgSolucao);
            this.Controls.Add(this.btnConhecimento);
            this.Controls.Add(this.btnRandomMap);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblQtdVidas);
            this.Controls.Add(this.lblVidas);
            this.Controls.Add(this.btnEast);
            this.Controls.Add(this.btnWest);
            this.Controls.Add(this.btnSouth);
            this.Controls.Add(this.btnNorth);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnProximoPasso);
            this.Controls.Add(this.DtgMapa);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "AISensorDeDirecao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IA :: Direction Sensor";
            this.Load += new System.EventHandler(this.AISensorDeDirecao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgMapa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgSolucao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgMapa;
        private System.Windows.Forms.Button btnProximoPasso;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnNorth;
        private System.Windows.Forms.Button btnSouth;
        private System.Windows.Forms.Button btnWest;
        private System.Windows.Forms.Button btnEast;
        private System.Windows.Forms.Label lblVidas;
        private System.Windows.Forms.Label lblQtdVidas;
        private System.Windows.Forms.Button btnM1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnM3;
        private System.Windows.Forms.Button btnM4;
        private System.Windows.Forms.Button btnM2;
        private System.Windows.Forms.Button btnRandomMap;
        private System.Windows.Forms.Button btnConhecimento;
        private System.Windows.Forms.DataGridView dtgSolucao;
    }
}