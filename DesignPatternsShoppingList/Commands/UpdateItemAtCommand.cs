using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsShoppingList.Commands
{
    public class UpdateItemAtCommand : ICommand
    {
        private readonly ShoppingList shoppingList;
        private readonly int index;
        private readonly string newItem;

        public UpdateItemAtCommand(ShoppingList shoppingList, int index, string newItem)
        {
            this.shoppingList = shoppingList;
            this.index = index;
            this.newItem = newItem;
        }

        public void Execute()
        {
            shoppingList.UpdateAt(index, newItem);
        }
    }
}
