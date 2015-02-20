namespace UniversityExampleApp
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.univExAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeIdColumnVisibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainDataGridView = new System.Windows.Forms.DataGridView();
            this.tablesComboBox = new System.Windows.Forms.ComboBox();
            this.rowAddDataGridView = new System.Windows.Forms.DataGridView();
            this.addRowButton = new System.Windows.Forms.Button();
            this.deleteSelButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowAddDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.univExAppToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(574, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // univExAppToolStripMenuItem
            // 
            this.univExAppToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeIdColumnVisibleToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.univExAppToolStripMenuItem.Name = "univExAppToolStripMenuItem";
            this.univExAppToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.univExAppToolStripMenuItem.Text = "Univ. Ex. App";
            // 
            // changeIdColumnVisibleToolStripMenuItem
            // 
            this.changeIdColumnVisibleToolStripMenuItem.Name = "changeIdColumnVisibleToolStripMenuItem";
            this.changeIdColumnVisibleToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.changeIdColumnVisibleToolStripMenuItem.Text = "Change Id column visible";
            this.changeIdColumnVisibleToolStripMenuItem.Click += new System.EventHandler(this.changeIdColumnVisibleToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // mainDataGridView
            // 
            this.mainDataGridView.AllowUserToAddRows = false;
            this.mainDataGridView.AllowUserToDeleteRows = false;
            this.mainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.mainDataGridView.Location = new System.Drawing.Point(12, 47);
            this.mainDataGridView.Name = "mainDataGridView";
            this.mainDataGridView.Size = new System.Drawing.Size(546, 330);
            this.mainDataGridView.TabIndex = 1;
            // 
            // tablesComboBox
            // 
            this.tablesComboBox.FormattingEnabled = true;
            this.tablesComboBox.Location = new System.Drawing.Point(12, 21);
            this.tablesComboBox.Name = "tablesComboBox";
            this.tablesComboBox.Size = new System.Drawing.Size(546, 21);
            this.tablesComboBox.TabIndex = 2;
            this.tablesComboBox.SelectedIndexChanged += new System.EventHandler(this.tablesComboBox_SelectedIndexChanged);
            // 
            // rowAddDataGridView
            // 
            this.rowAddDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rowAddDataGridView.Location = new System.Drawing.Point(12, 383);
            this.rowAddDataGridView.Name = "rowAddDataGridView";
            this.rowAddDataGridView.Size = new System.Drawing.Size(546, 118);
            this.rowAddDataGridView.TabIndex = 3;
            // 
            // addRowButton
            // 
            this.addRowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addRowButton.Location = new System.Drawing.Point(486, 507);
            this.addRowButton.Name = "addRowButton";
            this.addRowButton.Size = new System.Drawing.Size(75, 23);
            this.addRowButton.TabIndex = 4;
            this.addRowButton.Text = "Add Rows";
            this.addRowButton.UseVisualStyleBackColor = true;
            this.addRowButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // deleteSelButton
            // 
            this.deleteSelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteSelButton.Location = new System.Drawing.Point(12, 507);
            this.deleteSelButton.Name = "deleteSelButton";
            this.deleteSelButton.Size = new System.Drawing.Size(100, 23);
            this.deleteSelButton.TabIndex = 5;
            this.deleteSelButton.Text = "Delete selected";
            this.deleteSelButton.UseVisualStyleBackColor = true;
            this.deleteSelButton.Click += new System.EventHandler(this.deleteSelButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeButton.Location = new System.Drawing.Point(173, 507);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(75, 23);
            this.changeButton.TabIndex = 6;
            this.changeButton.Text = "Change";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveChangesButton.Location = new System.Drawing.Point(254, 507);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(127, 23);
            this.saveChangesButton.TabIndex = 7;
            this.saveChangesButton.Text = "Save Changes";
            this.saveChangesButton.UseVisualStyleBackColor = true;
            this.saveChangesButton.Click += new System.EventHandler(this.saveChangesButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 534);
            this.Controls.Add(this.saveChangesButton);
            this.Controls.Add(this.changeButton);
            this.Controls.Add(this.deleteSelButton);
            this.Controls.Add(this.addRowButton);
            this.Controls.Add(this.rowAddDataGridView);
            this.Controls.Add(this.tablesComboBox);
            this.Controls.Add(this.mainDataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "UniversityExampleApp";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowAddDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem univExAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.DataGridView mainDataGridView;
        private System.Windows.Forms.ComboBox tablesComboBox;
        private System.Windows.Forms.DataGridView rowAddDataGridView;
        private System.Windows.Forms.Button addRowButton;
        private System.Windows.Forms.ToolStripMenuItem changeIdColumnVisibleToolStripMenuItem;
        private System.Windows.Forms.Button deleteSelButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Button saveChangesButton;
    }
}

