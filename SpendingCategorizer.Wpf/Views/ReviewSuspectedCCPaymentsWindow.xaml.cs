using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using SpendingCategorizer.Core.Models;


namespace SpendingCategorizer.Wpf.Views
{
    /// <summary>
    /// Interaction logic for ReviewSuspectedCCPaymentsWindow.xaml
    /// </summary>
    public partial class ReviewSuspectedCCPaymentsWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Transaction> _paymentTransactions;
        private int _currentIndex = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        private string windowLabel;

        public string WindowLabel
        {
            get { return windowLabel; }
            set 
            { 
                windowLabel = value;
                OnPropertyChanged(nameof(WindowLabel));
            }
        }

        private Transaction _currentTransaction;
        public Transaction CurrentTransaction
        {
            get => _currentTransaction;
            set
            {
                _currentTransaction = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentTransaction)));
            }
        }

        public ICommand RemoveCommand { get; }
        public ICommand SkipCommand { get; }

        public ReviewSuspectedCCPaymentsWindow(ObservableCollection<Transaction> transactions)
        {
            InitializeComponent();
            DataContext = this;
            _paymentTransactions = transactions;

            RemoveCommand = new RelayCommand(RemoveTransaction);
            SkipCommand = new RelayCommand(SkipTransaction);

            LoadNextTransaction();
        }

        private void LoadNextTransaction()
        {
            if (_paymentTransactions.Count == 0)
            {
                MessageBox.Show("No transactions found.", "Review Complete", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
                return;
            }

            int startIndex = _currentIndex; // Track where we started to avoid infinite loops

            do
            {
                _currentIndex = (_currentIndex + 1) % _paymentTransactions.Count; // Move to next, loop if at end
                if (_paymentTransactions[_currentIndex].Description.ToLower().Contains("payment"))
                {
                    CurrentTransaction = _paymentTransactions[_currentIndex];
                    WindowLabel = $"Review Transaction #{_currentIndex}";
                    return;
                }
            }
            while (_currentIndex != startIndex); // Stop if we looped through all without finding another "payment"

            MessageBox.Show("No more payment transactions to review.", "Review Complete", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }

        private void RemoveTransaction()
        {
            _paymentTransactions.RemoveAt(_currentIndex);
            LoadNextTransaction();
        }

        private void SkipTransaction()
        {
            _currentIndex++;
            LoadNextTransaction();
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}