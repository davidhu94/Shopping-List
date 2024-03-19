using DesignPatternsShoppingList.Commands;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DesignPatternsShoppingList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IShoppingListObserver
    {
        private IState currentState;
        public ShoppingList shoppingList; 
        public Sort sort = new Sort();
        public MainWindow() 
        {
            InitializeComponent();
            this.shoppingList = new ShoppingList();
            this.shoppingList.Attach(new MainWindowObserver(this));
            SetState(new NormalState());

        }
        public MainWindow(ShoppingList shoppingList) : this()
        {
            InitializeComponent();
            this.shoppingList = shoppingList;
            this.shoppingList.Attach(this);
            RefreshShoppingListBox();

        }
        public void SetState(IState state)
        {
            currentState = state;
        }
        public void Update(string newItem)
        {
            RefreshShoppingListBox();
        }

        public void RefreshShoppingListBox()
        {
            ShoppingListBox.Items.Clear();
            ICommand getItemsCommand = new GetItemsCommand(shoppingList);
            getItemsCommand.Execute();
            List<string> items = ((GetItemsCommand)getItemsCommand).GetResult();

            foreach (string item in items)
            {
                ShoppingListBox.Items.Add(item);
            }
        }

        public void SetShoppingList(ShoppingList shoppingList)
        {
            this.shoppingList = shoppingList;
            RefreshShoppingListBox();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            currentState.HandleCreateButton(this);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            currentState.HandleDeleteButton(this);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            currentState.HandleEditButton(this);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text;
            currentState.HandleSearchButton(this, searchText);
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            currentState.HandleSortButton(this);

        }
    }
}