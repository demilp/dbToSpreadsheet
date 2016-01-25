namespace BypassSqlExecuter
{
    partial class SqlExecutor
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
            this.queryTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.executeBtn = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.executeBtn2 = new System.Windows.Forms.Button();
            this.queryTb2 = new System.Windows.Forms.TextBox();
            this.executeBtn3 = new System.Windows.Forms.Button();
            this.queryTb3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.resultLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // queryTb
            // 
            this.queryTb.Location = new System.Drawing.Point(78, 26);
            this.queryTb.Multiline = true;
            this.queryTb.Name = "queryTb";
            this.queryTb.Size = new System.Drawing.Size(556, 66);
            this.queryTb.TabIndex = 0;
            this.queryTb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.queryTb_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Query:";
            // 
            // executeBtn
            // 
            this.executeBtn.Location = new System.Drawing.Point(640, 69);
            this.executeBtn.Name = "executeBtn";
            this.executeBtn.Size = new System.Drawing.Size(75, 23);
            this.executeBtn.TabIndex = 2;
            this.executeBtn.Text = "Execute";
            this.executeBtn.UseVisualStyleBackColor = true;
            this.executeBtn.Click += new System.EventHandler(this.executeBtn_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToOrderColumns = true;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Location = new System.Drawing.Point(37, 286);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(677, 406);
            this.grid.TabIndex = 3;
            // 
            // executeBtn2
            // 
            this.executeBtn2.Location = new System.Drawing.Point(640, 141);
            this.executeBtn2.Name = "executeBtn2";
            this.executeBtn2.Size = new System.Drawing.Size(75, 23);
            this.executeBtn2.TabIndex = 5;
            this.executeBtn2.Text = "Execute";
            this.executeBtn2.UseVisualStyleBackColor = true;
            this.executeBtn2.Click += new System.EventHandler(this.executeBtn2_Click);
            // 
            // queryTb2
            // 
            this.queryTb2.Location = new System.Drawing.Point(78, 98);
            this.queryTb2.Multiline = true;
            this.queryTb2.Name = "queryTb2";
            this.queryTb2.Size = new System.Drawing.Size(556, 66);
            this.queryTb2.TabIndex = 4;
            // 
            // executeBtn3
            // 
            this.executeBtn3.Location = new System.Drawing.Point(640, 213);
            this.executeBtn3.Name = "executeBtn3";
            this.executeBtn3.Size = new System.Drawing.Size(75, 23);
            this.executeBtn3.TabIndex = 7;
            this.executeBtn3.Text = "Execute";
            this.executeBtn3.UseVisualStyleBackColor = true;
            this.executeBtn3.Click += new System.EventHandler(this.executeBtn3_Click);
            // 
            // queryTb3
            // 
            this.queryTb3.Location = new System.Drawing.Point(78, 170);
            this.queryTb3.Multiline = true;
            this.queryTb3.Name = "queryTb3";
            this.queryTb3.Size = new System.Drawing.Size(556, 66);
            this.queryTb3.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Result:";
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(80, 249);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 13);
            this.resultLabel.TabIndex = 9;
            // 
            // SqlExecuter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 707);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.executeBtn3);
            this.Controls.Add(this.queryTb3);
            this.Controls.Add(this.executeBtn2);
            this.Controls.Add(this.queryTb2);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.executeBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.queryTb);
            this.Name = "SqlExecuter";
            this.Text = "SQLExecuter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SqlExecuter_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox queryTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button executeBtn;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button executeBtn2;
        private System.Windows.Forms.TextBox queryTb2;
        private System.Windows.Forms.Button executeBtn3;
        private System.Windows.Forms.TextBox queryTb3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label resultLabel;
    }
}

