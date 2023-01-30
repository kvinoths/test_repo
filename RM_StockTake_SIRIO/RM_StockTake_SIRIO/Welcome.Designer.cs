namespace RM_StockTake_SIRIO
{
    partial class Welcome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.btnImportFile = new System.Windows.Forms.Button();
            this.btnStockTake = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnImportFile
            // 
            this.btnImportFile.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnImportFile.Location = new System.Drawing.Point(78, 21);
            this.btnImportFile.Name = "btnImportFile";
            this.btnImportFile.Size = new System.Drawing.Size(84, 30);
            this.btnImportFile.TabIndex = 0;
            this.btnImportFile.Text = "Import File";
            this.btnImportFile.Click += new System.EventHandler(this.btnImportFile_Click);
            // 
            // btnStockTake
            // 
            this.btnStockTake.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnStockTake.Enabled = false;
            this.btnStockTake.Location = new System.Drawing.Point(78, 84);
            this.btnStockTake.Name = "btnStockTake";
            this.btnStockTake.Size = new System.Drawing.Size(84, 30);
            this.btnStockTake.TabIndex = 1;
            this.btnStockTake.Text = "StockTake";
            this.btnStockTake.Click += new System.EventHandler(this.btnStockTake_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Coral;
            this.btnExit.Location = new System.Drawing.Point(16, 155);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 30);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(228, 201);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStockTake);
            this.Controls.Add(this.btnImportFile);
            this.Menu = this.mainMenu1;
            this.Name = "Welcome";
            this.Text = "Kingslake";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImportFile;
        private System.Windows.Forms.Button btnStockTake;
        private System.Windows.Forms.Button btnExit;
    }
}