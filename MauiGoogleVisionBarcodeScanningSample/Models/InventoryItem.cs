using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiGoogleVisionBarcodeScanningSample
{
    public class InventoryItem
    {
        public int id { get; set; }
        public string delstk01 { get; set; }
        public string prtnum01 { get; set; }
        public string pmdes101 { get; set; }
        public string pmdes201 { get; set; }
        public double onhand01 { get; set; }
        public int rop01 { get; set; }
        public DateTime creationDate { get; set; }
    }

}
