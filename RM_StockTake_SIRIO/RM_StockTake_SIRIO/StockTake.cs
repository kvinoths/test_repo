using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Symbol.Barcode2;

namespace RM_StockTake_SIRIO
{
    public partial class StockTake : Form
    {
        int status_Add = 0;
        private static Barcode2 barcodeReader;
        
        public StockTake()
        {
            InitializeComponent();
            InitializeScanner();
            txtBarCode.Enabled = true;
            txtBarCode.Focus();
        }
        private void InitializeScanner()
        {
            try
            {

                //Create new instance of Barcode2 class
                barcodeReader = new Barcode2();

                //Enable the device
                barcodeReader.Enable();
                barcodeReader.Config.TriggerMode = TRIGGERMODES.HARD;
                barcodeReader.Config.Decoders.I2OF5.MinLength=0;
                barcodeReader.Config.Decoders.I2OF5.MaxLength=20;

                barcodeReader.Config.TriggerMode = TRIGGERMODES.HARD;

                // Register a scan event handler to the barcode object
                barcodeReader.OnScan += new Barcode2.OnScanHandler(BCReader_OnScan);

                // Register a status event handler to the barcode object
                //BCReader.OnStatus += new Barcode2.OnStatusHandler(BCReader_OnStatus);

                // Issue an Asynchronous scan that calls back to an event delegate when a trigger is pulled
                Results sd = barcodeReader.Scan();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        private void BCReader_OnScan(ScanDataCollection sdc)
        {
            try
            {
                // If the asynchronous scanning is done in the buffered mode, there may be more than one scanned data in the collection
                foreach (ScanData sd in sdc)
                {
                    if (sd.Result == Results.SUCCESS)
                    {
                        HandleScan(sd.Text);
                    }
                }

                Results r = barcodeReader.Scan();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        private void HandleScan(string scandText)
        {
            scanner_ScanCompleteEvent(scandText);
        }
        private void scanner_ScanCompleteEvent(string scandText)
        {
           // MessageBox.Show(scandText);
            txtBarCode.Enabled = true;
            txtBarCode.Focus();
            txtBarCode.Text = scandText;
            txtBarCode.Enabled = false;
             DataAccess dataAccess = new DataAccess();
             RawMaterials rmd = new RawMaterials();
             status_Add = 0;

             rmd = dataAccess.GetBarcodeDetail(scandText);
             if (rmd != null)
             {
                 if (rmd.BarCode != null)
                 {
                     txtBarCode.Text = rmd.BarCode;
                     txtActualLocation.Text = rmd.ActualLocation;
                     txtStandardLocation.Text = rmd.StandardLocation;
                     txtMeterial.Text = rmd.Material;
                     txtActualStock.Text = rmd.ActualStock;
                     txtStandardStock.Text = rmd.StandardStock;
                     btnNext.Focus();
                 }
                 else 
                 {
                     ItemNotFound();
                 }
             }
             else
             {
                 ItemNotFound();
             }
            
        }
        private void ItemNotFound()
        {
            if (MessageBox.Show("Scanned Material not found in the system,Do you want to add ?", "New RM Found", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                status_Add = 1;
                AddNewRM();
                btnNext.Focus();
            }
            else
            {
                status_Add = 0;

                txtBarCode.Text = "";
                txtBarCode.Focus();
                txtActualLocation.Text = "";
                txtStandardLocation.Text = "";
                txtMeterial.Text = "";
                txtActualStock.Text = "";
                txtStandardStock.Text = "";
                btnNext.Focus();
            }
        
        }
        private int ValidateData()
        {
           int status=1;
            //check location is Different 
           if (txtActualLocation.Text != txtStandardLocation.Text)
            {
                if (MessageBox.Show("Material location is mismatch do you waint to procede ?", "Location is Mismatch", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    status=UpdateLocationStatus();
                    status = 2;
                }
                else
                {
                    status = 0;
                }
            }
           //check location is Different 

           if (txtActualStock.Text != txtStandardStock.Text)
            {
                if (MessageBox.Show("Material Quantity is mismatch do you waint to procede ?", "Quantity is Mismatch", MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    status = UpdateStockStatus();
                    status = 3;
                }
                else
                {
                    status = 0;
                }
            }
           //check status =1 scand status update
            if (status == 1 && status_Add==0)
            {
                UpdateScanStatus();
            }
            if (status == 2 || status == 3)
            {
                status = 1;
            }
           return status;
        }
        private int UpdateLocationStatus()
        { 
           int status=1;
           DataAccess dataAccess = new DataAccess();
           dataAccess.UpdateLocationStatus(txtBarCode.Text, txtActualLocation.Text);
           return status;
        }
        private int UpdateStockStatus()
        {
            int status = 1;
            DataAccess dataAccess = new DataAccess();
            dataAccess.UpdateStockStatus(txtBarCode.Text,txtActualStock.Text);
            return status;
        }
        private int UpdateScanStatus()
        {
            int status = 1;
            DataAccess dataAccess = new DataAccess();
            dataAccess.UpdateScanstatus(txtBarCode.Text);
            return status;
        }
        private int AddNewRM()
        {
            int status = 1;
            DataAccess dataAccess = new DataAccess();
            dataAccess.AddNewRM(txtBarCode.Text,txtActualLocation.Text,txtActualStock.Text);
            return status;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //validate data if sucuess forwed to  new page
            if (ValidateData()==1)
            {

                txtBarCode.Text = "";
                txtMeterial.Text = "";
                txtActualLocation.Text = "";
                txtStandardLocation.Text = "";
                txtActualStock.Text = "";
                txtStandardStock.Text = "";
                txtBarCode.Focus();
                txtBarCode.Enabled=true;
            }
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            Export export = new Export();
            export.Show(); 
        }       
    }
}