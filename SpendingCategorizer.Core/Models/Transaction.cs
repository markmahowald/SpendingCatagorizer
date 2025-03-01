using System;
using System.ComponentModel;

namespace SpendingCategorizer.Core.Models
{
    public class Transaction : INotifyPropertyChanged
    {
        private DateTime? _transactionDate;
        private string? _description;
        private string? _source;
        private float? _amount;
        private string? _category;

        public event PropertyChangedEventHandler? PropertyChanged;

        public DateTime? TransactionDate
        {
            get => _transactionDate;
            set
            {
                if (_transactionDate != value)
                {
                    _transactionDate = value;
                    OnPropertyChanged(nameof(TransactionDate));
                }
            }
        }

        public string? Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public string? Source
        {
            get => _source;
            set
            {
                if (_source != value)
                {
                    _source = value;
                    OnPropertyChanged(nameof(Source));
                }
            }
        }

        public float? Ammount
        {
            get => _amount;
            set
            {
                if (_amount != value)
                {
                    _amount = value;
                    OnPropertyChanged(nameof(Ammount));
                }
            }
        }

        public string? Category
        {
            get => _category;
            set
            {
                if (_category != value)
                {
                    _category = value;
                    OnPropertyChanged(nameof(Category));
                }
            }
        }

        public Transaction(DateTime transactionDate, string description, string source, float ammount, string category = "")
        {
            TransactionDate = transactionDate;
            Description = description;
            Source = source;
            Ammount = ammount;
            Category = category;
        }

        public Transaction() { }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
