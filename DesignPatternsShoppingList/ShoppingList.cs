using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsShoppingList
{
    public class ShoppingList 
    {
        private List<IShoppingListObserver> observers = new List<IShoppingListObserver>();

        public List<string> items;
        public ShoppingList()
        {
            items = new List<string>();
        }
        public void Attach(IShoppingListObserver observer)
        {
            observers.Add(observer);
        }
        public void Detach(IShoppingListObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers(string newItem)
        {
            foreach (var observer in observers)
            {
                observer.Update(newItem);
            }
        }
        
        public void AddItem(string item)
        {
            items.Add(item);
        }
        public void RemoveItem(string item)
        {
            items.Remove(item);
        }
        public void UpdateAt(int index, string item) 
        {
            items[index] = item;
            NotifyObservers(item);
        }
        public List<string> GetItems()
        {
            return items;
        }

        
    }
}
