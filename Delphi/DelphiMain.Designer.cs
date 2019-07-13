namespace Delphi
{
    partial class DelphiMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DelphiMain));
            this.pnlAll = new System.Windows.Forms.Panel();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.lblAll = new System.Windows.Forms.Label();
            this.txtSearched = new System.Windows.Forms.TextBox();
            this.btnMain = new System.Windows.Forms.Button();
            this.lblExpre = new System.Windows.Forms.Label();
            this.lblNovel = new System.Windows.Forms.Label();
            this.lblWord = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnTabella = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnBackward = new System.Windows.Forms.Button();
            this.btnRemind = new System.Windows.Forms.Button();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblDictName = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.PictureBox();
            this.btnAdd = new System.Windows.Forms.PictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlAddChoice = new System.Windows.Forms.Panel();
            this.lblAddDictionary = new System.Windows.Forms.Label();
            this.lblAddNovel = new System.Windows.Forms.Label();
            this.lblAddExpression = new System.Windows.Forms.Label();
            this.lblAddWord = new System.Windows.Forms.Label();
            this.btnDictionary = new System.Windows.Forms.PictureBox();
            this.btnNovel = new System.Windows.Forms.PictureBox();
            this.btnExpression = new System.Windows.Forms.PictureBox();
            this.btnWord = new System.Windows.Forms.PictureBox();
            this.txtMain = new System.Windows.Forms.RichTextBox();
            this.pnlAll.SuspendLayout();
            this.table.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlAddChoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDictionary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNovel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExpression)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnWord)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlAll
            // 
            this.pnlAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlAll.Controls.Add(this.table);
            this.pnlAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAll.Location = new System.Drawing.Point(0, 0);
            this.pnlAll.Name = "pnlAll";
            this.pnlAll.Size = new System.Drawing.Size(390, 627);
            this.pnlAll.TabIndex = 3;
            // 
            // table
            // 
            this.table.AutoScroll = true;
            this.table.AutoSize = true;
            this.table.ColumnCount = 1;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.Controls.Add(this.pnlMenu, 0, 0);
            this.table.Controls.Add(this.pnlBottom, 0, 2);
            this.table.Controls.Add(this.pnlMain, 0, 1);
            this.table.Dock = System.Windows.Forms.DockStyle.Top;
            this.table.Location = new System.Drawing.Point(0, 0);
            this.table.Name = "table";
            this.table.RowCount = 3;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.table.Size = new System.Drawing.Size(390, 623);
            this.table.TabIndex = 2;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlMenu.Controls.Add(this.lblAll);
            this.pnlMenu.Controls.Add(this.txtSearched);
            this.pnlMenu.Controls.Add(this.btnMain);
            this.pnlMenu.Controls.Add(this.lblExpre);
            this.pnlMenu.Controls.Add(this.lblNovel);
            this.pnlMenu.Controls.Add(this.lblWord);
            this.pnlMenu.Controls.Add(this.btnSearch);
            this.pnlMenu.Controls.Add(this.btnTabella);
            this.pnlMenu.Controls.Add(this.btnForward);
            this.pnlMenu.Controls.Add(this.btnBackward);
            this.pnlMenu.Controls.Add(this.btnRemind);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu.Location = new System.Drawing.Point(3, 3);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(384, 46);
            this.pnlMenu.TabIndex = 3;
            // 
            // lblAll
            // 
            this.lblAll.AutoSize = true;
            this.lblAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAll.Location = new System.Drawing.Point(294, 32);
            this.lblAll.Name = "lblAll";
            this.lblAll.Size = new System.Drawing.Size(17, 16);
            this.lblAll.TabIndex = 45;
            this.lblAll.Text = "A";
            this.lblAll.Click += new System.EventHandler(this.lblAll_Click);
            // 
            // txtSearched
            // 
            this.txtSearched.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearched.Location = new System.Drawing.Point(200, 3);
            this.txtSearched.Name = "txtSearched";
            this.txtSearched.Size = new System.Drawing.Size(144, 26);
            this.txtSearched.TabIndex = 44;
            // 
            // btnMain
            // 
            this.btnMain.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMain.FlatAppearance.BorderSize = 0;
            this.btnMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMain.Location = new System.Drawing.Point(80, 3);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(34, 31);
            this.btnMain.TabIndex = 43;
            this.btnMain.Text = "M";
            this.btnMain.UseVisualStyleBackColor = true;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // lblExpre
            // 
            this.lblExpre.AutoSize = true;
            this.lblExpre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpre.Location = new System.Drawing.Point(337, 32);
            this.lblExpre.Name = "lblExpre";
            this.lblExpre.Size = new System.Drawing.Size(17, 16);
            this.lblExpre.TabIndex = 40;
            this.lblExpre.Text = "E";
            this.lblExpre.Click += new System.EventHandler(this.lblExpre_Click);
            // 
            // lblNovel
            // 
            this.lblNovel.AutoSize = true;
            this.lblNovel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNovel.Location = new System.Drawing.Point(357, 32);
            this.lblNovel.Name = "lblNovel";
            this.lblNovel.Size = new System.Drawing.Size(18, 16);
            this.lblNovel.TabIndex = 41;
            this.lblNovel.Text = "N";
            this.lblNovel.Click += new System.EventHandler(this.lblNovel_Click);
            // 
            // lblWord
            // 
            this.lblWord.AutoSize = true;
            this.lblWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWord.Location = new System.Drawing.Point(317, 32);
            this.lblWord.Name = "lblWord";
            this.lblWord.Size = new System.Drawing.Size(17, 16);
            this.lblWord.TabIndex = 39;
            this.lblWord.Text = "P";
            this.lblWord.Click += new System.EventHandler(this.lblWord_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(341, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(34, 26);
            this.btnSearch.TabIndex = 38;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnTabella
            // 
            this.btnTabella.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTabella.FlatAppearance.BorderSize = 0;
            this.btnTabella.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTabella.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTabella.Location = new System.Drawing.Point(120, 3);
            this.btnTabella.Name = "btnTabella";
            this.btnTabella.Size = new System.Drawing.Size(34, 31);
            this.btnTabella.TabIndex = 37;
            this.btnTabella.Text = "T";
            this.btnTabella.UseVisualStyleBackColor = true;
            this.btnTabella.Click += new System.EventHandler(this.btnTabella_Click);
            // 
            // btnForward
            // 
            this.btnForward.FlatAppearance.BorderSize = 0;
            this.btnForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForward.Image = ((System.Drawing.Image)(resources.GetObject("btnForward.Image")));
            this.btnForward.Location = new System.Drawing.Point(46, 3);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(28, 31);
            this.btnForward.TabIndex = 35;
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnBackward
            // 
            this.btnBackward.BackColor = System.Drawing.Color.White;
            this.btnBackward.FlatAppearance.BorderSize = 0;
            this.btnBackward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackward.Image = ((System.Drawing.Image)(resources.GetObject("btnBackward.Image")));
            this.btnBackward.Location = new System.Drawing.Point(12, 3);
            this.btnBackward.Name = "btnBackward";
            this.btnBackward.Size = new System.Drawing.Size(28, 31);
            this.btnBackward.TabIndex = 34;
            this.btnBackward.UseVisualStyleBackColor = false;
            this.btnBackward.Click += new System.EventHandler(this.btnBackward_Click);
            // 
            // btnRemind
            // 
            this.btnRemind.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRemind.FlatAppearance.BorderSize = 0;
            this.btnRemind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemind.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemind.Location = new System.Drawing.Point(160, 3);
            this.btnRemind.Name = "btnRemind";
            this.btnRemind.Size = new System.Drawing.Size(34, 31);
            this.btnRemind.TabIndex = 36;
            this.btnRemind.Text = "R";
            this.btnRemind.UseVisualStyleBackColor = true;
            this.btnRemind.Click += new System.EventHandler(this.btnRemind_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.AutoSize = true;
            this.pnlBottom.Controls.Add(this.lblDictName);
            this.pnlBottom.Controls.Add(this.btnRefresh);
            this.pnlBottom.Controls.Add(this.btnOptions);
            this.pnlBottom.Controls.Add(this.btnAdd);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(3, 583);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(384, 37);
            this.pnlBottom.TabIndex = 4;
            // 
            // lblDictName
            // 
            this.lblDictName.AutoSize = true;
            this.lblDictName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDictName.Location = new System.Drawing.Point(156, 8);
            this.lblDictName.Name = "lblDictName";
            this.lblDictName.Size = new System.Drawing.Size(97, 24);
            this.lblDictName.TabIndex = 69;
            this.lblDictName.Text = "Dict Name";
            this.lblDictName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(9, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(31, 31);
            this.btnRefresh.TabIndex = 68;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOptions.Image")));
            this.btnOptions.Location = new System.Drawing.Point(356, 7);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(25, 25);
            this.btnOptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnOptions.TabIndex = 67;
            this.btnOptions.TabStop = false;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(320, 7);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 25);
            this.btnAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAdd.TabIndex = 66;
            this.btnAdd.TabStop = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.AutoScroll = true;
            this.pnlMain.Controls.Add(this.txtMain);
            this.pnlMain.Controls.Add(this.pnlAddChoice);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(3, 55);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(384, 522);
            this.pnlMain.TabIndex = 5;
            // 
            // pnlAddChoice
            // 
            this.pnlAddChoice.Controls.Add(this.lblAddDictionary);
            this.pnlAddChoice.Controls.Add(this.lblAddNovel);
            this.pnlAddChoice.Controls.Add(this.lblAddExpression);
            this.pnlAddChoice.Controls.Add(this.lblAddWord);
            this.pnlAddChoice.Controls.Add(this.btnDictionary);
            this.pnlAddChoice.Controls.Add(this.btnNovel);
            this.pnlAddChoice.Controls.Add(this.btnExpression);
            this.pnlAddChoice.Controls.Add(this.btnWord);
            this.pnlAddChoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAddChoice.Location = new System.Drawing.Point(0, 0);
            this.pnlAddChoice.Name = "pnlAddChoice";
            this.pnlAddChoice.Size = new System.Drawing.Size(384, 522);
            this.pnlAddChoice.TabIndex = 16;
            // 
            // lblAddDictionary
            // 
            this.lblAddDictionary.AutoSize = true;
            this.lblAddDictionary.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddDictionary.Location = new System.Drawing.Point(193, 413);
            this.lblAddDictionary.Name = "lblAddDictionary";
            this.lblAddDictionary.Size = new System.Drawing.Size(190, 25);
            this.lblAddDictionary.TabIndex = 15;
            this.lblAddDictionary.Text = "ADD DICTIONARY";
            // 
            // lblAddNovel
            // 
            this.lblAddNovel.AutoSize = true;
            this.lblAddNovel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddNovel.Location = new System.Drawing.Point(36, 413);
            this.lblAddNovel.Name = "lblAddNovel";
            this.lblAddNovel.Size = new System.Drawing.Size(133, 25);
            this.lblAddNovel.TabIndex = 14;
            this.lblAddNovel.Text = "ADD NOVEL";
            // 
            // lblAddExpression
            // 
            this.lblAddExpression.AutoSize = true;
            this.lblAddExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddExpression.Location = new System.Drawing.Point(186, 212);
            this.lblAddExpression.Name = "lblAddExpression";
            this.lblAddExpression.Size = new System.Drawing.Size(197, 25);
            this.lblAddExpression.TabIndex = 13;
            this.lblAddExpression.Text = "ADD EXPRESSION";
            // 
            // lblAddWord
            // 
            this.lblAddWord.AutoSize = true;
            this.lblAddWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddWord.Location = new System.Drawing.Point(36, 212);
            this.lblAddWord.Name = "lblAddWord";
            this.lblAddWord.Size = new System.Drawing.Size(128, 25);
            this.lblAddWord.TabIndex = 12;
            this.lblAddWord.Text = "ADD WORD";
            // 
            // btnDictionary
            // 
            this.btnDictionary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnDictionary.Image = ((System.Drawing.Image)(resources.GetObject("btnDictionary.Image")));
            this.btnDictionary.Location = new System.Drawing.Point(216, 250);
            this.btnDictionary.Name = "btnDictionary";
            this.btnDictionary.Size = new System.Drawing.Size(150, 150);
            this.btnDictionary.TabIndex = 11;
            this.btnDictionary.TabStop = false;
            this.btnDictionary.Click += new System.EventHandler(this.btnDictionary_Click);
            // 
            // btnNovel
            // 
            this.btnNovel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnNovel.Image = ((System.Drawing.Image)(resources.GetObject("btnNovel.Image")));
            this.btnNovel.Location = new System.Drawing.Point(27, 250);
            this.btnNovel.Name = "btnNovel";
            this.btnNovel.Size = new System.Drawing.Size(150, 150);
            this.btnNovel.TabIndex = 10;
            this.btnNovel.TabStop = false;
            this.btnNovel.Click += new System.EventHandler(this.btnNovel_Click);
            // 
            // btnExpression
            // 
            this.btnExpression.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnExpression.Image = ((System.Drawing.Image)(resources.GetObject("btnExpression.Image")));
            this.btnExpression.Location = new System.Drawing.Point(216, 55);
            this.btnExpression.Name = "btnExpression";
            this.btnExpression.Size = new System.Drawing.Size(150, 150);
            this.btnExpression.TabIndex = 9;
            this.btnExpression.TabStop = false;
            this.btnExpression.Click += new System.EventHandler(this.btnExpression_Click);
            // 
            // btnWord
            // 
            this.btnWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnWord.Image = ((System.Drawing.Image)(resources.GetObject("btnWord.Image")));
            this.btnWord.Location = new System.Drawing.Point(27, 55);
            this.btnWord.Name = "btnWord";
            this.btnWord.Size = new System.Drawing.Size(150, 150);
            this.btnWord.TabIndex = 8;
            this.btnWord.TabStop = false;
            this.btnWord.Click += new System.EventHandler(this.btnWord_Click);
            // 
            // txtMain
            // 
            this.txtMain.BackColor = System.Drawing.Color.DimGray;
            this.txtMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMain.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMain.ForeColor = System.Drawing.Color.White;
            this.txtMain.Location = new System.Drawing.Point(0, 0);
            this.txtMain.Name = "txtMain";
            this.txtMain.Size = new System.Drawing.Size(384, 522);
            this.txtMain.TabIndex = 4;
            this.txtMain.Text = "";
            // 
            // DelphiMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(390, 627);
            this.Controls.Add(this.pnlAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(410, 670);
            this.MinimumSize = new System.Drawing.Size(410, 670);
            this.Name = "DelphiMain";
            this.Text = "Delphi";
            this.Load += new System.EventHandler(this.DelphiMain_Load);
            this.pnlAll.ResumeLayout(false);
            this.pnlAll.PerformLayout();
            this.table.ResumeLayout(false);
            this.table.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlAddChoice.ResumeLayout(false);
            this.pnlAddChoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDictionary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNovel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExpression)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnWord)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAll;
        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label lblExpre;
        private System.Windows.Forms.Label lblNovel;
        private System.Windows.Forms.Label lblWord;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnTabella;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnBackward;
        private System.Windows.Forms.Button btnRemind;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.PictureBox btnOptions;
        private System.Windows.Forms.PictureBox btnAdd;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.RichTextBox txtMain;
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.TextBox txtSearched;
        private System.Windows.Forms.Label lblAll;
        private System.Windows.Forms.Label lblDictName;
        private System.Windows.Forms.Panel pnlAddChoice;
        private System.Windows.Forms.Label lblAddDictionary;
        private System.Windows.Forms.Label lblAddNovel;
        private System.Windows.Forms.Label lblAddExpression;
        private System.Windows.Forms.Label lblAddWord;
        private System.Windows.Forms.PictureBox btnDictionary;
        private System.Windows.Forms.PictureBox btnNovel;
        private System.Windows.Forms.PictureBox btnExpression;
        private System.Windows.Forms.PictureBox btnWord;
    }
}

