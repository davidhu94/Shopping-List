using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsShoppingList.Commands
{
    public class GetItemsCommand : ICommand
    {
        private readonly ShoppingList shoppingList;
        private List<string> items;

        public GetItemsCommand(ShoppingList shoppingList)
        {
            this.shoppingList = shoppingList;
        }

        public void Execute()
        {
            items = shoppingList.GetItems();
        }

        public List<string> GetResult()
        {
            return items;
        }
    }
}
