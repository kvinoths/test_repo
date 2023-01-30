using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;
namespace RM_StockTake_SIRIO
{

    //Satus 
    //Initial "DW"  Download
    //"ML" Modified Location
    //"MQ" Modified Quantity
    //"NW" New Record
    //"SC" Scand 
    // ScanDate will enter only for scan without an error
   public class DataAccess
    {
       // string conStr = @"Data Source=.\\Program Files\\RMStockTake_SIRIO\\DataFiles\\StockTake.sdf";
       string conStr = @"Data Source=.\\Program Files\\RMStockTake_SIRIO\\DataFiles\\StockTake.sdf";
        public String createNewDB()
        {
            String state = "";
            System.IO.File.Delete(@".\\Program Files\\RMStockTake_SIRIO\\DataFiles\\StockTake.sdf");
            if (System.IO.File.Exists(@".\\Program Files\\RMStockTake_SIRIO\\DataFiles\\StockTake1.sdf"))
            {               
            }
            else
            {
                state=createDB();
                createStockTakeImportDetail();
            }

            state=InsertStoTakDetailsData();
            return state;
        }

        private String createDB()
        {
            SqlCeEngine engine = new SqlCeEngine();
            engine.LocalConnectionString = conStr;
            try
            {
                engine.CreateDatabase();
            }
            catch (SqlCeException sqlEx)
            {
                return sqlEx.ToString();
             //   mess.Show(sqlEx.ToString());
            }
            return "";
        }

        private void createStockTakeImportDetail()
        {
            SqlCeConnection con = new SqlCeConnection();
            SqlCeCommand ceCmd = new SqlCeCommand();
            con.ConnectionString = conStr;
            con.Open();
            ceCmd.Connection = con;

            string sqlCmd = "CREATE TABLE [StockTakeImportDetails](" +
                                "[Material] [nvarchar](20) NULL," +
                                "[Batch] [nvarchar](20) NULL," +
                                "[Gr_Date] [datetime] NULL," +
                                "[BarCode] [nvarchar](20) NULL," +
                                "[StandardLocation] [nvarchar](20) NULL," +
                                "[ActualLocation] [nvarchar](20) NULL," +
                                "[StandardStock] [decimal](18, 3) NULL," +
                                "[ActualStock] [decimal](18, 3) NULL," +
                                "[Storage_Type] [int] NULL," +
                                "[Storage_Bin] [nvarchar](50) NULL," +
                                "[Transfer_Order_Number] [nvarchar](20) NULL, " +
                                "[Status] [nvarchar](2) NULL, " +
                                "[CreatedDate] [datetime] NULL, " +
                                "[LocationModifiedDate] [datetime] NULL, " +
                                "[StockModifiedDate] [datetime] NULL, " +
                                "[Device] [nvarchar](30) NULL," +
                                "[UserName] [nvarchar](20) NULL," +
                                "[ScanDate] [datetime] NULL " +
                                ") ";

            ceCmd.CommandText = sqlCmd;
            ceCmd.ExecuteNonQuery();
            con.Close();

        }

      
        private String InsertStoTakDetailsData()
        {
            string targetFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
            string targetFileName = Path.Combine(targetFolder, "DataFiles\\ImportData_Text.txt");

            SqlCeConnection con = new SqlCeConnection();
            SqlCeCommand ceCmd = new SqlCeCommand();
            con.ConnectionString = conStr;
            con.Open();
            ceCmd.Connection = con;

            if (File.Exists(targetFileName))
            {
                using (Stream myStream = File.Open(targetFileName, FileMode.Open, FileAccess.Read))
                {
                    StreamReader sr = new StreamReader(myStream);
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        RawMaterials rm = new RawMaterials();
                        string[] Tokens = Regex.Split(line, ",");
                        string Material = Tokens[0];
                        string Batch = Tokens[1];
                        DateTime Gr_Date = Convert.ToDateTime(Tokens[2]);
                        string BarCode = Tokens[3];
                        string StandardLocation = Tokens[4];
                        string ActualLocation = Tokens[4];

                        decimal StandardStock = Convert.ToDecimal(Tokens[5]);
                        decimal ActualStock = Convert.ToDecimal(Tokens[5]);

                        decimal Total_Stock = Convert.ToDecimal(Tokens[6]);
                        int Storage_Type = Convert.ToInt16(Tokens[7]);
                        string Storage_Bin = Tokens[8];
                        string Transfer_Order_Number = Tokens[9];


                        ceCmd.CommandText = "INSERT INTO StockTakeImportDetails"
                            + " ([Material],[Batch],[Gr_Date],[BarCode],[StandardLocation],[ActualLocation],[StandardStock],[ActualStock],[Storage_Type],[Storage_Bin],[Transfer_Order_Number],[Status],[CreatedDate],[Device])"
                            + " VALUES ( "+
                    "'" + Material + "'," +
                    "'" + Batch + "'," +
                    "'" + Gr_Date + "'," +
                    "'" + BarCode + "'," +
                    "'" + StandardLocation + "'," +
                    "'" + ActualLocation + "'," +
                    StandardStock + "," +
                    ActualStock + "," +
                    Storage_Type + "," +
                    "'" + Storage_Bin + "'," +
                    "'" + Transfer_Order_Number + "'," +
                    "'" + "DW" + "'," +   //Downloaded
                    "'" + (DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss")) + "'," +
                    "'" + (System.Net.Dns.GetHostName().ToString()) + "'" +    
                        ")";

                        try
                        {
                            ceCmd.ExecuteNonQuery();
                        }
                        catch (SqlCeException ex)
                        {
                            return ex.ToString();
                            //MessageBox.Show(ex.ToString());
                        }
                    }
                }
            }
            return "";
            con.Close();
        }

        public RawMaterials GetBarcodeDetail(string barCode)
        {
            RawMaterials rmd = new RawMaterials();

            SqlCeConnection con = new SqlCeConnection();
            SqlCeCommand ceCmd = new SqlCeCommand();
            con.ConnectionString = conStr;
            con.Open();
            ceCmd.Connection = con;

            SqlCeDataAdapter Adapter = new SqlCeDataAdapter();
           // ceCmd.CommandText = "SELECT OperationID FROM TeamDetails WHERE OperationID = '" + this.textBox2.Text + "' ";
            ceCmd.CommandText = "SELECT  * FROM  StockTakeImportDetails WHERE BarCode="
            + "'" + (barCode).Trim() + "'";
            Adapter.SelectCommand = ceCmd;
            DataSet ds = new DataSet();
            if (ds != null)
            {
                Adapter.Fill(ds);

                if (ds.Tables[0].Rows.Count != 0)
                {
                    Adapter.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        rmd.Material = ds.Tables[0].Rows[i]["Material"].ToString();
                        rmd.StandardLocation = ds.Tables[0].Rows[i]["StandardLocation"].ToString();
                        rmd.ActualLocation = ds.Tables[0].Rows[i]["ActualLocation"].ToString();
                        rmd.StandardStock = ds.Tables[0].Rows[i]["StandardStock"].ToString();
                        rmd.ActualStock = ds.Tables[0].Rows[i]["ActualStock"].ToString();
                        rmd.BarCode = ds.Tables[0].Rows[i]["BarCode"].ToString();
                    }
                }
                else
                {
                    //SaveDetails();
                }
            }
            ds.Dispose();
            con.Close();
            return rmd;
        }

        public int UpdateLocationStatus(string barCode, string actualLocation)
        {

            SqlCeConnection con = new SqlCeConnection();
            SqlCeCommand ceCmd = new SqlCeCommand();
            con.ConnectionString = conStr;
            con.Open();
            ceCmd.Connection = con;


            ceCmd.CommandText = "Update StockTakeImportDetails Set "
                + "ActualLocation ='" + actualLocation + "',"
                + "LocationModifiedDate ='" + (DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss")) + "',"
                + "Status ='" + "ML" + "'"
                + " WHERE BarCode ='" + barCode  + "'";

            try
            {
                ceCmd.ExecuteNonQuery();
            }
            catch (SqlCeException ex)
            {
                return 0;
            }

            con.Close();


            return 1;
        }
        public int UpdateStockStatus(string barCode, string actualStock)
        {

            SqlCeConnection con = new SqlCeConnection();
            SqlCeCommand ceCmd = new SqlCeCommand();
            con.ConnectionString = conStr;
            con.Open();
            ceCmd.Connection = con;


            ceCmd.CommandText = "Update StockTakeImportDetails Set "
                + "ActualStock ='" + actualStock + "',"
                + "StockModifiedDate ='" + (DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss")) + "',"
                + "Status ='" + "MQ" + "'"
                + " WHERE BarCode ='" + barCode + "'";

            try
            {
                ceCmd.ExecuteNonQuery();
            }
            catch (SqlCeException ex)
            {
                return 0;
            }

            con.Close();


            return 1;
        }

        public int UpdateScanstatus(string barCode)
        {

            SqlCeConnection con = new SqlCeConnection();
            SqlCeCommand ceCmd = new SqlCeCommand();
            con.ConnectionString = conStr;
            con.Open();
            ceCmd.Connection = con;


            ceCmd.CommandText = "Update StockTakeImportDetails Set "
                + "Status ='" + "SC" + "',"
                + "ScanDate ='" + (DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss")) + "'"
                + " WHERE BarCode ='" + barCode + "'";
            try
            {
                ceCmd.ExecuteNonQuery();
            }
            catch (SqlCeException ex)
            {
                return 0;
            }

            con.Close();


            return 1;
        }

        public int AddNewRM(string barCode, string actualLocation, string actualStock)
        {

            SqlCeConnection con = new SqlCeConnection();
            SqlCeCommand ceCmd = new SqlCeCommand();
            con.ConnectionString = conStr;
            con.Open();
            ceCmd.Connection = con;


            ceCmd.CommandText = "INSERT INTO StockTakeImportDetails"
                            + " ([BarCode],[ActualLocation],[ActualStock],[Status],[CreatedDate],[Device])"
                            + " VALUES ( " +
                    "'" + barCode + "'," +
                    "'" + actualLocation + "'," +
                    "'" + (actualStock.ToString() == "" ? "0" : actualStock).ToString() + "'," +
                    "'" + "NW" + "'," +   //New Record
                    "'" + (DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss")) + "'," +
                    "'" + (System.Net.Dns.GetHostName().ToString()) + "'" +
                        ")";


            try
            {
                ceCmd.ExecuteNonQuery();
            }
            catch (SqlCeException ex)
            {
                return 0;
            }

            con.Close();


            return 1;
        }
        public List<RawMaterials> GetBarcodeDetails()
        {
            List<RawMaterials> rmds = new List<RawMaterials>();

            RawMaterials rmd = new RawMaterials();

            SqlCeConnection con = new SqlCeConnection();
            SqlCeCommand ceCmd = new SqlCeCommand();
            con.ConnectionString = conStr;
            con.Open();
            ceCmd.Connection = con;

            SqlCeDataAdapter Adapter = new SqlCeDataAdapter();
            ceCmd.CommandText = "SELECT  * FROM  StockTakeImportDetails Order by Status desc";
            Adapter.SelectCommand = ceCmd;
            DataSet ds = new DataSet();
           
            if (ds != null)
            {
                Adapter.Fill(ds);
                if (ds.Tables[0].Rows.Count != 0)
                {
                   
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        rmd = new RawMaterials();
                        rmd.Material = ds.Tables[0].Rows[i]["Material"].ToString();
                        rmd.StandardLocation = ds.Tables[0].Rows[i]["StandardLocation"].ToString();
                        rmd.ActualLocation = ds.Tables[0].Rows[i]["ActualLocation"].ToString();
                        rmd.StandardStock = ds.Tables[0].Rows[i]["StandardStock"].ToString();
                        rmd.ActualStock = ds.Tables[0].Rows[i]["ActualStock"].ToString();
                        rmd.BarCode = ds.Tables[0].Rows[i]["BarCode"].ToString();
                        rmd.Status = ds.Tables[0].Rows[i]["Status"].ToString();

                        rmds.Add(rmd);
                    }
                }
                
            }
            ds.Dispose();
            con.Close();
            return rmds;
        }

    }
    
}
