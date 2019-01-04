namespace DecksStorage
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvDeck = new System.Windows.Forms.DataGridView();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClearDecks = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Copy = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearchNote = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSearchFormat = new System.Windows.Forms.ComboBox();
            this.cbSearchClass = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deckBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeck)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deckBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCreate,
            this.操作ToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // menuCreate
            // 
            this.menuCreate.Name = "menuCreate";
            resources.ApplyResources(this.menuCreate, "menuCreate");
            this.menuCreate.Click += new System.EventHandler(this.menuCreate_Click);
            // 
            // dgvDeck
            // 
            this.dgvDeck.AllowUserToAddRows = false;
            this.dgvDeck.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dgvDeck, "dgvDeck");
            this.dgvDeck.AutoGenerateColumns = false;
            this.dgvDeck.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeck.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.formatDataGridViewTextBoxColumn,
            this.classDataGridViewTextBoxColumn,
            this.noteDataGridViewTextBoxColumn,
            this.Copy,
            this.Delete});
            this.dgvDeck.DataSource = this.deckBindingSource;
            this.dgvDeck.Name = "dgvDeck";
            this.dgvDeck.ReadOnly = true;
            this.dgvDeck.RowHeadersVisible = false;
            this.dgvDeck.RowTemplate.Height = 24;
            this.dgvDeck.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeck_CellClick);
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuClearDecks});
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            resources.ApplyResources(this.操作ToolStripMenuItem, "操作ToolStripMenuItem");
            // 
            // menuClearDecks
            // 
            this.menuClearDecks.Name = "menuClearDecks";
            resources.ApplyResources(this.menuClearDecks, "menuClearDecks");
            this.menuClearDecks.Click += new System.EventHandler(this.menuClearDecks_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.cbSearchClass);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbSearchFormat);
            this.groupBox1.Controls.Add(this.txtSearchNote);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSearchName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // Copy
            // 
            resources.ApplyResources(this.Copy, "Copy");
            this.Copy.Name = "Copy";
            this.Copy.ReadOnly = true;
            this.Copy.Text = "複製";
            this.Copy.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            this.Delete.FillWeight = 20.61856F;
            resources.ApplyResources(this.Delete, "Delete");
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Text = "刪除";
            this.Delete.UseColumnTextForButtonValue = true;
            // 
            // txtSearchName
            // 
            resources.ApplyResources(this.txtSearchName, "txtSearchName");
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.TextChanged += new System.EventHandler(this.txtSearchName_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtSearchNote
            // 
            resources.ApplyResources(this.txtSearchNote, "txtSearchNote");
            this.txtSearchNote.Name = "txtSearchNote";
            this.txtSearchNote.TextChanged += new System.EventHandler(this.txtSearchNote_TextChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cbSearchFormat
            // 
            this.cbSearchFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchFormat.FormattingEnabled = true;
            resources.ApplyResources(this.cbSearchFormat, "cbSearchFormat");
            this.cbSearchFormat.Name = "cbSearchFormat";
            this.cbSearchFormat.SelectedIndexChanged += new System.EventHandler(this.cbSearchFormat_SelectedIndexChanged);
            // 
            // cbSearchClass
            // 
            this.cbSearchClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSearchClass.FormattingEnabled = true;
            resources.ApplyResources(this.cbSearchClass, "cbSearchClass");
            this.cbSearchClass.Name = "cbSearchClass";
            this.cbSearchClass.SelectedIndexChanged += new System.EventHandler(this.cbSearchClass_SelectedIndexChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            resources.ApplyResources(this.nameDataGridViewTextBoxColumn, "nameDataGridViewTextBoxColumn");
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // formatDataGridViewTextBoxColumn
            // 
            this.formatDataGridViewTextBoxColumn.DataPropertyName = "Format";
            this.formatDataGridViewTextBoxColumn.FillWeight = 20.61856F;
            resources.ApplyResources(this.formatDataGridViewTextBoxColumn, "formatDataGridViewTextBoxColumn");
            this.formatDataGridViewTextBoxColumn.Name = "formatDataGridViewTextBoxColumn";
            this.formatDataGridViewTextBoxColumn.ReadOnly = true;
            this.formatDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // classDataGridViewTextBoxColumn
            // 
            this.classDataGridViewTextBoxColumn.DataPropertyName = "Class";
            this.classDataGridViewTextBoxColumn.FillWeight = 20.61856F;
            resources.ApplyResources(this.classDataGridViewTextBoxColumn, "classDataGridViewTextBoxColumn");
            this.classDataGridViewTextBoxColumn.Name = "classDataGridViewTextBoxColumn";
            this.classDataGridViewTextBoxColumn.ReadOnly = true;
            this.classDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // noteDataGridViewTextBoxColumn
            // 
            this.noteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.noteDataGridViewTextBoxColumn.DataPropertyName = "Note";
            this.noteDataGridViewTextBoxColumn.FillWeight = 338.1443F;
            resources.ApplyResources(this.noteDataGridViewTextBoxColumn, "noteDataGridViewTextBoxColumn");
            this.noteDataGridViewTextBoxColumn.Name = "noteDataGridViewTextBoxColumn";
            this.noteDataGridViewTextBoxColumn.ReadOnly = true;
            this.noteDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // deckBindingSource
            // 
            this.deckBindingSource.DataSource = typeof(DecksStorage.Models.Deck);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvDeck);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeck)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deckBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuCreate;
        private System.Windows.Forms.DataGridView dgvDeck;
        private System.Windows.Forms.BindingSource deckBindingSource;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuClearDecks;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn formatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn classDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Copy;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.ComboBox cbSearchClass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbSearchFormat;
        private System.Windows.Forms.TextBox txtSearchNote;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

