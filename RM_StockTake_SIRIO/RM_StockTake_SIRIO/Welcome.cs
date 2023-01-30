using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RM_StockTake_SIRIO
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnImportFile_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(DateTime.Now.ToString("dd/MM/yyyy"));
            //Import Data Form text File 
            DataAccess dataAccess=new  DataAccess();
            String state = dataAccess.createNewDB();
            if (state == String.Empty)
            {
                MessageBox.Show("File Imported","Information....",MessageBoxButtons.OK,MessageBoxIcon.None,MessageBoxDefaultButton.Button1);
                btnStockTake.Enabled = true;
            }
            else
            {
                MessageBox.Show(state);
                btnStockTake.Enabled = false;
            }

        }

        private void btnStockTake_Click(object sender, EventArgs e)
        {
            //Call StockTake Form
            StockTake stockTake = new StockTake();
            stockTake.Show();
        }
    }
}