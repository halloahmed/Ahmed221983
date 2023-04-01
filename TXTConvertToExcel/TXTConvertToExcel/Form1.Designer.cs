namespace TXTConvertToExcel
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.DateiAuswählenBTN = new System.Windows.Forms.Button();
            this.TxTfromfile = new System.Windows.Forms.TextBox();
            this.DataGridfromTXT = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.TOExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridfromTXT)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pfad";
            // 
            // DateiAuswählenBTN
            // 
            this.DateiAuswählenBTN.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateiAuswählenBTN.Location = new System.Drawing.Point(503, 46);
            this.DateiAuswählenBTN.Name = "DateiAuswählenBTN";
            this.DateiAuswählenBTN.Size = new System.Drawing.Size(135, 28);
            this.DateiAuswählenBTN.TabIndex = 1;
            this.DateiAuswählenBTN.Text = "Datei auswählen";
            this.DateiAuswählenBTN.UseVisualStyleBackColor = true;
            this.DateiAuswählenBTN.Click += new System.EventHandler(this.DateiAuswählenBTN_Click);
            // 
            // TxTfromfile
            // 
            this.TxTfromfile.Location = new System.Drawing.Point(77, 49);
            this.TxTfromfile.Multiline = true;
            this.TxTfromfile.Name = "TxTfromfile";
            this.TxTfromfile.Size = new System.Drawing.Size(418, 23);
            this.TxTfromfile.TabIndex = 2;
            // 
            // DataGridfromTXT
            // 
            this.DataGridfromTXT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridfromTXT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridfromTXT.Location = new System.Drawing.Point(2, 96);
            this.DataGridfromTXT.Name = "DataGridfromTXT";
            this.DataGridfromTXT.Size = new System.Drawing.Size(1357, 509);
            this.DataGridfromTXT.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // TOExcel
            // 
            this.TOExcel.Location = new System.Drawing.Point(642, 47);
            this.TOExcel.Name = "TOExcel";
            this.TOExcel.Size = new System.Drawing.Size(114, 28);
            this.TOExcel.TabIndex = 4;
            this.TOExcel.Text = "ConvertToExcel";
            this.TOExcel.UseVisualStyleBackColor = true;
            this.TOExcel.Click += new System.EventHandler(this.TOExcel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 605);
            this.Controls.Add(this.TOExcel);
            this.Controls.Add(this.DataGridfromTXT);
            this.Controls.Add(this.TxTfromfile);
            this.Controls.Add(this.DateiAuswählenBTN);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridfromTXT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DateiAuswählenBTN;
        private System.Windows.Forms.TextBox TxTfromfile;
        private System.Windows.Forms.DataGridView DataGridfromTXT;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button TOExcel;
    }
}

