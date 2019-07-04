namespace Delphi
{
    partial class UCAdd
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
            this.btnAddWord = new System.Windows.Forms.Button();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.pnlDef = new System.Windows.Forms.Panel();
            this.txtTradu = new System.Windows.Forms.TextBox();
            this.lblTran = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.btnAddDef = new System.Windows.Forms.Button();
            this.txtContra = new System.Windows.Forms.TextBox();
            this.txtSino = new System.Windows.Forms.TextBox();
            this.lblCon = new System.Windows.Forms.Label();
            this.lblSino = new System.Windows.Forms.Label();
            this.txtDefinizione = new System.Windows.Forms.TextBox();
            this.lblDefinizione = new System.Windows.Forms.Label();
            this.txtOri = new System.Windows.Forms.TextBox();
            this.lblOri = new System.Windows.Forms.Label();
            this.txtWord = new System.Windows.Forms.TextBox();
            this.lblWord = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.pnlDef.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddWord
            // 
            this.btnAddWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddWord.Location = new System.Drawing.Point(288, 473);
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.Size = new System.Drawing.Size(80, 26);
            this.btnAddWord.TabIndex = 5;
            this.btnAddWord.Text = "Aggiungi";
            this.btnAddWord.UseVisualStyleBackColor = true;
            this.btnAddWord.Click += new System.EventHandler(this.btnAddWord_Click);
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(11, 421);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(357, 46);
            this.txtNote.TabIndex = 4;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(7, 398);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(47, 20);
            this.lblNote.TabIndex = 24;
            this.lblNote.Text = "Nota:";
            // 
            // pnlDef
            // 
            this.pnlDef.Controls.Add(this.txtTradu);
            this.pnlDef.Controls.Add(this.lblTran);
            this.pnlDef.Controls.Add(this.lblHint);
            this.pnlDef.Controls.Add(this.btnAddDef);
            this.pnlDef.Controls.Add(this.txtContra);
            this.pnlDef.Controls.Add(this.txtSino);
            this.pnlDef.Controls.Add(this.lblCon);
            this.pnlDef.Controls.Add(this.lblSino);
            this.pnlDef.Controls.Add(this.txtDefinizione);
            this.pnlDef.Controls.Add(this.lblDefinizione);
            this.pnlDef.Location = new System.Drawing.Point(0, 39);
            this.pnlDef.Name = "pnlDef";
            this.pnlDef.Size = new System.Drawing.Size(385, 267);
            this.pnlDef.TabIndex = 1;
            // 
            // txtTradu
            // 
            this.txtTradu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTradu.Location = new System.Drawing.Point(105, 178);
            this.txtTradu.Name = "txtTradu";
            this.txtTradu.Size = new System.Drawing.Size(263, 23);
            this.txtTradu.TabIndex = 3;
            // 
            // lblTran
            // 
            this.lblTran.AutoSize = true;
            this.lblTran.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTran.Location = new System.Drawing.Point(13, 181);
            this.lblTran.Name = "lblTran";
            this.lblTran.Size = new System.Drawing.Size(86, 20);
            this.lblTran.TabIndex = 12;
            this.lblTran.Text = "Traduzioni:";
            // 
            // lblHint
            // 
            this.lblHint.AutoSize = true;
            this.lblHint.Location = new System.Drawing.Point(210, 204);
            this.lblHint.Name = "lblHint";
            this.lblHint.Size = new System.Drawing.Size(158, 13);
            this.lblHint.TabIndex = 11;
            this.lblHint.Text = "* Separare con il punto e virgola";
            // 
            // btnAddDef
            // 
            this.btnAddDef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDef.Location = new System.Drawing.Point(11, 231);
            this.btnAddDef.Name = "btnAddDef";
            this.btnAddDef.Size = new System.Drawing.Size(136, 23);
            this.btnAddDef.TabIndex = 4;
            this.btnAddDef.Text = "aggiungi definizione";
            this.btnAddDef.UseVisualStyleBackColor = true;
            this.btnAddDef.Click += new System.EventHandler(this.btnAddDef_Click);
            // 
            // txtContra
            // 
            this.txtContra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContra.Location = new System.Drawing.Point(83, 149);
            this.txtContra.Name = "txtContra";
            this.txtContra.Size = new System.Drawing.Size(285, 23);
            this.txtContra.TabIndex = 2;
            // 
            // txtSino
            // 
            this.txtSino.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSino.Location = new System.Drawing.Point(83, 120);
            this.txtSino.Name = "txtSino";
            this.txtSino.Size = new System.Drawing.Size(285, 23);
            this.txtSino.TabIndex = 1;
            // 
            // lblCon
            // 
            this.lblCon.AutoSize = true;
            this.lblCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCon.Location = new System.Drawing.Point(13, 152);
            this.lblCon.Name = "lblCon";
            this.lblCon.Size = new System.Drawing.Size(69, 20);
            this.lblCon.TabIndex = 7;
            this.lblCon.Text = "Contrari:";
            // 
            // lblSino
            // 
            this.lblSino.AutoSize = true;
            this.lblSino.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSino.Location = new System.Drawing.Point(13, 123);
            this.lblSino.Name = "lblSino";
            this.lblSino.Size = new System.Drawing.Size(73, 20);
            this.lblSino.TabIndex = 8;
            this.lblSino.Text = "Sinonimi:";
            // 
            // txtDefinizione
            // 
            this.txtDefinizione.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDefinizione.Location = new System.Drawing.Point(17, 34);
            this.txtDefinizione.Multiline = true;
            this.txtDefinizione.Name = "txtDefinizione";
            this.txtDefinizione.Size = new System.Drawing.Size(351, 70);
            this.txtDefinizione.TabIndex = 0;
            // 
            // lblDefinizione
            // 
            this.lblDefinizione.AutoSize = true;
            this.lblDefinizione.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDefinizione.Location = new System.Drawing.Point(13, 11);
            this.lblDefinizione.Name = "lblDefinizione";
            this.lblDefinizione.Size = new System.Drawing.Size(92, 20);
            this.lblDefinizione.TabIndex = 2;
            this.lblDefinizione.Text = "Definizione:";
            // 
            // txtOri
            // 
            this.txtOri.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOri.Location = new System.Drawing.Point(11, 332);
            this.txtOri.Multiline = true;
            this.txtOri.Name = "txtOri";
            this.txtOri.Size = new System.Drawing.Size(357, 55);
            this.txtOri.TabIndex = 3;
            // 
            // lblOri
            // 
            this.lblOri.AutoSize = true;
            this.lblOri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOri.Location = new System.Drawing.Point(7, 309);
            this.lblOri.Name = "lblOri";
            this.lblOri.Size = new System.Drawing.Size(63, 20);
            this.lblOri.TabIndex = 21;
            this.lblOri.Text = "Origine:";
            // 
            // txtWord
            // 
            this.txtWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWord.Location = new System.Drawing.Point(111, 3);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(189, 30);
            this.txtWord.TabIndex = 0;
            // 
            // lblWord
            // 
            this.lblWord.AutoSize = true;
            this.lblWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWord.Location = new System.Drawing.Point(6, 6);
            this.lblWord.Name = "lblWord";
            this.lblWord.Size = new System.Drawing.Size(99, 25);
            this.lblWord.TabIndex = 6;
            this.lblWord.Text = "PAROLA:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(306, 36);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(60, 13);
            this.lblType.TabIndex = 13;
            this.lblType.Text = "*tipo parola";
            // 
            // txtType
            // 
            this.txtType.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtType.Location = new System.Drawing.Point(306, 3);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(62, 30);
            this.txtType.TabIndex = 1;
            // 
            // UCAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.btnAddWord);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.pnlDef);
            this.Controls.Add(this.txtOri);
            this.Controls.Add(this.lblOri);
            this.Controls.Add(this.txtWord);
            this.Controls.Add(this.lblWord);
            this.Name = "UCAdd";
            this.Size = new System.Drawing.Size(385, 503);
            this.pnlDef.ResumeLayout(false);
            this.pnlDef.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddWord;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Panel pnlDef;
        private System.Windows.Forms.TextBox txtTradu;
        private System.Windows.Forms.Label lblTran;
        private System.Windows.Forms.Label lblHint;
        private System.Windows.Forms.Button btnAddDef;
        private System.Windows.Forms.TextBox txtContra;
        private System.Windows.Forms.TextBox txtSino;
        private System.Windows.Forms.Label lblCon;
        private System.Windows.Forms.Label lblSino;
        private System.Windows.Forms.TextBox txtDefinizione;
        private System.Windows.Forms.Label lblDefinizione;
        private System.Windows.Forms.TextBox txtOri;
        private System.Windows.Forms.Label lblOri;
        private System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.Label lblWord;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtType;
    }
}
