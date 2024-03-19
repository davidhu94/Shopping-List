using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsShoppingList
{
    public interface IState
    {
        void HandleCreateButton(MainWindow context);
        void HandleEditButton(MainWindow context);
        void HandleDeleteButton(MainWindow context);
        void HandleSortButton(MainWindow context);
        void HandleSearchButton(MainWindow context, string searchText);
    }
}
