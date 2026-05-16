using Microsoft.VisualBasic.ApplicationServices;
using Store.Classes;
using Store.Methods;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace Store.Database
{
    internal class Actions
    {

        public static int GetRoleID { get; set; }
        public static string GetUserID { get; set; }
        public static string GetName { get; set; }

        public int getRoleID
        {
            get { return GetRoleID; }
            set { GetRoleID = value; }
        }
        public string getUserID
        {
            get { return GetUserID; }
            set { GetUserID = value; }
        }

        public string getName
        {
            get { return GetName; }
            set { GetName = value; }
        }

        public static string checkCategory(SQLiteConnection con,string category_name)
        {
            string sql = "SELECT * FROM category_tbl WHERE category_name = ?";
            string categoryID = "";

            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql,con)) {
                    cmd.Parameters.AddWithValue("@category_name", category_name);
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) { 
                            categoryID = reader["category_id"].ToString();
                        }
                    }
                }

            }
            catch (SQLiteException ex)
            {
                Debug.Print(ex.Message);
            }
            catch (Exception ex) {
                Debug.Print(ex.Message);
            }

            return categoryID;
        }
        public static bool checkCredential(SQLiteConnection con, string user,string password)
        {
            string sql = "SELECT * FROM user_tbl where user_name = ?";
            try
            {
                using (SQLiteCommand cmd  = new SQLiteCommand(sql,con))
                {
                    cmd.Parameters.AddWithValue("@user_name",user);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Moves the cursor to the first row
                        {
                            string encryptedPass = reader["password"].ToString();
                            bool isValid = BCrypt.Net.BCrypt.Verify(password, encryptedPass);

                            if (isValid)
                            {
                                int role_id = Convert.ToInt32(reader["role_id"]);
                                string userId = reader["user_id"].ToString();
                                GetRoleID = role_id;
                                GetUserID = userId;

                                return true;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return false;
            }
            return false;
            
        }


        public static List<Item> getItems(SQLiteConnection con)
        {
            List<Item> items = new List<Item>();
            string sql = "select c.category_id as CategoryId," +
                "c.category_name as CategoryName," +
                "i.item_name as ItemName," +
                "i.item_quantity as ItemQuantity," +
                "i.item_grams as ItemGrams," +
                "i.item_ml as ItemML," +
                "i.item_price as ItemPrice," +
                "i.sell_price as SellPrice," +
                "i.item_id as ItemId from category_tbl as c INNER JOIN items_tbl as i where c.category_id = i.category_id";
            using (SQLiteCommand cmd = new SQLiteCommand(sql,con))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new Item
                        {
                            CategoryId = reader["CategoryId"].ToString(),
                            CategoryName = reader["CategoryName"].ToString(),
                            ItemName = reader["ItemName"].ToString(),
                            ItemQuantity = Convert.ToInt32(reader["ItemQuantity"]),
                            Grams = reader["ItemGrams"].ToString(),
                            Milliliters = reader["ItemML"].ToString(),
                            ItemPrice = Convert.ToDecimal(reader["ItemPrice"]),
                            SellPrice  = Convert.ToDecimal(reader["SellPrice"]),
                            ItemId = reader["ItemId"].ToString()
                        });

                    }
                }
            }
            return items;

        }

        public static bool removeItem(SQLiteConnection con,string item_id)
        {
            string sql = "DELETE FROM items_tbl WHERE item_id = ?";
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql,con))
                {
                    cmd.Parameters.AddWithValue("@item_id", item_id);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }catch(SQLiteException ex)
            {
                Debug.Print(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return false;
        }
        
        public static bool addItem(SQLiteConnection con,string category_name,string itemName,int quantity,
            string grams,string ml,decimal itemPrice,decimal sellPrice)
        {

            string category_id = LstFunction.GenerateUniqueKey();
            string item_id = LstFunction.GenerateUniqueKey();
            string sql1 = "INSERT INTO category_tbl(category_name,category_id) values(?,?)";
            string sql2 = "INSERT INTO items_tbl(category_id,item_name,item_quantity,item_grams,item_ml,item_price,sell_price,item_id)" +
                            "values(?,?,?,?,?,?,?,?)";

            try
            {
                string holderID = checkCategory(con, category_name);
                if (holderID == "")
                {
                    
                    using (SQLiteCommand cmd = new SQLiteCommand(sql1, con))
                    {
                        cmd.Parameters.AddWithValue(null, category_name);
                        cmd.Parameters.AddWithValue(null, category_id);

                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    category_id = holderID;
                }

                using (SQLiteCommand cmd = new SQLiteCommand(sql2, con))
                {
                    cmd.Parameters.AddWithValue(null, category_id);
                    cmd.Parameters.AddWithValue(null, itemName);
                    cmd.Parameters.AddWithValue(null, quantity);
                    cmd.Parameters.AddWithValue(null, grams);
                    cmd.Parameters.AddWithValue(null, ml);
                    cmd.Parameters.AddWithValue(null, itemPrice);
                    cmd.Parameters.AddWithValue(null, sellPrice);
                    cmd.Parameters.AddWithValue(null, item_id);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return false;
            }
            
            return false;
        }
        public static bool addUser(SQLiteConnection con, string name,string user,string pass,string role_desc)
        {

            string userUnique = LstFunction.GenerateUniqueKey();
            string encryptPass = BCrypt.Net.BCrypt.HashPassword(pass);
            int role_id = (role_desc.ToUpper() == "CASHIER" ? 2 : 1);

            string sql = "INSERT INTO user_tbl(name,user_name,password,role_desc,role_id,user_id) values(?,?,?,?,?,?)";
            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql,con)) {
                    cmd.Parameters.AddWithValue(null,name);
                    cmd.Parameters.AddWithValue(null, user);
                    cmd.Parameters.AddWithValue(null, encryptPass);
                    cmd.Parameters.AddWithValue(null, role_desc);
                    cmd.Parameters.AddWithValue(null, role_id);
                    cmd.Parameters.AddWithValue(null, userUnique);

                    cmd.ExecuteNonQuery();
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                return false;
            }
        }
    }
}
