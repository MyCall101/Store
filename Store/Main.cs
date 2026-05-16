using Microsoft.VisualBasic.ApplicationServices;
using Store.Database;
using Store.Forms;
using Store.Methods;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Store
{
    public partial class Main : Form
    {

        DBCon db = new DBCon();
        Actions act = new Actions();
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

            this.BackColor = ColorTranslator.FromHtml("#F1F5F9"); //light gray
            pnlHeader.BackColor = ColorTranslator.FromHtml("#2563EB");
            lblTitle.ForeColor = ColorTranslator.FromHtml("#F1F5F9");


            //TabPage3
            g2PnlItems.BorderThickness = 0;
            g2PnlItems.CustomBorderThickness = new Padding(0, 0, 3, 0);
            g2PnlItems.CustomBorderColor = ColorTranslator.FromHtml("#212A39");
            g2PnlItemTitleShadow.FillColor = ColorTranslator.FromHtml("#2563EB");
            g2BtnAddItem.FillColor = ColorTranslator.FromHtml("#2563EB");
            g2BtnEdit.FillColor = ColorTranslator.FromHtml("#2563EB");
            g2DGV.BackgroundColor = ColorTranslator.FromHtml("#94A3B8");

            SQLiteConnection con = db.DbConnection();
            g2DGV.AutoGenerateColumns = false;
            g2DGV.DataSource = Actions.getItems(con);
            LstFunction.displayDataGridViewItems(this.g2DGV);

            tabPage1.BackColor = ColorTranslator.FromHtml("#94A3B8");
            tabPage2.BackColor = ColorTranslator.FromHtml("#94A3B8");
            tabPage3.BackColor = ColorTranslator.FromHtml("#94A3B8");

            if (act.getRoleID == 1)
            {
                //TabPage4
                guna2ShadowPnlTitle.FillColor = ColorTranslator.FromHtml("#2563EB");

                tabPage4.BackColor = ColorTranslator.FromHtml("#94A3B8");

                // resize            
                int addWidth = g2PnlForm.Width - ((g2TxbName.Size.Width + 10) + (g2LblName.Size.Width + 10));
                int addPWidth = g2PnlForm.Width - ((g2TxbPassword.Size.Width + 10) + (g2LblPassword.Size.Width + 10));
                int addCmBWidth = g2PnlForm.Width - ((g2CmbRole.Size.Width + 10) + (g2LblRole.Size.Width + 10));

                g2LblName.Left = g2LblName.Left + 5;
                g2TxbName.Width = addWidth + (g2TxbName.Size.Width - 15 - g2LblName.Left);
                g2TxbName.Left = g2TxbName.Left + 15;

                g2LblUser.Left = g2LblUser.Left + 5;
                g2TxbUser.Width = addWidth + (g2TxbUser.Size.Width - 5 - g2LblUser.Left);
                g2TxbUser.Left = g2TxbUser.Left + 15;

                g2LblPassword.Left = g2LblPassword.Left + 5;
                g2TxbPassword.Width = addPWidth + (g2TxbPassword.Size.Width - 18 - g2LblPassword.Left);
                g2TxbPassword.Left = g2TxbPassword.Left + 15;

                g2LblRole.Left = g2LblRole.Left + 5;
                g2CmbRole.Width = addCmBWidth + (g2CmbRole.Size.Width - 15 - g2LblRole.Left);
                g2CmbRole.Left = g2CmbRole.Left + 15;

                g2BtnRegister.Left = (g2PnlForm.Width / 2) - 50;
                g2BtnRegister.FillColor = ColorTranslator.FromHtml("#2563EB");
            }
            else
            {
                guna2TabControl1.TabPages.Remove(tabPage4);
            }


        }

        private void g2BtnRegister_Click(object sender, EventArgs e)
        {
            string name = g2TxbName.Text;
            string user = g2TxbUser.Text;
            string password = g2TxbPassword.Text;
            string role_desc = g2CmbRole.Text;
            SQLiteConnection con = db.DbConnection();

            bool success = Actions.addUser(con, name, user, password, role_desc);
            if (success)
            {
                MessageBox.Show("Successfully registered", "REGISTERED", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearInput();
            }
            else
            {
                MessageBox.Show("Failed to registered", "REGISTERED", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearInput()
        {
            g2TxbName.Text = "";
            g2TxbUser.Text = "";
            g2TxbPassword.Text = "";
            g2CmbRole.Text = "";
            g2CmbRole.SelectedIndex = -1;
            g2CmbRole.SelectedItem = null;
        }

        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2TabControl1.SelectedTab == tabPage1)
            {

            }
            else if (guna2TabControl1.SelectedTab == tabPage4)
            {
                g2TxbName.Focus();
            }
        }

        private void g2TxbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                g2TxbUser.Focus();
            }
        }

        private void g2TxbUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                g2TxbPassword.Focus();
            }
        }

        private void g2TxbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                g2CmbRole.Focus();
            }
        }

        private void g2CmbCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                g2TxbItemName.Focus();
            }
        }

        private void g2TxbItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                g2TxbQuantity.Focus();
            }
        }

        private void g2TxbQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                g2TxbGrams.Focus();
            }
        }

        private void g2TxbGrams_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                g2TxbML.Focus();
            }
        }

        private void g2TxbML_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                g2TxbItmPrice.Focus();
            }
        }

        private void g2TxbItmPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                g2TxbSellPrice.Focus();
            }
        }

        private void g2TxbSellPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                g2BtnAddItem.Focus();
            }
        }

        private void clearInputTab3()
        {
            g2TxbItemName.Text = "";
            g2TxbQuantity.Text = "";
            g2TxbGrams.Text = "";
            g2TxbML.Text = "";
            g2TxbItmPrice.Text = "";
            g2TxbSellPrice.Text = "";
            g2CmbCategory.Text = "";
            g2CmbCategory.SelectedIndex = -1;
            g2CmbCategory.SelectedItem = null;
        }
        private void g2BtnAddItem_Click(object sender, EventArgs e)
        {
            string category = g2CmbCategory.Text;
            string itemName = g2TxbItemName.Text;
            int quantity = Convert.ToInt32(g2TxbQuantity.Text);
            string grams = g2TxbGrams.Text.ToString().Trim();
            string ml = g2TxbML.Text.ToString().Trim();
            decimal itemPrice = Convert.ToDecimal(g2TxbItmPrice.Text);
            decimal sellPrice = Convert.ToDecimal(g2TxbSellPrice.Text);


            SQLiteConnection con = db.DbConnection();

            bool success = Actions.addItem(con, category, itemName, quantity, grams, ml, itemPrice, sellPrice);
            if (success)
            {
                //MessageBox.Show("Successfully added", "ADDED ITEM", MessageBoxButtons.OK, MessageBoxIcon.Information);
                g2DGV.AutoGenerateColumns = false;
                g2DGV.DataSource = Actions.getItems(con);
                LstFunction.displayDataGridViewItems(this.g2DGV);

                clearInputTab3();
            }
            else
            {
                MessageBox.Show("Failed to added", "FAILDED ITEM", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void g2BtnRemove_Click(object sender, EventArgs e)
        {
            if (this.g2DGV != null && this.g2DGV.CurrentRow != null)
            {
                DialogResult confirm = MessageBox.Show("Are you sure you want to remove this item?", "REMOVE", 
                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes) 
                {
                    var sourceList = (List<Store.Classes.Item>)this.g2DGV.DataSource;
                    var itemToRemove = (Store.Classes.Item)this.g2DGV.CurrentRow.DataBoundItem;

                    string item_id = itemToRemove.ItemId;

                    SQLiteConnection con = db.DbConnection();
                    if(Actions.removeItem(con, item_id))
                    {
                        sourceList.Remove(itemToRemove);

                        this.g2DGV.DataSource = null;
                        this.g2DGV.DataSource = sourceList;
                        LstFunction.displayDataGridViewItems(this.g2DGV);
                    }
                    
                }

                
            }
        }
    }
}
