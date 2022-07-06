using patientlist.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace patientlist.ViewModels
{
    public class ContactMappingViewModel : ViewModelBase, INotifyDataErrorInfo
    {

        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyAndDisplayChanged(nameof(FirstName));

            }
        }

        private string _lastName;

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyAndDisplayChanged(nameof(LastName));
            }
        }

        private string _age;


        public string Age
        {
            get
            {
                return _age;
            }
            set
            {
                RemoveError(nameof(Age));

                if (!int.TryParse(value, out int newAge))
                    AddError(nameof(Age), "Please type a number");

                _age = value;
                OnPropertyAndDisplayChanged(nameof(Age));
            }
        }

        
        public string DisplayContact => $"{_firstName}, {_lastName} ({_age})";

        #region INotifyDataErrorInfo

        private readonly Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();

        public bool HasErrors => _propertyErrors.Any();

        public IEnumerable GetErrors(string propertyName)
        {
            return _propertyErrors.GetValueOrDefault(propertyName, null);
        }


        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        #endregion

        public void AddError(string propertyName, string errorMessage)
        {
            if (!_propertyErrors.ContainsKey(propertyName))
                _propertyErrors.Add(propertyName, new List<string>());

            _propertyErrors[propertyName].Add(errorMessage);
            OnErrorsChanged(propertyName);
        }

        public void RemoveError(string propertyName)
        {
            if (_propertyErrors.Remove(propertyName))
                OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(string propertyName) => ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));

        public ContactMappingViewModel(Contact contact, PropertyChangedEventHandler onAgePropertyChanged) : this(
            contact.FirstName,
            contact.LastName,
            contact.Age.ToString(),
            onAgePropertyChanged
        )
        { }

        public ContactMappingViewModel(string firstName, string lastName, string age, PropertyChangedEventHandler onAgePropertyChanged)
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
            PropertyChanged += onAgePropertyChanged;
        }
    }
}
