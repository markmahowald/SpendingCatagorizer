using System.Collections.ObjectModel;
using System.Security.Cryptography;
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

        }

        private void OpenRemoveCCWindow()
        {
            var reviewWindow = new ReviewSuspectedCCPaymentsWindow(Transactions);
           // reviewWindow.Owner = this;
            reviewWindow.ShowDialog();
        }

        private void OpenCsv()
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
        public void OpenCCUCsv()
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
        public void OpenChaseCsv()
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

        public void Clear()
        {
            this.Transactions.Clear();
        }

        public void SaveCsv()
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
    }
}
