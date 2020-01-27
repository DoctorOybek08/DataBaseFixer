namespace SqlDifference
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.sql1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.difference = new System.Windows.Forms.Button();
            this.database1 = new System.Windows.Forms.TextBox();
            this.database2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.field = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.null_Val = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.default_Val = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tablle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // sql1
            // 
            this.sql1.Location = new System.Drawing.Point(57, 25);
            this.sql1.Name = "sql1";
            this.sql1.Size = new System.Drawing.Size(346, 20);
            this.sql1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Table 1";
            // 
            // difference
            // 
            this.difference.Location = new System.Drawing.Point(419, 22);
            this.difference.Name = "difference";
            this.difference.Size = new System.Drawing.Size(75, 23);
            this.difference.TabIndex = 4;
            this.difference.Text = "Difference";
            this.difference.UseVisualStyleBackColor = true;
            this.difference.Click += new System.EventHandler(this.difference_Click);
            // 
            // database1
            // 
            this.database1.Location = new System.Drawing.Point(57, 3);
            this.database1.Name = "database1";
            this.database1.Size = new System.Drawing.Size(141, 20);
            this.database1.TabIndex = 1;
            // 
            // database2
            // 
            this.database2.Location = new System.Drawing.Point(258, 3);
            this.database2.Name = "database2";
            this.database2.Size = new System.Drawing.Size(145, 20);
            this.database2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "DB 1";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "DB 2";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(500, 22);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "EXECUTE";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.field,
            this.type,
            this.null_Val,
            this.key,
            this.default_Val,
            this.extra,
            this.tablle});
            this.dataGridView1.Location = new System.Drawing.Point(18, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(628, 473);
            this.dataGridView1.TabIndex = 9;
            // 
            // field
            // 
            this.field.HeaderText = "Field";
            this.field.Name = "field";
            // 
            // type
            // 
            this.type.HeaderText = "Type";
            this.type.Name = "type";
            // 
            // null_Val
            // 
            this.null_Val.HeaderText = "Null";
            this.null_Val.Name = "null_Val";
            this.null_Val.Width = 60;
            // 
            // key
            // 
            this.key.HeaderText = "Key";
            this.key.Name = "key";
            this.key.Width = 60;
            // 
            // default_Val
            // 
            this.default_Val.HeaderText = "Default";
            this.default_Val.Name = "default_Val";
            this.default_Val.Width = 60;
            // 
            // extra
            // 
            this.extra.HeaderText = "Extra";
            this.extra.Name = "extra";
            // 
            // tablle
            // 
            this.tablle.HeaderText = "Table";
            this.tablle.Name = "tablle";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(197, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 24);
            this.label5.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(581, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 36);
            this.button1.TabIndex = 11;
            this.button1.Text = "DB1 BackUP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 567);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.difference);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.database2);
            this.Controls.Add(this.database1);
            this.Controls.Add(this.sql1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sql1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button difference;
        private System.Windows.Forms.TextBox database1;
        private System.Windows.Forms.TextBox database2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn field;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn null_Val;
        private System.Windows.Forms.DataGridViewTextBoxColumn key;
        private System.Windows.Forms.DataGridViewTextBoxColumn default_Val;
        private System.Windows.Forms.DataGridViewTextBoxColumn extra;
        private System.Windows.Forms.DataGridViewTextBoxColumn tablle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}

