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
using WindowsFormsApp1.BLL;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public partial class OrderUi : Form
    {
        OrderManager _orderManager = new OrderManager();
        OrderManager _orderRepository = new OrderManager();
        Order _order = new Order();
        public OrderUi()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {

           if (String.IsNullOrEmpty(quantityTextBox.Text))
            {
                MessageBox.Show("quantity Can not be Empty!!!");
                return;
            }           
            _order.CustomerId = (Convert.ToInt32(customerComboBox.SelectedValue));
            _order.TotalPrice = Convert.ToInt32(totalPriceTextBox.Text);
            _order.ItemId = (Convert.ToInt32(itemComboBox.SelectedValue));
            _order.Quantity = (Convert.ToInt32(quantityTextBox.Text));
            
            bool isOrderAdded = _orderManager.AddOrder(_order);

            if (isOrderAdded)
            {
                MessageBox.Show("Save Order");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }

            showDataGridView.DataSource = _orderManager.Display();
        }
   
        private void OrderUi_Load(object sender, EventArgs e)
        {
            customerComboBox.DataSource= _orderManager.CustomerCombo();
            itemComboBox.DataSource = _orderManager.ItemCombo();
        }
    }
}
