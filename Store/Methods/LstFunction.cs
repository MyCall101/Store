using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Methods
{
    internal class LstFunction
    {
        public static string GenerateUniqueKey()
        {
            return Guid.NewGuid().ToString("N");
        }

        public static void displayDataGridViewItems(Guna2DataGridView g2DGV)
        {
            g2DGV.Columns["colCategoryId"].DataPropertyName = "CategoryId";
            g2DGV.Columns["colCategoryName"].DataPropertyName = "CategoryName";
            g2DGV.Columns["colItemName"].DataPropertyName = "ItemName";
            g2DGV.Columns["colItemQuantity"].DataPropertyName = "ItemQuantity";
            g2DGV.Columns["colItemGrams"].DataPropertyName = "ItemGrams";
            g2DGV.Columns["colItemMl"].DataPropertyName = "ItemML";
            g2DGV.Columns["colItemPrice"].DataPropertyName = "ItemPrice";
            g2DGV.Columns["colItemSell"].DataPropertyName = "SellPrice";
            g2DGV.Columns["colItemId"].DataPropertyName = "ItemId";
        }

    }
}
