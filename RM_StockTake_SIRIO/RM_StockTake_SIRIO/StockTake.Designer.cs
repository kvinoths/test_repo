namespace RM_StockTake_SIRIO
{
    partial class StockTake
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
            this.lblStockTake = new System.Windows.Forms.Label();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.txtMeterial = new System.Windows.Forms.TextBox();
            this.txtActualLocation = new System.Windows.Forms.TextBox();
            this.txtActualStock = new System.Windows.Forms.TextBox();
            this.lblBarCode = new System.Windows.Forms.Label();
            this.lblMeterial = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.txtStandardStock = new System.Windows.Forms.TextBox();
            this.txtStandardLocation = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblStockTake
            // 
            this.lblStockTake.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblStockTake.Location = new System.Drawing.Point(48, 6);
            this.lblStockTake.Name = "lblStockTake";
            this.lblStockTake.Size = new System.Drawing.Size(136, 20);
            this.lblStockTake.Text = "Stock Take";
            // 
            // txtBarCode
            // 
            this.txtBarCode.Enabled = false;
            this.txtBarCode.Location = new System.Drawing.Point(62, 30);
            this.txtBarCode.MaxLength = 20;
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(163, 23);
            this.txtBarCode.TabIndex = 1;
            // 
            // txtMeterial
            // 
            this.txtMeterial.Enabled = false;
            this.txtMeterial.Location = new System.Drawing.Point(62, 59);
            this.txtMeterial.MaxLength = 20;
            this.txtMeterial.Name = "txtMeterial";
            this.txtMeterial.Size = new System.Drawing.Size(163, 23);
            this.txtMeterial.TabIndex = 2;
            // 
            // txtActualLocation
            // 
            this.txtActualLocation.Location = new System.Drawing.Point(62, 88);
            this.txtActualLocation.MaxLength = 20;
            this.txtActualLocation.Name = "txtActualLocation";
            this.txtActualLocation.Size = new System.Drawing.Size(83, 23);
            this.txtActualLocation.TabIndex = 3;
            // 
            // txtActualStock
            // 
            this.txtActualStock.Location = new System.Drawing.Point(62, 117);
            this.txtActualStock.MaxLength = 20;
            this.txtActualStock.Name = "txtActualStock";
            this.txtActualStock.Size = new System.Drawing.Size(83, 23);
            this.txtActualStock.TabIndex = 4;
            // 
            // lblBarCode
            // 
            this.lblBarCode.Location = new System.Drawing.Point(7, 30);
            this.lblBarCode.Name = "lblBarCode";
            this.lblBarCode.Size = new System.Drawing.Size(55, 22);
            this.lblBarCode.Text = "Barcode";
            // 
            // lblMeterial
            // 
            this.lblMeterial.Location = new System.Drawing.Point(7, 59);
            this.lblMeterial.Name = "lblMeterial";
            this.lblMeterial.Size = new System.Drawing.Size(62, 20);
            this.lblMeterial.Text = "Meterial";
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(7, 89);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(62, 20);
            this.lblLocation.Text = "Location";
            // 
            // lblQuantity
            // 
            this.lblQuantity.Location = new System.Drawing.Point(7, 117);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(62, 20);
            this.lblQuantity.Text = "Quantity";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Coral;
            this.btnExit.Location = new System.Drawing.Point(10, 145);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 30);
            this.btnExit.TabIndex = 11;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Coral;
            this.btnNext.Location = new System.Drawing.Point(146, 145);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 30);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.Color.Coral;
            this.btnFinish.Location = new System.Drawing.Point(10, 193);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(72, 30);
            this.btnFinish.TabIndex = 13;
            this.btnFinish.Text = "Finish";
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // txtStandardStock
            // 
            this.txtStandardStock.Enabled = false;
            this.txtStandardStock.Location = new System.Drawing.Point(148, 117);
            this.txtStandardStock.Name = "txtStandardStock";
            this.txtStandardStock.Size = new System.Drawing.Size(77, 23);
            this.txtStandardStock.TabIndex = 19;
            // 
            // txtStandardLocation
            // 
            this.txtStandardLocation.Enabled = false;
            this.txtStandardLocation.Location = new System.Drawing.Point(148, 88);
            this.txtStandardLocation.Name = "txtStandardLocation";
            this.txtStandardLocation.Size = new System.Drawing.Size(77, 23);
            this.txtStandardLocation.TabIndex = 20;
            // 
            // StockTake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(228, 240);
            this.Controls.Add(this.txtActualStock);
            this.Controls.Add(this.txtActualLocation);
            this.Controls.Add(this.txtMeterial);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.txtStandardLocation);
            this.Controls.Add(this.txtStandardStock);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblMeterial);
            this.Controls.Add(this.lblBarCode);
            this.Controls.Add(this.lblStockTake);
            this.Menu = this.mainMenu1;
            this.Name = "StockTake";
            this.Text = "StockTake";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStockTake;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.TextBox txtMeterial;
        private System.Windows.Forms.TextBox txtActualLocation;
        private System.Windows.Forms.TextBox txtActualStock;
        private System.Windows.Forms.Label lblBarCode;
        private System.Windows.Forms.Label lblMeterial;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.TextBox txtStandardStock;
        private System.Windows.Forms.TextBox txtStandardLocation;
    }
}