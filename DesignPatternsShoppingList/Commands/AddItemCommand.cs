using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsShoppingList.Commands
{
    public class AddItemCommand : ICommand
    {
        private readonly ShoppingList shoppingList;
        private readonly string item;

        public AddItemCommand(ShoppingList shoppingList, string item)
        {
            this.shoppingList = shoppingList;
            this.item = item;
        }

        public void Execute()
        {
            shoppingList.AddItem(item);
        }
    }

}
