using DesignPatternsShoppingList.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesignPatternsShoppingList
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        ShoppingList shoppingList;  
        private string selectedItem;
        private int selectedIndex;
        MainWindow mainWindow;

        private bool isEdit;

        public EditWindow(ShoppingList shoppingList, MainWindow mainWindow)    // Create
        {
            InitializeComponent();
            this.shoppingList = shoppingList;
            this.mainWindow = mainWindow;
            
        }

        public EditWindow(ShoppingList shoppingList, string selectedItem, int selectedIndex, MainWindow mainWindow)  //Edit
        {
            InitializeComponent();
            this.shoppingList = shoppingList;
            this.selectedItem = selectedItem;
            this.selectedIndex = selectedIndex;
            this.mainWindow = mainWindow;
            ShoppingTextBox.Text = selectedItem;
            isEdit = true;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ShoppingTextBox.Text != "")
            {
                string newItem = ShoppingTextBox.Text;
                ICommand command;
                bool itemExists = false;

                foreach (string item in shoppingList.GetItems())
                {
                    if (item == newItem)
                    {
                        itemExists = true;
                        break;
                    }
                }

                if (!itemExists)
                {
                    if (isEdit == false)
                    {
                        command = new AddItemCommand(shoppingList, newItem);
                        shoppingList.NotifyObservers(newItem);
                    }
                    else
                    {
                        command = new UpdateItemAtCommand(shoppingList, selectedIndex, newItem);
                    }
                    command.Execute();
                    MessageBox.Show("Shopping list saved!");
                }
                else
                {
                    MessageBox.Show("Item already exists in the list.");
                }
            }
            else
            {
                MessageBox.Show("List cannot be empty");
            }
        }
        private void ListsButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.SetShoppingList(shoppingList);
            mainWindow.Show();
            Close();   
        }
    }
}
