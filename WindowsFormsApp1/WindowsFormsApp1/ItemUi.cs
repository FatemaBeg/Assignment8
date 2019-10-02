using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;
using WindowsFormsApp1.BLL;

namespace WindowsFormsApp1
{
    public partial class ItemUi : Form
    {
        int Record_Id;
        ItemManager _itemRepository = new ItemManager();
        ItemManager _itemManager = new ItemManager();
        Item _item = new Item();
     
        public ItemUi()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            showDataGridView.DataSource = _itemRepository.Display();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(itemPriceTextBox.Text))
            {
                MessageBox.Show("Price Can not be Empty!!!");
                return;
            }
            _item.ItemName = itemNameTextBox.Text;
            if (_itemRepository.ItemIsNameExists(_item.ItemName))
            {
                MessageBox.Show(itemNameTextBox.Text + "Already Exists! plz Enter Another Name");
                return;
            }
            _item.Price = Convert.ToDouble(itemPriceTextBox.Text);
            //bool isAdded = _itemManager.Add(_item.Name, _item.Price);
            bool isAdded = _itemManager.Add(_item);
           
            //bool isAdded = _itemRepository.Add(_item.Name, _item.Price);

            if (isAdded)
            {
                MessageBox.Show("Save Item");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }

            showDataGridView.DataSource = _itemRepository.Display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(itemNameTextBox.Text))
            {
                MessageBox.Show("Name Can not be Empty!!!");
                return;
            }

            if (_itemRepository.DeleteItem((Convert.ToInt32(Record_Id))))
            {
                MessageBox.Show("item Deleted");
                showDataGridView.DataSource = _itemRepository.Display();
            }
            else
            {
                MessageBox.Show("item Not Deleted");
            }

           
        }

        private void button4_Click(object sender, EventArgs e)
        {
           

            if (_itemRepository.UpdateItem(itemNameTextBox.Text, (Convert.ToDouble(itemPriceTextBox.Text)), (Convert.ToInt32(Record_Id))))
             {

               MessageBox.Show("Item  Updated");
                showDataGridView.DataSource = _itemRepository.Display();

            }
             else
             {
               MessageBox.Show(" Item Not Update");
               
             }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(itemNameTextBox.Text))
            {
                MessageBox.Show("Name Can not be Empty!!!");
                return;
            }
            DataTable dataTable = new DataTable();
            dataTable = _itemRepository.SearchItem(itemNameTextBox.Text);
            if (dataTable.Rows.Count > 0)
            {
                showDataGridView.DataSource = dataTable;
                MessageBox.Show(itemNameTextBox.Text + " Item found");
                return;
            }
            else
            {
                MessageBox.Show("Item not found");
            }
        }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Record_Id = Convert.ToInt32(showDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
            itemNameTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            itemPriceTextBox.Text= showDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
        }
    }
}
