using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace RM_StockTake_SIRIO
{
    public class RawMaterials
    {
        private string material ;
        private string batch;  
        private string gr_Date;
        private string barCode;//BarCode   
        private string standardLocation;
        private string actualLocation;
        private string standardStock;
        private string actualStock;   
        private string storage_Type;   
        private string storage_Bin;   
        private string transfer_Order_Number;
        private string status;

        public string Material
        {
            get
            {
                return material;
            }
            set
            {
                material = value;
            }
        }
        public string Batch
        {
            get
            {
                return batch;
            }
            set
            {
                batch = value;
            }
        }
        public string Gr_Date
        {
            get
            {
                return gr_Date;
            }
            set
            {
                gr_Date = value;
            }
        }
        
        public string BarCode
        {
            get
            {
                return barCode;
            }
            set
            {
                barCode = value;
            }
        }
        public string StandardLocation
        {
            get
            {
                return standardLocation;
            }
            set
            {
                standardLocation = value;
            }
        }
        public string ActualLocation
        {
            get
            {
                return actualLocation;
            }
            set
            {
                actualLocation = value;
            }
        }
        public string StandardStock
        {
            get
            {
                return standardStock;
            }
            set
            {
                standardStock = value;
            }
        }
        
        public string ActualStock
        {
            get
            {
                return actualStock;
            }
            set
            {
                actualStock = value;
            }
        }
        public string Storage_Bin
        {
            get
            {
                return storage_Bin;
            }
            set
            {
                storage_Bin = value;
            }
        }
        public string Transfer_Order_Number
        {
            get
            {
                return transfer_Order_Number;
            }
            set
            {
                transfer_Order_Number = value;
            }
        }
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }
    }
}
