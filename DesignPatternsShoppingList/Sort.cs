using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsShoppingList
{
    public class Sort
    {
        readonly ShoppingList shoppingList;

        public void QuickSort(ShoppingList shoppingList)
        {
            QuickSortHelper(shoppingList.items, 0, shoppingList.items.Count - 1);
        }

        private void QuickSortHelper(List<string> listToSort, int left, int right)
        {
            if (left < right)
            {
                int partitionIndex = Partition(listToSort, left, right);

                QuickSortHelper(listToSort, left, partitionIndex - 1);
                QuickSortHelper(listToSort, partitionIndex + 1, right);
            }
        }

        private int Partition(List<string> list, int left, int right)
        {
            string pivot = list[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (string.Compare(list[j], pivot) < 0)
                {
                    i++;
                    Swap(list, i, j);
                }
            }
            Swap(list, i + 1, right);
            return i;
        }

        private void Swap(List<string> list, int i, int j)
        {
            string temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

    }
}
