using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Reository;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsApp1.Repository;
using WindowsFormsApp1.Model;
namespace WindowsFormsApp1.BLL
{
    public class ItemManager
    {
        ItemRepository _itemRepository = new ItemRepository();
        public bool Add(Item item)
        {
            
            return _itemRepository.Add(item);
        }
        public bool ItemIsNameExists(string name)
        {
            return _itemRepository.ItemIsNameExists(name);
        }
        
        public bool UpdateItem(string name, double price, int id)
        {
            
            return _itemRepository.UpdateItem(name, price, id);
        }
        public bool DeleteItem(int id)
        {
            return _itemRepository.DeleteItem(id);
        }
        public DataTable SearchItem(string name)
        {
            return _itemRepository.SearchItem(name);
        }
        public DataTable Display()
        {
            return _itemRepository.Display();
        }
    }
}
