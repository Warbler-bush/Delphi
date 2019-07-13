namespace Delphi
{
    partial class UCExpressionEdit
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblOrigine = new System.Windows.Forms.Label();
            this.txtOrigine = new System.Windows.Forms.TextBox();
            this.pnlView = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.lblNota = new System.Windows.Forms.Label();
            this.pnlExpression = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtSpiegazionne = new System.Windows.Forms.TextBox();
            this.lblSpiegazione = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtTesto = new System.Windows.Forms.TextBox();
            this.lblTesto = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.pnlView.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlExpression.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblOrigine);
            this.panel2.Controls.Add(this.txtOrigine);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(376, 133);
            this.panel2.TabIndex = 1;
            // 
            // lblOrigine
            // 
            this.lblOrigine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrigine.Location = new System.Drawing.Point(4, 12);
            this.lblOrigine.Name = "lblOrigine";
            this.lblOrigine.Size = new System.Drawing.Size(115, 23);
            this.lblOrigine.TabIndex = 6;
            this.lblOrigine.Text = "ORIGINE";
            // 
            // txtOrigine
            // 
            this.txtOrigine.BackColor = System.Drawing.Color.DimGray;
            this.txtOrigine.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrigine.ForeColor = System.Drawing.Color.White;
            this.txtOrigine.Location = new System.Drawing.Point(8, 38);
            this.txtOrigine.Multiline = true;
            this.txtOrigine.Name = "txtOrigine";
            this.txtOrigine.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOrigine.Size = new System.Drawing.Size(347, 77);
            this.txtOrigine.TabIndex = 5;
            // 
            // pnlView
            // 
            this.pnlView.Controls.Add(this.lblTitle);
            this.pnlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlView.Location = new System.Drawing.Point(3, 3);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(376, 60);
            this.pnlView.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(4, 10);
            this.lblTitle.MaximumSize = new System.Drawing.Size(379, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(87, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Titolo";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtNota);
            this.panel3.Controls.Add(this.lblNota);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 208);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(376, 128);
            this.panel3.TabIndex = 2;
            // 
            // txtNota
            // 
            this.txtNota.BackColor = System.Drawing.Color.DimGray;
            this.txtNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNota.ForeColor = System.Drawing.Color.White;
            this.txtNota.Location = new System.Drawing.Point(10, 39);
            this.txtNota.Multiline = true;
            this.txtNota.Name = "txtNota";
            this.txtNota.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNota.Size = new System.Drawing.Size(347, 84);
            this.txtNota.TabIndex = 8;
            // 
            // lblNota
            // 
            this.lblNota.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNota.Location = new System.Drawing.Point(4, 13);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(115, 23);
            this.lblNota.TabIndex = 7;
            this.lblNota.Text = "NOTA";
            // 
            // pnlExpression
            // 
            this.pnlExpression.ColumnCount = 1;
            this.pnlExpression.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlExpression.Controls.Add(this.panel3, 0, 2);
            this.pnlExpression.Controls.Add(this.pnlView, 0, 0);
            this.pnlExpression.Controls.Add(this.panel2, 0, 1);
            this.pnlExpression.Controls.Add(this.panel5, 0, 3);
            this.pnlExpression.Controls.Add(this.panel7, 0, 4);
            this.pnlExpression.Location = new System.Drawing.Point(0, 0);
            this.pnlExpression.Name = "pnlExpression";
            this.pnlExpression.RowCount = 5;
            this.pnlExpression.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.278351F));
            this.pnlExpression.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.49509F));
            this.pnlExpression.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.79383F));
            this.pnlExpression.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.14165F));
            this.pnlExpression.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 29.17251F));
            this.pnlExpression.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlExpression.Size = new System.Drawing.Size(382, 713);
            this.pnlExpression.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 342);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(376, 159);
            this.panel5.TabIndex = 4;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtSpiegazionne);
            this.panel6.Controls.Add(this.lblSpiegazione);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(376, 159);
            this.panel6.TabIndex = 0;
            // 
            // txtSpiegazionne
            // 
            this.txtSpiegazionne.BackColor = System.Drawing.Color.DimGray;
            this.txtSpiegazionne.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpiegazionne.ForeColor = System.Drawing.Color.White;
            this.txtSpiegazionne.Location = new System.Drawing.Point(10, 43);
            this.txtSpiegazionne.Multiline = true;
            this.txtSpiegazionne.Name = "txtSpiegazionne";
            this.txtSpiegazionne.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSpiegazionne.Size = new System.Drawing.Size(347, 116);
            this.txtSpiegazionne.TabIndex = 8;
            // 
            // lblSpiegazione
            // 
            this.lblSpiegazione.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpiegazione.Location = new System.Drawing.Point(4, 17);
            this.lblSpiegazione.Name = "lblSpiegazione";
            this.lblSpiegazione.Size = new System.Drawing.Size(158, 23);
            this.lblSpiegazione.TabIndex = 7;
            this.lblSpiegazione.Text = "SPIEGAZIONE";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnOK);
            this.panel7.Controls.Add(this.txtTesto);
            this.panel7.Controls.Add(this.lblTesto);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 507);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(376, 203);
            this.panel7.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(246, 170);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(109, 24);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "Complete";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtTesto
            // 
            this.txtTesto.BackColor = System.Drawing.Color.DimGray;
            this.txtTesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTesto.ForeColor = System.Drawing.Color.White;
            this.txtTesto.Location = new System.Drawing.Point(10, 37);
            this.txtTesto.Multiline = true;
            this.txtTesto.Name = "txtTesto";
            this.txtTesto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTesto.Size = new System.Drawing.Size(347, 116);
            this.txtTesto.TabIndex = 8;
            // 
            // lblTesto
            // 
            this.lblTesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTesto.Location = new System.Drawing.Point(6, 11);
            this.lblTesto.Name = "lblTesto";
            this.lblTesto.Size = new System.Drawing.Size(115, 23);
            this.lblTesto.TabIndex = 7;
            this.lblTesto.Text = "TESTO";
            // 
            // UCExpressionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.pnlExpression);
            this.Name = "UCExpressionEdit";
            this.Size = new System.Drawing.Size(351, 496);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlView.ResumeLayout(false);
            this.pnlView.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlExpression.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblOrigine;
        private System.Windows.Forms.TextBox txtOrigine;
        private System.Windows.Forms.Panel pnlView;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.TableLayoutPanel pnlExpression;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtSpiegazionne;
        private System.Windows.Forms.Label lblSpiegazione;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txtTesto;
        private System.Windows.Forms.Label lblTesto;
        private System.Windows.Forms.Button btnOK;
    }
}
