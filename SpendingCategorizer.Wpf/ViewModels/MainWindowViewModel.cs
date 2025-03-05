using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using SpendingCategorizer.Core;
using SpendingCategorizer.Core.Models;
using SpendingCategorizer.Data;
using SpendingCategorizer.Wpf.Views;

namespace SpendingCategorizer.Wpf
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly TransactionCsvService _csvService;

        // Collection bound to the DataGrid in the UI
        public ObservableCollection<Transaction> Transactions { get; set; }
            = new ObservableCollection<Transaction>();

        // Commands for buttons
        public ICommand OpenCsvCommand { get; }
        public ICommand SaveCsvCommand { get; }
        public ICommand ClearCommand { get; }
        public ICommand OpenChaseCsvCommand { get; }
        public ICommand OpenCCUCommand { get; }
        public ICommand OpenRemoveSuspectedCCPayments { get; }
        public ICommand OpenManageCategoriesWindowCommand { get; } 

        public MainWindowViewModel()
        {
            _csvService = new TransactionCsvService();

            // Set up commands using a RelayCommand
            OpenCsvCommand = new RelayCommand(OpenCsv);
            SaveCsvCommand = new RelayCommand(SaveCsv);
            ClearCommand = new RelayCommand(Clear);

            OpenRemoveSuspectedCCPayments = new RelayCommand(OpenRemoveCCWindow);
            OpenCCUCommand = new RelayCommand(OpenCCUCsv);
            OpenChaseCsvCommand = new RelayCommand(OpenChaseCsv);
            OpenManageCategoriesWindowCommand = new RelayCommand(OpenManageCategoriesWindow);

        }

        private void OpenRemoveCCWindow()
        {
            var reviewWindow = new ReviewSuspectedCCPaymentsWindow(Transactions);
           // reviewWindow.Owner = this;
            reviewWindow.ShowDialog();
        }

        private void OpenCsv()
        {
            try
            {

            var ofd = new OpenFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
            };

            if (ofd.ShowDialog() == true)
            {
                var txList = _csvService.ReadTransactions(ofd.FileName);

                // Automatically categorize after loading
                TransactionCategorizer.Categorize(txList);

                // Update the ObservableCollection for the UI
                Transactions.Clear();
                foreach (var t in txList)
                {
                    Transactions.Add(t);
                }
            }

            }
            catch (Exception e)
            {

                MessageBox.Show($"Failed to open csv: {e.Message}");
            }
            finally
            {

            }
        }
        public void OpenCCUCsv()
        {
            try
            {
                var ofd = new OpenFileDialog
                {
                    Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
                };

                if (ofd.ShowDialog() == true)
                {
                    var txList = _csvService.ReadCcuCsv(ofd.FileName);

                    // Automatically categorize after loading
                    TransactionCategorizer.Categorize(txList);

                    // Update the ObservableCollection for the UI
                    //Transactions.Clear();
                    foreach (var t in txList)
                    {
                        Transactions.Add(t);
                    }
                }
            }
            catch (Exception e)
            {

                MessageBox.Show($"Failed to open csv: {e.Message}");
            }
        }
        public void OpenChaseCsv()
        {
            try
            {
                var ofd = new OpenFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
            };

            if (ofd.ShowDialog() == true)
            {
                var txList = _csvService.ReadChaseCsv(ofd.FileName);

                // Automatically categorize after loading
                TransactionCategorizer.Categorize(txList);

                // Update the ObservableCollection for the UI
                //Transactions.Clear();
                foreach (var t in txList)
                {
                    Transactions.Add(t);
                }
            }
        }
            catch (Exception e)
            {

                MessageBox.Show($"Failed to open csv: {e.Message}");
            }
            finally
            {

            }
        }

        public void Clear()
        {
            this.Transactions.Clear();
        }

        public void SaveCsv()
        {
            try
            {
                var sfd = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
            };

            if (sfd.ShowDialog() == true)
            {
                _csvService.WriteTransactions(sfd.FileName, Transactions);
            }

        }
            catch (Exception e)
            {

                MessageBox.Show($"Failed to open csv: {e.Message}");
            }
            finally
            {
            }

        }
        public void OpenManageCategoriesWindow()
        {
            var manageCategoriesWindow = new ManageCategoriesWindow(App.CategoryLibrary);
            manageCategoriesWindow.ShowDialog();
        }

    }
}
