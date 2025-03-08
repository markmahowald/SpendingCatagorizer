using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for CategoryEditor.xaml
    /// </summary>
    public partial class CategoryEditor : Window
    {
        //public ObservableCollection<string> Categories { get; set; }
        public string SelectedCategory { get; set; }
        public string FilterString { get; set; }

        private readonly MainWindowViewModel _mainWindowViewModel;
        public ObservableCollection<string> Categories { get; set; }
        //public ICommand SaveCommand { get; }


        public CategoryEditor(ObservableCollection<string> categories, string description, MainWindowViewModel mainWindowViewModel)
        {
            Categories = categories;
            FilterString = description;
            _mainWindowViewModel = mainWindowViewModel;
           // _onSave = onSave;

            //SaveCommand = new RelayCommand(Save);
            DataContext = this;
            InitializeComponent();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    if (!string.IsNullOrWhiteSpace(SelectedCategory) && !string.IsNullOrWhiteSpace(FilterString))
        //    {
        //        var catLib =  App.CategoryLibrary;
        //        catLib.Categories[this.SelectedCategory].Append(FilterString);
        //            _mainWindowViewModel.RefreshCategoryList();
        //        Close();
        //    }
        //}
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SelectedCategory) && !string.IsNullOrWhiteSpace(FilterString))
            {
                var catLib = App.CategoryLibrary;

                if (catLib.Categories.ContainsKey(SelectedCategory))
                {
                    // Convert array to list, modify, and assign back
                    var existingValues = catLib.Categories[SelectedCategory].ToList();
                    existingValues.Add(FilterString);
                    catLib.Categories[SelectedCategory] = existingValues.ToArray();
                }
                else
                {
                    // If category doesn't exist, add it
                    catLib.Categories[SelectedCategory] = new string[] { FilterString };
                }

                _mainWindowViewModel.RefreshCategoryList();
                Close();
            }
        }


    }
}
