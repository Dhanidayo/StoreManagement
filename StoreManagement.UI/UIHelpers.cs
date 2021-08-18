using System;
using Management.BL;
using Management.Commons;
using Management.DB;
using Management.Models;
using System.Collections.Generic;

namespace StoreManagement.UI
{
    public class UIHelpers
    {
        //table display for customer store history
        public static void DisplayHistoryTable(List<Store> stores)
        {
            TableDisplay.PrintLine();
            TableDisplay.PrintRow("Store Type", "Store Name", "Store ID", "Products" );
            TableDisplay.PrintLine();

            foreach (var store in stores)
            {
                TableDisplay.PrintRow(Convert.ToString(store.StoreType), store.StoreName, store.StoreId, Convert.ToString(store.Product));
                TableDisplay.PrintLine();
            }
        }
    }
}