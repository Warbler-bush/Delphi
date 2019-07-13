namespace Delphi
{
    partial class frmSettings
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
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblDictInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLanguage = new System.Windows.Forms.Label();
            this.lblDataCreation = new System.Windows.Forms.Label();
            this.lblNovelCount = new System.Windows.Forms.Label();
            this.lblExprCount = new System.Windows.Forms.Label();
            this.lblWordsCount = new System.Windows.Forms.Label();
            this.lblCurDict = new System.Windows.Forms.Label();
            this.lblDictToSelect = new System.Windows.Forms.Label();
            this.cmbDictToSelect = new System.Windows.Forms.ComboBox();
            this.pnlSettings.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSettings
            // 
            this.pnlSettings.Controls.Add(this.btnOK);
            this.pnlSettings.Controls.Add(this.lblDictInfo);
            this.pnlSettings.Controls.Add(this.panel1);
            this.pnlSettings.Controls.Add(this.lblCurDict);
            this.pnlSettings.Controls.Add(this.lblDictToSelect);
            this.pnlSettings.Controls.Add(this.cmbDictToSelect);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSettings.Location = new System.Drawing.Point(0, 0);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(379, 273);
            this.pnlSettings.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(287, 240);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "Finish";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblDictInfo
            // 
            this.lblDictInfo.AutoSize = true;
            this.lblDictInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDictInfo.Location = new System.Drawing.Point(17, 96);
            this.lblDictInfo.Name = "lblDictInfo";
            this.lblDictInfo.Size = new System.Drawing.Size(115, 20);
            this.lblDictInfo.TabIndex = 4;
            this.lblDictInfo.Text = "Dictionary Info:";
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblLanguage);
            this.panel1.Controls.Add(this.lblDataCreation);
            this.panel1.Controls.Add(this.lblNovelCount);
            this.panel1.Controls.Add(this.lblExprCount);
            this.panel1.Controls.Add(this.lblWordsCount);
            this.panel1.Location = new System.Drawing.Point(21, 128);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 106);
            this.panel1.TabIndex = 3;
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLanguage.Location = new System.Drawing.Point(177, 65);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(76, 18);
            this.lblLanguage.TabIndex = 4;
            this.lblLanguage.Text = "Language:";
            // 
            // lblDataCreation
            // 
            this.lblDataCreation.AutoSize = true;
            this.lblDataCreation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataCreation.Location = new System.Drawing.Point(12, 9);
            this.lblDataCreation.Name = "lblDataCreation";
            this.lblDataCreation.Size = new System.Drawing.Size(103, 18);
            this.lblDataCreation.TabIndex = 3;
            this.lblDataCreation.Text = "Data Creation:";
            // 
            // lblNovelCount
            // 
            this.lblNovelCount.AutoSize = true;
            this.lblNovelCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNovelCount.Location = new System.Drawing.Point(12, 65);
            this.lblNovelCount.Name = "lblNovelCount";
            this.lblNovelCount.Size = new System.Drawing.Size(77, 18);
            this.lblNovelCount.TabIndex = 2;
            this.lblNovelCount.Text = "N. Novels:";
            // 
            // lblExprCount
            // 
            this.lblExprCount.AutoSize = true;
            this.lblExprCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExprCount.Location = new System.Drawing.Point(12, 37);
            this.lblExprCount.Name = "lblExprCount";
            this.lblExprCount.Size = new System.Drawing.Size(113, 18);
            this.lblExprCount.TabIndex = 1;
            this.lblExprCount.Text = "N. Expressions:";
            // 
            // lblWordsCount
            // 
            this.lblWordsCount.AutoSize = true;
            this.lblWordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWordsCount.Location = new System.Drawing.Point(177, 37);
            this.lblWordsCount.Name = "lblWordsCount";
            this.lblWordsCount.Size = new System.Drawing.Size(76, 18);
            this.lblWordsCount.TabIndex = 0;
            this.lblWordsCount.Text = "N. Words:";
            // 
            // lblCurDict
            // 
            this.lblCurDict.AutoSize = true;
            this.lblCurDict.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurDict.Location = new System.Drawing.Point(16, 20);
            this.lblCurDict.Name = "lblCurDict";
            this.lblCurDict.Size = new System.Drawing.Size(137, 20);
            this.lblCurDict.TabIndex = 2;
            this.lblCurDict.Text = "Current dictionary:";
            // 
            // lblDictToSelect
            // 
            this.lblDictToSelect.AutoSize = true;
            this.lblDictToSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDictToSelect.Location = new System.Drawing.Point(17, 54);
            this.lblDictToSelect.MaximumSize = new System.Drawing.Size(300, 0);
            this.lblDictToSelect.Name = "lblDictToSelect";
            this.lblDictToSelect.Size = new System.Drawing.Size(179, 20);
            this.lblDictToSelect.TabIndex = 1;
            this.lblDictToSelect.Text = "Select current dictionary";
            // 
            // cmbDictToSelect
            // 
            this.cmbDictToSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDictToSelect.FormattingEnabled = true;
            this.cmbDictToSelect.Location = new System.Drawing.Point(202, 54);
            this.cmbDictToSelect.Name = "cmbDictToSelect";
            this.cmbDictToSelect.Size = new System.Drawing.Size(165, 26);
            this.cmbDictToSelect.TabIndex = 0;
            this.cmbDictToSelect.SelectedIndexChanged += new System.EventHandler(this.cmbDictToSelect_SelectedIndexChanged);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 273);
            this.Controls.Add(this.pnlSettings);
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.pnlSettings.ResumeLayout(false);
            this.pnlSettings.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Label lblCurDict;
        private System.Windows.Forms.Label lblDictToSelect;
        private System.Windows.Forms.ComboBox cmbDictToSelect;
        private System.Windows.Forms.Label lblDictInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNovelCount;
        private System.Windows.Forms.Label lblExprCount;
        private System.Windows.Forms.Label lblWordsCount;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Label lblDataCreation;
        private System.Windows.Forms.Button btnOK;
    }
}