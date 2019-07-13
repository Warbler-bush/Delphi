namespace Delphi
{
    partial class UCAddNovel
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
            this.btnOK = new System.Windows.Forms.Button();
            this.txtText = new System.Windows.Forms.TextBox();
            this.lblText = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.txtOri = new System.Windows.Forms.TextBox();
            this.lblOri = new System.Windows.Forms.Label();
            this.txtNovel = new System.Windows.Forms.TextBox();
            this.lblNovel = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(248, 485);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(118, 26);
            this.btnOK.TabIndex = 46;
            this.btnOK.Text = "Aggiungi";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtText
            // 
            this.txtText.BackColor = System.Drawing.Color.White;
            this.txtText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtText.Location = new System.Drawing.Point(9, 289);
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(357, 190);
            this.txtText.TabIndex = 44;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(3, 266);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(53, 20);
            this.lblText.TabIndex = 45;
            this.lblText.Text = "Testo:";
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.Color.White;
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(7, 201);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(357, 46);
            this.txtNote.TabIndex = 38;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(3, 178);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(47, 20);
            this.lblNote.TabIndex = 41;
            this.lblNote.Text = "Nota:";
            // 
            // txtOri
            // 
            this.txtOri.BackColor = System.Drawing.Color.White;
            this.txtOri.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOri.Location = new System.Drawing.Point(7, 112);
            this.txtOri.Multiline = true;
            this.txtOri.Name = "txtOri";
            this.txtOri.Size = new System.Drawing.Size(357, 55);
            this.txtOri.TabIndex = 37;
            // 
            // lblOri
            // 
            this.lblOri.AutoSize = true;
            this.lblOri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOri.Location = new System.Drawing.Point(3, 89);
            this.lblOri.Name = "lblOri";
            this.lblOri.Size = new System.Drawing.Size(63, 20);
            this.lblOri.TabIndex = 40;
            this.lblOri.Text = "Origine:";
            // 
            // txtNovel
            // 
            this.txtNovel.BackColor = System.Drawing.Color.White;
            this.txtNovel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNovel.Location = new System.Drawing.Point(111, 11);
            this.txtNovel.Name = "txtNovel";
            this.txtNovel.Size = new System.Drawing.Size(255, 30);
            this.txtNovel.TabIndex = 36;
            // 
            // lblNovel
            // 
            this.lblNovel.AutoSize = true;
            this.lblNovel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNovel.Location = new System.Drawing.Point(4, 14);
            this.lblNovel.Name = "lblNovel";
            this.lblNovel.Size = new System.Drawing.Size(111, 25);
            this.lblNovel.TabIndex = 39;
            this.lblNovel.Text = "NOVELLA:";
            // 
            // txtAuthor
            // 
            this.txtAuthor.BackColor = System.Drawing.Color.White;
            this.txtAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuthor.Location = new System.Drawing.Point(111, 53);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(168, 23);
            this.txtAuthor.TabIndex = 47;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthor.Location = new System.Drawing.Point(3, 53);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(61, 20);
            this.lblAuthor.TabIndex = 48;
            this.lblAuthor.Text = "Autore:";
            // 
            // UCAddNovel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.txtOri);
            this.Controls.Add(this.lblOri);
            this.Controls.Add(this.txtNovel);
            this.Controls.Add(this.lblNovel);
            this.Name = "UCAddNovel";
            this.Size = new System.Drawing.Size(370, 522);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtOri;
        private System.Windows.Forms.Label lblOri;
        private System.Windows.Forms.TextBox txtNovel;
        private System.Windows.Forms.Label lblNovel;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblAuthor;
    }
}
