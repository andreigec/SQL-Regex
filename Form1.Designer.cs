namespace SQLRegex
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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rowLV = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.connectionStringTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLB = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.columnsLB = new System.Windows.Forms.ListBox();
            this.inRegexesTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.outTBRegexes = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label6 = new System.Windows.Forms.Label();
            this.whereTB = new System.Windows.Forms.TextBox();
            this.QueryB = new System.Windows.Forms.Button();
            this.SaveChangesB = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Silver;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(894, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // rowLV
            // 
            this.rowLV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rowLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader1,
            this.columnHeader2});
            this.rowLV.Location = new System.Drawing.Point(20, 410);
            this.rowLV.Name = "rowLV";
            this.rowLV.ShowItemToolTips = true;
            this.rowLV.Size = new System.Drawing.Size(862, 226);
            this.rowLV.TabIndex = 1;
            this.rowLV.UseCompatibleStateImageBehavior = false;
            this.rowLV.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Table";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Column Name";
            this.columnHeader4.Width = 103;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Original";
            this.columnHeader1.Width = 295;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "After Regex";
            this.columnHeader2.Width = 345;
            // 
            // connectionStringTB
            // 
            this.connectionStringTB.Location = new System.Drawing.Point(15, 56);
            this.connectionStringTB.Name = "connectionStringTB";
            this.connectionStringTB.Size = new System.Drawing.Size(470, 20);
            this.connectionStringTB.TabIndex = 2;
         
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Connection String";
            // 
            // tableLB
            // 
            this.tableLB.FormattingEnabled = true;
            this.tableLB.Location = new System.Drawing.Point(20, 98);
            this.tableLB.Name = "tableLB";
            this.tableLB.Size = new System.Drawing.Size(237, 121);
            this.tableLB.TabIndex = 5;
            this.tableLB.SelectedIndexChanged += new System.EventHandler(this.tableLB_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Table";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(260, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Columns";
            // 
            // columnsLB
            // 
            this.columnsLB.FormattingEnabled = true;
            this.columnsLB.Location = new System.Drawing.Point(263, 98);
            this.columnsLB.Name = "columnsLB";
            this.columnsLB.Size = new System.Drawing.Size(237, 121);
            this.columnsLB.TabIndex = 7;
            this.columnsLB.SelectedIndexChanged += new System.EventHandler(this.columnsLB_SelectedIndexChanged);
            // 
            // inRegexesTB
            // 
            this.inRegexesTB.Location = new System.Drawing.Point(20, 298);
            this.inRegexesTB.Multiline = true;
            this.inRegexesTB.Name = "inRegexesTB";
            this.inRegexesTB.Size = new System.Drawing.Size(480, 77);
            this.inRegexesTB.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 282);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "In Regexes";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(506, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Out Regex";
            // 
            // outTBRegexes
            // 
            this.outTBRegexes.Location = new System.Drawing.Point(506, 298);
            this.outTBRegexes.Multiline = true;
            this.outTBRegexes.Name = "outTBRegexes";
            this.outTBRegexes.Size = new System.Drawing.Size(376, 77);
            this.outTBRegexes.TabIndex = 12;
            this.outTBRegexes.Text = "\r\n";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 598);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(894, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Where...";
            // 
            // whereTB
            // 
            this.whereTB.Location = new System.Drawing.Point(20, 248);
            this.whereTB.Name = "whereTB";
            this.whereTB.Size = new System.Drawing.Size(480, 20);
            this.whereTB.TabIndex = 15;
            // 
            // QueryB
            // 
            this.QueryB.Location = new System.Drawing.Point(20, 381);
            this.QueryB.Name = "QueryB";
            this.QueryB.Size = new System.Drawing.Size(75, 23);
            this.QueryB.TabIndex = 17;
            this.QueryB.Text = "Query";
            this.QueryB.UseVisualStyleBackColor = true;
            this.QueryB.Click += new System.EventHandler(this.QueryB_Click);
            // 
            // SaveChangesB
            // 
            this.SaveChangesB.Location = new System.Drawing.Point(761, 381);
            this.SaveChangesB.Name = "SaveChangesB";
            this.SaveChangesB.Size = new System.Drawing.Size(121, 23);
            this.SaveChangesB.TabIndex = 18;
            this.SaveChangesB.Text = "Get SQL";
            this.SaveChangesB.UseVisualStyleBackColor = true;
            this.SaveChangesB.Click += new System.EventHandler(this.SaveChangesB_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 620);
            this.Controls.Add(this.SaveChangesB);
            this.Controls.Add(this.QueryB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.whereTB);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.outTBRegexes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.inRegexesTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.columnsLB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tableLB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.connectionStringTB);
            this.Controls.Add(this.rowLV);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ListView rowLV;
        private System.Windows.Forms.TextBox connectionStringTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox tableLB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox columnsLB;
        private System.Windows.Forms.TextBox inRegexesTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox outTBRegexes;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox whereTB;
        private System.Windows.Forms.Button QueryB;
        private System.Windows.Forms.Button SaveChangesB;
    }
}

