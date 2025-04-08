using System.Collections.Specialized;
using System.ComponentModel;

namespace Components
{
    public class WorkersViewModel : INotifyPropertyChanged
    {
        private int _id { get; set; }
        public int Id
        {
            get => _id;
            set
            {
                if (_id == value)
                {
                    return;
                }
                _id = value;
                NotifyPropertyChanged(nameof(Id));
            }
        }
        private string _firstName;
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName == value)
                {
                    return;
                }
                _firstName = value;
                NotifyPropertyChanged(nameof(FirstName));
            }
        }
        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName == value)
                {
                    return;
                }
                _lastName = value;
                NotifyPropertyChanged(nameof(LastName));
            }
        }
        private char _gender { get; set; }
        public char Gender
        {
            get => _gender;
            set
            {
                if (_gender == value)
                {
                    return;
                }
                _gender = value;
                NotifyPropertyChanged(nameof(Gender));
            }
        }
        private int _annualSalary;
        public int AnnualSalary
        {
            get => _annualSalary;
            set
            {
                if (_annualSalary == value)
                {
                    return;
                }
                _annualSalary = value;
                NotifyPropertyChanged(nameof(AnnualSalary));
            }
        }
        public bool IsManager { get; set; }

        private void NotifyPropertyChanged(string propertyNames)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyNames));
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
