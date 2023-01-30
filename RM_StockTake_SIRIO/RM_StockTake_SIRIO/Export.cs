using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
//using System.Threading.Tasks; // for Task class
using System.Threading; // for Thread class
namespace RM_StockTake_SIRIO
{
    public partial class Export : Form
    {
        public Export()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExportFile_Click(object sender, EventArgs e)
        {
            string PhysicallyNotExistsOrNotScannedReport = ".\\Program Files\\RMStockTake_SIRIO\\DataFiles\\PhysicallyNotExistsOrNotScannedReport.txt";
            string QTYDifferentceReport = ".\\Program Files\\RMStockTake_SIRIO\\DataFiles\\QTYDifferentceReport.txt";
            string ManuallyEnteredReport = ".\\Program Files\\RMStockTake_SIRIO\\DataFiles\\ManuallyEnteredReport.txt";
            
            DataAccess dataAccess = new DataAccess();
            List<RawMaterials> rmds = new List<RawMaterials>();
            StreamWriter physicallyNotExist_Outpufile;
            StreamWriter qTYDifferentce_Outpufile;
            StreamWriter manuallyEntered_Outpufile;

                physicallyNotExist_Outpufile = new StreamWriter(PhysicallyNotExistsOrNotScannedReport);
                qTYDifferentce_Outpufile = new StreamWriter(QTYDifferentceReport);
                manuallyEntered_Outpufile = new StreamWriter(ManuallyEnteredReport);

                physicallyNotExist_Outpufile.Flush();
                qTYDifferentce_Outpufile.Flush();
                manuallyEntered_Outpufile.Flush();

              
            string text = "";
            rmds = dataAccess.GetBarcodeDetails();
                        if (rmds != null)
                        {
                            physicallyNotExist_Outpufile.WriteLine("Bar Code            |Material            |Quantity");
                            qTYDifferentce_Outpufile.WriteLine("Bar Code            |Material            |Standard Quantity   |Actual");
                            manuallyEntered_Outpufile.WriteLine("Bar Code            |Material            |Quantity");

                                foreach (var point in rmds)
                            {
                                text = "";
                               
                                //MannualyEntered
                                if (point.Status.ToString().Trim() == "NW")
                                {
                                   // MessageBox.Show(point.Status.ToString().Trim());
                                    Thread.Sleep(8000);
                                    text = point.BarCode.ToString()
                                             + "," + string.Format("{0,20}", point.Material.ToString())
                                             + "," + string.Format("{0,20}",point.ActualStock.ToString());
                                    manuallyEntered_Outpufile.WriteLine(text.Trim());
                                }
                                //QTYDifferentce
                                else if (point.Status.ToString().Trim() == "MQ")
                                {
                                    text = point.BarCode.ToString()
                                           + "," + string.Format("{0,20}", point.Material.ToString())
                                           + "," + string.Format("{0,20}", point.StandardStock.ToString())
                                           + "," + string.Format("{0,20}", point.ActualStock.ToString());
                                    qTYDifferentce_Outpufile.WriteLine(text);
                                }
                                //PhysicallyNotExist
                                else if (point.Status.ToString().Trim() == "DW")
                                {
                                    text = point.BarCode.ToString()
                                           + "," + string.Format("{0,20}", point.Material.ToString())
                                           + "," + string.Format("{0,20}", point.StandardStock.ToString());
                                    physicallyNotExist_Outpufile.WriteLine(text);
                                }
                                else {
                                   // MessageBox.Show(point.Status.ToString());
                                }
                                
                            }
                        }
            physicallyNotExist_Outpufile.Close();
            qTYDifferentce_Outpufile.Close();
            manuallyEntered_Outpufile.Close();
            MessageBox.Show("Export has successfully completed");
        }
           

        private void btnBack_Click(object sender, EventArgs e)
        {
            StockTake stockTake = new StockTake();
            stockTake.Show(); 
        }
       

       
    }
}