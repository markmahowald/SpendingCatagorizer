using SpendingCategorizer.Core.Models;
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

namespace SpendingCategorizer.Wpf.Views
{
    /// <summary>
    /// Interaction logic for ManageCategoriesWindow.xaml
    /// </summary>
    public partial class ManageCategoriesWindow : Window
    {
        private TransactionCatagoryLibrary _categoryLibrary;
        private MainWindowViewModel _mainWindowViewModel;

        public ManageCategoriesWindow(TransactionCatagoryLibrary categoryLibrary, MainWindowViewModel mainviewmodel)
        {
            InitializeComponent();
            _categoryLibrary = categoryLibrary;
            this._mainWindowViewModel = mainviewmodel;
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            string category = CategoryTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(category) && !_categoryLibrary.Categories.ContainsKey(category))
            {
                _categoryLibrary.AddCategory(category, new string[] { });
                _categoryLibrary.SaveCategoriesToJson();
                this._mainWindowViewModel.RefreshCategoryList();
                
                MessageBox.Show($"Category '{category}' added!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Category already exists or is empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AddKeyword_Click(object sender, RoutedEventArgs e)
        {
            string category = CategoryTextBox.Text.Trim();
            string keyword = KeywordTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(category) && !string.IsNullOrEmpty(keyword))
            {
                if (_categoryLibrary.Categories.ContainsKey(category))
                {
                    _categoryLibrary.AddKeywordToCategory(category, keyword);
                    _categoryLibrary.SaveCategoriesToJson();
                    MessageBox.Show($"Keyword '{keyword}' added to '{category}'!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Category does not exist!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Both category and keyword must be provided!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}