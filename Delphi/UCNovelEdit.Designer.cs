namespace Delphi
{
    partial class UCNovelEdit
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlNovel = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.lblNota = new System.Windows.Forms.Label();
            this.pnlView = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblOrigine = new System.Windows.Forms.Label();
            this.txtOrigine = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtTesto = new System.Windows.Forms.TextBox();
            this.lblTesto = new System.Windows.Forms.Label();
            this.lblAutore = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.pnlNovel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlView.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pnlNovel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 513);
            this.panel1.TabIndex = 0;
            // 
            // pnlNovel
            // 
            this.pnlNovel.ColumnCount = 1;
            this.pnlNovel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlNovel.Controls.Add(this.panel3, 0, 2);
            this.pnlNovel.Controls.Add(this.pnlView, 0, 0);
            this.pnlNovel.Controls.Add(this.panel2, 0, 1);
            this.pnlNovel.Controls.Add(this.panel7, 0, 3);
            this.pnlNovel.Location = new System.Drawing.Point(0, 0);
            this.pnlNovel.Name = "pnlNovel";
            this.pnlNovel.RowCount = 4;
            this.pnlNovel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.09067F));
            this.pnlNovel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.19635F));
            this.pnlNovel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.91585F));
            this.pnlNovel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.96634F));
            this.pnlNovel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlNovel.Size = new System.Drawing.Size(382, 713);
            this.pnlNovel.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtNota);
            this.panel3.Controls.Add(this.lblNota);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 232);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(376, 135);
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
            // pnlView
            // 
            this.pnlView.Controls.Add(this.txtAuthor);
            this.pnlView.Controls.Add(this.lblAutore);
            this.pnlView.Controls.Add(this.lblTitle);
            this.pnlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlView.Location = new System.Drawing.Point(3, 3);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(376, 80);
            this.pnlView.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(5, 11);
            this.lblTitle.MaximumSize = new System.Drawing.Size(379, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(71, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Titolo";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblOrigine);
            this.panel2.Controls.Add(this.txtOrigine);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(376, 137);
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
            // panel7
            // 
            this.panel7.Controls.Add(this.btnOK);
            this.panel7.Controls.Add(this.txtTesto);
            this.panel7.Controls.Add(this.lblTesto);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 373);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(376, 337);
            this.panel7.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(248, 296);
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
            this.txtTesto.Size = new System.Drawing.Size(347, 253);
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
            // lblAutore
            // 
            this.lblAutore.AutoSize = true;
            this.lblAutore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutore.Location = new System.Drawing.Point(6, 49);
            this.lblAutore.Name = "lblAutore";
            this.lblAutore.Size = new System.Drawing.Size(57, 20);
            this.lblAutore.TabIndex = 1;
            this.lblAutore.Text = "Autore";
            // 
            // txtAuthor
            // 
            this.txtAuthor.BackColor = System.Drawing.Color.DimGray;
            this.txtAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuthor.ForeColor = System.Drawing.Color.White;
            this.txtAuthor.Location = new System.Drawing.Point(69, 47);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAuthor.Size = new System.Drawing.Size(142, 22);
            this.txtAuthor.TabIndex = 6;
            // 
            // UCNovelEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UCNovelEdit";
            this.Size = new System.Drawing.Size(386, 513);
            this.panel1.ResumeLayout(false);
            this.pnlNovel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlView.ResumeLayout(false);
            this.pnlView.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel pnlNovel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.Panel pnlView;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblOrigine;
        private System.Windows.Forms.TextBox txtOrigine;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtTesto;
        private System.Windows.Forms.Label lblTesto;
        private System.Windows.Forms.Label lblAutore;
        private System.Windows.Forms.TextBox txtAuthor;
    }
}
