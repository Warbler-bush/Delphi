namespace Delphi
{
    partial class UCAddDictionary
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
            this.txtDictionary = new System.Windows.Forms.TextBox();
            this.lblNovel = new System.Windows.Forms.Label();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.cmbLanguage = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtDictionary
            // 
            this.txtDictionary.BackColor = System.Drawing.Color.White;
            this.txtDictionary.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDictionary.Location = new System.Drawing.Point(141, 10);
            this.txtDictionary.Name = "txtDictionary";
            this.txtDictionary.Size = new System.Drawing.Size(224, 30);
            this.txtDictionary.TabIndex = 40;
            // 
            // lblNovel
            // 
            this.lblNovel.AutoSize = true;
            this.lblNovel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNovel.Location = new System.Drawing.Point(3, 13);
            this.lblNovel.Name = "lblNovel";
            this.lblNovel.Size = new System.Drawing.Size(132, 25);
            this.lblNovel.TabIndex = 41;
            this.lblNovel.Text = "DIZIONARIO:";
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLanguage.Location = new System.Drawing.Point(3, 53);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(77, 25);
            this.lblLanguage.TabIndex = 42;
            this.lblLanguage.Text = "Lingua:";
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(272, 474);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(93, 28);
            this.btnOK.TabIndex = 44;
            this.btnOK.Text = "Aggiungi";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cmbLanguage
            // 
            this.cmbLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLanguage.FormattingEnabled = true;
            this.cmbLanguage.Location = new System.Drawing.Point(141, 50);
            this.cmbLanguage.Name = "cmbLanguage";
            this.cmbLanguage.Size = new System.Drawing.Size(121, 28);
            this.cmbLanguage.TabIndex = 45;
            // 
            // UCAddDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbLanguage);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblLanguage);
            this.Controls.Add(this.txtDictionary);
            this.Controls.Add(this.lblNovel);
            this.Name = "UCAddDictionary";
            this.Size = new System.Drawing.Size(370, 505);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDictionary;
        private System.Windows.Forms.Label lblNovel;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cmbLanguage;
    }
}
