using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsShoppingList
{
    public interface IShoppingListObserver
    {
        void Update(string newItem);
    }
}
