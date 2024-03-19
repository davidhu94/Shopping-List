using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsShoppingList
{
    public class MainWindowObserver : IShoppingListObserver
    {
        private readonly MainWindow mainWindow;

        public MainWindowObserver(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void Update(string newItem)
        {  
            mainWindow.RefreshShoppingListBox();
        }
    }
}
