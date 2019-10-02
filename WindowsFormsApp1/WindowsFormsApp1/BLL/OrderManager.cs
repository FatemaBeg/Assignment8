using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsApp1.Reository;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.BLL
{
   public class OrderManager
    {
        OrderRepository _orderRepository = new OrderRepository();
        
        public bool AddOrder(Order order)
        {
                   
            return _orderRepository.AddOrder(order);
        }
     
       
        public DataTable Display()
        {
            return _orderRepository.Display();
        }
        public DataTable ItemCombo()
        {
            return _orderRepository.ItemCombo();
        }
        public DataTable CustomerCombo()
        {
            return _orderRepository.CustomerCombo();
        }
    }
}
