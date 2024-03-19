using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DesignPatternsShoppingList
{
    public class NormalState : IState
    {
        public void HandleCreateButton(MainWindow mainWindow)
        {
            EditWindow editWindow = new EditWindow(mainWindow.shoppingList, mainWindow);
            editWindow.Show();
            mainWindow.Hide();
        }

        public void HandleDeleteButton(MainWindow mainWindow)
        {
            if (mainWindow.shoppingList != null && mainWindow.ShoppingListBox.SelectedIndex != -1 && mainWindow.shoppingList.items.Count > 0)
            {
                MessageBoxResult result = MessageBox.Show("Do you want to delete this list?", "Confirmation", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    mainWindow.shoppingList.items.RemoveAt(mainWindow.ShoppingListBox.SelectedIndex);
                    mainWindow.RefreshShoppingListBox();
                }
            }
            else
            {
                MessageBox.Show("You need to select an item.");
            }
        }

        public void HandleEditButton(MainWindow mainWindow)
        {
            if (mainWindow.ShoppingListBox.SelectedItem != null)
            {
                string selectedItem = mainWindow.ShoppingListBox.SelectedItem.ToString();
                int selectedIndex = mainWindow.ShoppingListBox.SelectedIndex;

                EditWindow editWindow = new EditWindow(mainWindow.shoppingList, selectedItem, selectedIndex, mainWindow);
                editWindow.Show();
            }
            else
            {
                MessageBox.Show("Please select an item to edit.");
            }
        }

        public void HandleSearchButton(MainWindow mainWindow, string searchText)
        {
            if (!string.IsNullOrEmpty(searchText))
            {
                mainWindow.ShoppingListBox.Items.Clear();
                foreach (string item in mainWindow.shoppingList.GetItems())
                {
                    if (item.Contains(searchText))
                    {
                        mainWindow.ShoppingListBox.Items.Add(item);
                    }
                }
            }
            else
            {
                mainWindow.RefreshShoppingListBox();
            }
        }

        public void HandleSortButton(MainWindow mainWindow)
        {
            mainWindow.sort.QuickSort(mainWindow.shoppingList);
            mainWindow.RefreshShoppingListBox();
        }
    }
}
