namespace LoadingObjFormat
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.loadOBJToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setObjectColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setBGColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._tableLayoutPanel.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.ColumnCount = 1;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.90722F));
            this._tableLayoutPanel.Controls.Add(this.menuStrip1, 0, 1);
            this._tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 2;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.02985F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.970149F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this._tableLayoutPanel.Size = new System.Drawing.Size(776, 583);
            this._tableLayoutPanel.TabIndex = 1;
            // 
            // loadOBJToolStripMenuItem
            // 
            this.loadOBJToolStripMenuItem.Name = "loadOBJToolStripMenuItem";
            this.loadOBJToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.loadOBJToolStripMenuItem.Text = "Load .OBJ";
            this.loadOBJToolStripMenuItem.Click += new System.EventHandler(this.loadOBJToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setObjectColorToolStripMenuItem,
            this.setBGColorToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.editToolStripMenuItem.Text = "Edit...";
            // 
            // setObjectColorToolStripMenuItem
            // 
            this.setObjectColorToolStripMenuItem.Name = "setObjectColorToolStripMenuItem";
            this.setObjectColorToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.setObjectColorToolStripMenuItem.Text = "Set Object Color";
            this.setObjectColorToolStripMenuItem.Click += new System.EventHandler(this.setObjectColorToolStripMenuItem_Click);
            // 
            // setBGColorToolStripMenuItem
            // 
            this.setBGColorToolStripMenuItem.Name = "setBGColorToolStripMenuItem";
            this.setBGColorToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.setBGColorToolStripMenuItem.Text = "Set BG Color";
            this.setBGColorToolStripMenuItem.Click += new System.EventHandler(this.setBGColorToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadOBJToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 548);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(776, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 583);
            this.Controls.Add(this._tableLayoutPanel);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this._tableLayoutPanel.ResumeLayout(false);
            this._tableLayoutPanel.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadOBJToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setObjectColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setBGColorToolStripMenuItem;
    }
}

